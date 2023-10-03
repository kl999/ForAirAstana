using ForAirAstana.Database;
using ForAirAstana.Domain;
using ForAirAstana.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ForAirAstana.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly AirAstanaDbContext _dbContext;

        public UserService(AirAstanaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? AuthenticateUser(string username, string password)
        {
            var dbUser = _dbContext.Users.FirstOrDefault(i => i.Username == username && i.Password == ComputeSHA256(password));

            if (dbUser is null)
                return null;

            return new User()
            {
                Id = dbUser.Id,
                Username = dbUser.Username,
                RoleId = dbUser.RoleId,
                Password = dbUser.Password,
            };
        }

        private string ComputeSHA256(string s)
        {
            string hash = String.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash;
        }
    }
}
