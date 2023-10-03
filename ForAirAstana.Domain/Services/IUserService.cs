using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAirAstana.Domain.Services
{
    public interface IUserService
    {
        User? AuthenticateUser(string username, string password);
    }
}
