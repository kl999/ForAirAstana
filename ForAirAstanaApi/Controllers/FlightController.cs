﻿using ForAirAstana.Domain;
using ForAirAstana.Infrastructure;
using ForAirAstana.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForAirAstanaApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FlightController
    {
        private readonly ILogger<FlightController> _logger;
        private readonly C3Controller<ForAirAstana.Infrastructure.Controllers.FlightController> _controller;

        private User? _user;

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
            return _controller.Invoke(ctrl => ctrl.GetFlights());
        }

        [HttpPost(Name = "Add")]
        public IResponse Add(AddFlightRequest request)
        {
            return _controller.Invoke(ctrl => ctrl.AddFlight(request, _user));
        }

        [HttpPost(Name = "Update")]
        public IResponse Update(UpdateFlightRequest request)
        {
            return _controller.Invoke(ctrl => ctrl.UpdateFlight(request));
        }
    }
}
