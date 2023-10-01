using ForAirAstana.Domain;

namespace ForAirAstana.Infrastructure
{
    public class FlightController : IController
    {
        public IResponse<IEnumerable<Flight>> GetFlights()
        {
            throw new System.NotImplementedException();
        }
    }
}