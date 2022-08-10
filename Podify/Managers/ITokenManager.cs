using Podify.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podify.Managers
{
    public interface ITokenManager
    {
        Task<string> CreateToken(User user);

    }
}