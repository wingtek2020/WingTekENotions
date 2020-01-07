using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TekENotions.API.Models;
using TekENotions.API.Data;
using TekENotions.API.DTOs;

namespace TekENotions.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly TekENotionsContext _context;

        public AuthRepository(TekENotionsContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
                return null;
            else
            {
                if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    return null;
            }
            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var i = 0;
                var computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                foreach(var hash in computedhash)
                {
                    if(hash != passwordHash[i])
                        return false;
                        i++;
                }
                return true;
            }
        }

        public async Task<User> Register(UserForRegisterDTO userForRegisterDTO, string password)
        {
           

            User user = new User
            {
                Username = userForRegisterDTO.Username
            };
            
            byte[] hash, salt;

            CreatePasswordHash(password, out hash, out salt);
            user.PasswordHash = hash;
            user.PasswordSalt = salt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;
            return false;
        }

    }
}
