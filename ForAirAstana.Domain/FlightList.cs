using ForAirAstana.Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAirAstana.Domain
{
    public class FlightList
    {
        private readonly ILogger<FlightList> _logger;
        private readonly IFlightService _flightService;

        public FlightList(ILogger<FlightList> logger, IFlightService flightService)
        {
            _logger = logger;
            _flightService = flightService;
            
        }

        public Flight GetFlight(int id, User user)
        {
            if(user is null)
                throw new ArgumentNullException(nameof(user));

            return _flightService.GetFlight(id);
        }

        public void AddFlight(Flight flight, User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));
            if(user.IsModerator)
                throw new InvalidOperationException("User is not moderator");

            _flightService.AddFlight(flight);

            _logger.LogInformation($"Flight #{flight.Id} added");
        }

        public void UpdateFlight(Flight flight, User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));
            if (user.IsModerator)
                throw new InvalidOperationException("User is not moderator");

            _flightService.UpdateFlight(flight);

            _logger.LogInformation($"Flight #{flight.Id} updated");
        }
    }
}
