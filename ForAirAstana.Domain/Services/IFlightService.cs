using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAirAstana.Domain.Services
{
    public interface IFlightService
    {
        void AddFlight(Flight flight);
        Flight GetFlight(int id);
        void UpdateFlight(Flight flight);
    }
}
