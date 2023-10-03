using ForAirAstana.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAirAstana.Infrastructure.Services
{
    public class FlightCache
    {
        private readonly Dictionary<int, Flight> _flights = new Dictionary<int, Flight>();
        private DateTime _lastUpdate = DateTime.MinValue;

        public bool IsExpired => DateTime.Now - _lastUpdate > TimeSpan.FromMinutes(30);

        public void SetFlights(IEnumerable<Flight> flights)
        {
            _flights.Clear();

            foreach (var flight in flights)
                _flights.Add(flight.Id, flight);

            _lastUpdate = DateTime.Now;
        }

        public void AddFlight(Flight flight)
        {
            _flights.Add(flight.Id, flight);
        }

        public Flight? GetFlight(int id)
        {
            if (_flights.ContainsKey(id))
                return _flights[id];

            return null;
        }

        public void UpdateFlight(Flight flight)
        {
            if (_flights.ContainsKey(flight.Id))
                _flights[flight.Id] = flight;
        }

        public IEnumerable<Flight> GetFlights()
        {
            return _flights.Values;
        }
    }
}
