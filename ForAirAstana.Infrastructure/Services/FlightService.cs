using ForAirAstana.Domain;
using ForAirAstana.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAirAstana.Infrastructure.Services
{
    public class FlightService : IFlightService
    {
        public void AddFlight(Flight flight)
        {
            flight.Id = 1;
        }

        public Flight GetFlight(int id)
        {
            return new Flight() { Arrival = DateTime.Now };
        }

        public IEnumerable<Flight> GetFlights()
        {
            return new[] { new Flight() { Arrival = DateTime.Now } };
        }

        public void UpdateFlight(Flight flight)
        {

        }
    }
}
