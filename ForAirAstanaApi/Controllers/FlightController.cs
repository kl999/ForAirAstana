using ForAirAstana.Domain;
using ForAirAstana.Infrastructure;
using ForAirAstana.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ForAirAstanaApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FlightController : ControllerBase
    {
        private readonly ILogger<FlightController> _logger;
        private readonly C3Controller<ForAirAstana.Infrastructure.Controllers.FlightController> _controller;

        public FlightController(
            ILogger<FlightController> logger,
            C3Controller<ForAirAstana.Infrastructure.Controllers.FlightController> controller)
        {
            _logger = logger;
            _controller = controller;
        }

        [HttpGet(Name = "GetList")]
        public IResponse GetList()
        {
            string? userJson = HttpContext.Session.GetString("User");

            var user = userJson is null ? null : JsonSerializer.Deserialize<User>(userJson);

            return _controller.Invoke(ctrl => ctrl.GetFlights(user));
        }

        [HttpPost(Name = "Add")]
        public IResponse Add(AddFlightRequest request)
        {
            string? userJson = HttpContext.Session.GetString("User");

            var user = userJson is null ? null : JsonSerializer.Deserialize<User>(userJson);

            return _controller.Invoke(ctrl => ctrl.AddFlight(request, user));
        }

        [HttpPost(Name = "Update")]
        public IResponse Update(UpdateFlightRequest request)
        {
            string? userJson = HttpContext.Session.GetString("User");

            var user = userJson is null ? null : JsonSerializer.Deserialize<User>(userJson);

            return _controller.Invoke(ctrl => ctrl.UpdateFlight(request, user));
        }
    }
}
