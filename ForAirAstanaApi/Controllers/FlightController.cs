using ForAirAstana.Domain;
using ForAirAstana.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ForAirAstanaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController
    {
        private readonly ILogger<FlightController> _logger;
        private readonly C3Controller<ForAirAstana.Infrastructure.FlightController> _controller;

        private User? _user;

        public FlightController(
            ILogger<FlightController> logger,
            C3Controller<ForAirAstana.Infrastructure.FlightController> controller)
        {
            _logger = logger;
            _controller = controller;
        }

        [HttpGet(Name = "GetFlights")]
        public IResponse Get()
        {
            return _controller.Invoke(ctrl => ctrl.GetFlights());
        }
    }
}
