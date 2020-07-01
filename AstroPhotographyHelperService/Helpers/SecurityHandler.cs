using AstroPhotographyHelperService.Models;
using System;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using AstroPhotographyHelperService.Database.DbAccess;

namespace AstroPhotographyHelperService.Helpers
{
    public class SecurityHandler
    {
        #region Private Fields
        private readonly AppSettings _appSettings;
        #endregion

        public SecurityHandler(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        #region Public Methods
        public string GenerateJwtToken(string user)
        {
            // generate token that is valid for 2 hours
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user)
                }),
                Expires = DateTime.UtcNow.AddMinutes(120),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GetUserIfAuthorized(AuthenticateRequestModel model)
        {
            DatabaseAccessHandler db = new DatabaseAccessHandler();

            byte[] salt = db.GetSaltByUserName(model.Username);
            string hash = GeneratePasswordHash(model.Password, salt).Item1;
            string result = db.GetUserByUserNameAndPW(model.Username, hash);

            if (result != model.Username) return "";
            else return model.Username;

        }

        public Tuple<string, byte[]> GeneratePasswordHash(string pw, byte[] useSalt = null)
        {
            byte[] salt;
            if (useSalt == null)
            {
                // generate a 128-bit salt using a secure PRNG
                salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
            }
            else
            {
                salt = useSalt;
            }

            //System.Diagnostics.Debug.WriteLine("\n================ " + Encoding.ASCII.GetString(salt) + "================\n");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pw,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return new Tuple<string, byte[]>(hashed, salt);
        }
        #endregion
    }
}
