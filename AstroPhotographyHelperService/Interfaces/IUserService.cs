using AstroPhotographyHelperService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponseModel Authenticate(AuthenticateRequestModel model);
    }
}
