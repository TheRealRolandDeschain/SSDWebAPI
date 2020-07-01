using AstroPhotographyHelperService.Database.DbAccess;
using AstroPhotographyHelperService.Database.DbModels;
using AstroPhotographyHelperService.Helpers;
using AstroPhotographyHelperService.Interfaces;
using AstroPhotographyHelperService.Models;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;

namespace AstroPhotographyHelperService.Services
{
    public class UserService : IUserService
    {
        #region Private Fields
        private readonly SecurityHandler security;
        #endregion

        #region Constructor
        public UserService(SecurityHandler sec)
        {
            security = sec;
        }
        #endregion

        #region Private Methods
        private bool CheckUserModel(UserModel user)
        {
            foreach (PropertyInfo pi in user.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(user);
                    if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region Public Methods
        public string Authenticate(AuthenticateRequestModel model)
        {
            string userName = security.GetUserIfAuthorized(model);

            // return null if user not found
            if (string.IsNullOrEmpty(userName)) return null;

            // authentication successful so generate jwt token
            var token = security.GenerateJwtToken(userName);

            return token;
        }

        public string CreateNewUser(UserModel user)
        {
            if (!CheckUserModel(user)) return null;
            DatabaseAccessHandler db = new DatabaseAccessHandler();
            Tuple<string, byte[]> secInfo = security.GeneratePasswordHash(user.Password);
            DbUserModel dbUser = new DbUserModel()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = secInfo.Item1,
                PasswordSalt = secInfo.Item2 
            };
            string response = db.TryCreateNewUser(dbUser);
            return response;
        }
        #endregion
    }
}

