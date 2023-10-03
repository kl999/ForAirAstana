using ForAirAstana.Domain;
using ForAirAstana.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAirAstana.Infrastructure.Controllers
{
    public class UserController : IController
    {
        private readonly UserList _userList;

        public UserController(UserList userList)
        {
            _userList = userList;
        }

        public IResponse GetUser(string username, string password)
        {
            return new Response<User?>
            {
                Code = ResponseCodes.Success,
                Data = _userList.AuthenticateUser(username, password)
            };
        }
    }
}
