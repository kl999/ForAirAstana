using ForAirAstana.Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAirAstana.Domain
{
    public class UserList
    {
        private readonly ILogger<UserList> _logger;
        private readonly IUserService _userService;

        public UserList(ILogger<UserList> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public User AuthenticateUser(string username, string password)
        {
            var user = _userService.AuthenticateUser(username, password);

            _userService.AuthenticateUser(user);

            _logger.LogInformation($"User #{user.Id} authenticated");

            return user;
        }
    }
}
