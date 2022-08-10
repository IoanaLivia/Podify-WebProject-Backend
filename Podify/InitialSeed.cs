using Podify.Entities;
using Podify.Auth;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podify
{
    public class InitialSeed
    {
        private RoleManager<Role> _roleManager;
        private UserManager<User> _userManager;
        private AppDbContext _projectContext;

        /*public InitialSeed(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }*/

        public InitialSeed(RoleManager<Role> roleManager, UserManager<User> userManager, AppDbContext projectContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _projectContext = projectContext;
        }

        /*public async void CreateRoles()
        {
            string[] roleNames =
            {
                "Admin",
                "BasicUser"
            };

            foreach (var roleName in roleNames)
            {
                var role = new Role
                {
                    Name = roleName
                };
                _roleManager.CreateAsync(role).Wait();
            }
        }*/

        public async Task SeedRoles()
        {
            if (_projectContext.Roles.Any())
            {
                return;
            }

            string[] roleNames = {
                "Admin",
                "BasicUser"
            };

            foreach (var roleName in roleNames)
            {
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (roleExists)
                {
                    continue;
                }

                await _roleManager.CreateAsync(new Role { Name = roleName });
                await _projectContext.SaveChangesAsync();
            }
        }

        public async Task SeedUsers()
        {
            var usersExist = this._projectContext.Users.Count() > 0;
            if (usersExist)
            {
                return;
            }

            User[] rawUsers = new User[] {
                new User { UserName = "foo", Email = "foo@foo.com"},
                new User { UserName = "bar", Email = "bar@bar.com"}
            };

            foreach (var rawU in rawUsers)
            {
                await this._userManager.CreateAsync(rawU, "pass123AAA" + rawU.Id);
                await this._userManager.AddToRoleAsync(rawU, rawU.Id == "1" ? "Admin" : "BasicUser");
            }
        }
    }
}
