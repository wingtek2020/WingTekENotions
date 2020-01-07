using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TekENotions.API.DTOs;
using TekENotions.API.Models;

namespace TekENotions.API.Data
{
    public interface IAuthRepository
    {
        Task<User> Register(UserForRegisterDTO user, string password);
        Task<User> Login(string user, string password);
        Task<bool> UserExists(string username);

    }
}
