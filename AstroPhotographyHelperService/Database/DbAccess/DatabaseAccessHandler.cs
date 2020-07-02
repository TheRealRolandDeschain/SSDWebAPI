using AstroPhotographyHelperService.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using AstroPhotographyHelperService.Database.DbModels;
using System.Linq;
using AstroPhotographyHelperService.Helpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AstroPhotographyHelperService.Database.DbAccess
{
    public class DatabaseAccessHandler
    {
        #region Private Fields
        private readonly string connectionString;
        #endregion

        #region Constructor
        public DatabaseAccessHandler()
        {
            connectionString = AppConfigHelper.Configuration.GetConnectionString("SQLDatabase");
        }
        #endregion

        #region Public Methods

        #region Users
        public string TryCreateNewUser(DbUserModel user)
        {
            string response;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                response = connection.Execute("dbo.spAddUser @UserName, @FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt", 
                    new { user.Username, user.FirstName, user.LastName, user.Email, user.PasswordHash, user.PasswordSalt}).ToString();
            }
            return response;
        }

        public string GetUserByUserNameAndPW(string username, string passwordhash)
        {
            List<string> response;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                response = connection.Query<string>("dbo.spAuthorizeUser @UserName, @PasswordHash",
                    new { username, passwordhash }).ToList();
            }
            if (response.Count == 0) return null;
            return response[0];
        }

        public byte[] GetSaltByUserName(string username)
        {
            List<byte[]> response;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                response = connection.Query<byte[]>("dbo.spGetSaltByUserName @UserName",
                    new { username }).ToList();
            }
            if (response.Count == 0) return null;
            return response[0];
        }


        public DbUserModel GetUserByUserName(string username)
        {
            List<DbUserModel> response;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                response = connection.Query<DbUserModel>("dbo.spGetUserByUsername @UserName",
                    new { username}).ToList();
            }
            if (response.Count == 0)
                return null;

            return response[0];
        }

        public string UpdateUserByUserName(DbUserModel user)
        {
            string response;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                response = connection.Execute("dbo.spUpdateUserByUserName @UserName, @FirstName, @LastName, @Email, @PasswordHash, @PasswordSalt",
                    new { user.Username, user.FirstName, user.LastName, user.Email, user.PasswordHash, user.PasswordSalt }).ToString();
            }
            return response;
        }


        public string DeleteUserByUserName(string username)
        {
            string response;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                response = connection.Execute("dbo.spDeleteUserByUsername @UserName",
                    new { username }).ToString();
            }

            return response;
        }
        #endregion

        #region Locations
        public  List<DbLocationModel> TryGetLocationByArea(float longleft, float longright, float lattop, float latbottom)
        {
            List<DbLocationModel> response;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                response = connection.Query<DbLocationModel>("dbo.spGetLocationsByArea @LongLeft, @LongRight, @LatTop, @LatBottom",
                    new { longleft, longright, lattop, latbottom }).ToList();
            }
            return response;
        }

        public string TryCreateNewLocation(DbLocationModel location)
        {
            string response;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                response = connection.Execute("dbo.spAddLocation @UserName, @Name, @Description, @Longitude, @Latitude, @CelestialBody_Name, @CelestialBody_Type, @CelestialBody_ImageUrl",
                    new { location.UserName, location.Name, location.Description, location.Longitude, location.Latitude, 
                        location.CelestialBody_Name, location.CelestialBody_Type, location.CelestialBody_ImageUrl}).ToString();
            }
            return response;
        }

        public  DbLocationModel TryGetLocationByName(string Name)
        {
            List<DbLocationModel> response;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                response = connection.Query<DbLocationModel>("dbo.spGetLocationsByName @Name",
                    new { Name }).ToList();
            }

            if (response.Count == 0) return null;
            return response[0];
        }

        public string DeleteLocationByName(string Name)
        {
            string response;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                response = connection.Execute("dbo.spDeleteLocationByName @Name",
                    new { Name }).ToString();
            }

            return response;
        }
        #endregion

        #endregion
    }
}
