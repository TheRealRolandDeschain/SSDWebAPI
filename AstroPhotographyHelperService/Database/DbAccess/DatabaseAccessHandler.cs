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
            return response[0];
        }
        #endregion
    }
}
