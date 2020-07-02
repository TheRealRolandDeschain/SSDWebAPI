using AstroPhotographyHelperService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Interfaces
{
    public interface IUserService
    {
        string Authenticate(AuthenticateRequestModel model);
        string CreateNewUser(UserModel user);
        UserModel GetUserByUserName(string username);
        string UpdateUserByUserName(UserModel user);
        string DeleteUserByUserName(string username);
    }
}
