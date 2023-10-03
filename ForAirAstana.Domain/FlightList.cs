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

        public Flight? GetFlight(int id, User user)
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

            _logger.LogInformation($"Flight #{flight.Id} added. User {user.Id}");
        }

        public void UpdateFlight(Flight flight, User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));
            if (user.IsModerator)
                throw new InvalidOperationException("User is not moderator");

            _flightService.UpdateFlight(flight);

            _logger.LogInformation($"Flight #{flight.Id} updated. User {user.Id}");
        }

        public IEnumerable<Flight> GetFlightList(User user, FlightListOrder flightListOrder = FlightListOrder.Arival)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            var flights = _flightService.GetFlights();

            switch (flightListOrder)
            {
                case FlightListOrder.Arival:
                    flights = flights.OrderBy(f => f.Arrival);
                    break;
                case FlightListOrder.Destination:
                    flights = flights.OrderBy(f => f.Destination);
                    break;
                case FlightListOrder.Origin:
                    flights = flights.OrderBy(f => f.Origin);
                    break;
                default:
                    throw new InvalidOperationException("Invalid flight list order");
            }

            return flights;
        }
    }
}
