using Podify.Auth;
using Podify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Managers
{
    public interface IAuthenticationManager
    {
        Task Signup(SignupUserModel signupUserModel);

        Task<TokenModel> Login(LoginUserModel loginUserModel);
    }
}