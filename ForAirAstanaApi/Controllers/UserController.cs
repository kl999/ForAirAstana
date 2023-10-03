using ForAirAstana.Domain;
using ForAirAstana.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ForAirAstanaApi.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly C3Controller<ForAirAstana.Infrastructure.Controllers.UserController> _controller;

        public UserController(
            ILogger<UserController> logger,
            C3Controller<ForAirAstana.Infrastructure.Controllers.UserController> controller)
        {
            _logger = logger;
            _controller = controller;
        }

        [HttpGet(Name = "Authenticate")]
        public IResponse Authenticate(string username, string password)
        {

            var response = _controller.Invoke(ctrl => ctrl.GetUser(username, password)) as IResponse<User?>;

            if(response is null)
                return new EmptyResponse()
                {
                    Code = ResponseCodes.UnknownError,
                    Message = nameof(ResponseCodes.UnknownError),
                };

            if (response.Data is null)
                return response;

            HttpContext.Session.SetString("User", JsonSerializer.Serialize(response.Data));

            return new EmptyResponse()
            {
                Code = ResponseCodes.Success,
                Message = nameof(ResponseCodes.Success),
            };
        }
    }
}
