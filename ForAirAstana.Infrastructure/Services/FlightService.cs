using ForAirAstana.Database;
using ForAirAstana.Database.Entities;
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
        private readonly AirAstanaDbContext _dbContext;
        private readonly FlightCache _flightCache;

        public FlightService(AirAstanaDbContext dbContext, FlightCache flightCache)
        {
            _dbContext = dbContext;
            _flightCache = flightCache;
        }

        public void AddFlight(Domain.Flight flight)
        {
            var flightDb = new Database.Entities.Flight()
            {
                Arrival = flight.Arrival,
                Origin = flight.Origin,
                Destination = flight.Destination,
                Departure = flight.Departure,
                Status = (int)flight.Status
            };

            _dbContext.Flights.Add(flightDb);

            _dbContext.SaveChanges();

            _flightCache.AddFlight(flight);

            flight.Id = flightDb.Id;
        }

        public Domain.Flight? GetFlight(int id)
        {
            if(!_flightCache.IsExpired)
                return _flightCache.GetFlight(id);

            var dbFlight = _dbContext.Flights.FirstOrDefault(i => i.Id == id);

            if(dbFlight is null)
                return null;

            return new Domain.Flight()
            {
                Id = dbFlight.Id,
                Arrival = dbFlight.Arrival,
                Origin = dbFlight.Origin,
                Destination = dbFlight.Destination,
                Departure = dbFlight.Departure,
                Status = (Status)dbFlight.Status
            };
        }

        public IEnumerable<Domain.Flight> GetFlights()
        {
            var result = new List<Domain.Flight>();

            if (!_flightCache.IsExpired)
                return _flightCache.GetFlights();
            else
            {
                foreach (var flight in _dbContext.Flights)
                {
                    result.Add(new Domain.Flight()
                    {
                        Id = flight.Id,
                        Arrival = flight.Arrival,
                        Origin = flight.Origin,
                        Destination = flight.Destination,
                        Departure = flight.Departure,
                        Status = (Status)flight.Status
                    });
                }

                _flightCache.SetFlights(result);
            }

            return result;
        }

        public void UpdateFlight(Domain.Flight flight)
        {
            var flightDb = _dbContext.Flights.FirstOrDefault(i => i.Id == flight.Id);

            if (flightDb is null)
                return;

            flightDb.Arrival = flight.Arrival;
            flightDb.Origin = flight.Origin;
            flightDb.Destination = flight.Destination;
            flightDb.Departure = flight.Departure;
            flightDb.Status = (int)flight.Status;

            _dbContext.SaveChanges();

            _flightCache.UpdateFlight(flight);
        }
    }
}
