using Microsoft.AspNetCore.Identity;
using Podify.Models;
using Podify.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Podify.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> singInManager;
        private readonly ITokenManager tokenManager;
        public AuthenticationManager(UserManager<User> userManager, SignInManager<User> signInManager,
            ITokenManager tokenManager)

        {
            this.userManager = userManager;
            this.singInManager = signInManager;
            this.tokenManager = tokenManager;
        }

        public async Task Signup(SignupUserModel signupUserModel)
        {

            var user = new User
            {
                Email = signupUserModel.Email,
                UserName = signupUserModel.Email
            };

            var result = await userManager.CreateAsync(user, signupUserModel.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, signupUserModel.RoleId);
            }

        } // acum am user-ul in baza

        public async Task<TokenModel> Login(LoginUserModel loginUserModel)
        {
            var user = await userManager.FindByEmailAsync(loginUserModel.Email);
            if (user != null)
            {
                var result = await singInManager.CheckPasswordSignInAsync(user, loginUserModel.Password, false);

                if (result.Succeeded)
                {
                    //Create token
                    var token = await tokenManager.CreateToken(user); //new manager responsible with creating the token

                    return new TokenModel { Token = token };
                }
            }

            return null;
        }

    }

}