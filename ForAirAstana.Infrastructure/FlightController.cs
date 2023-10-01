using ForAirAstana.Domain;

namespace ForAirAstana.Infrastructure
{
    public class FlightController : IController
    {
        public IResponse<IEnumerable<Flight>> GetFlights()
        {
            return new Response<IEnumerable<Flight>>
            {
                Code = ResponseCodes.Success,
                Message = "Success",
                Data = new Flight[]
                {
                    new Flight
                    {
                        Id = 1,
                        Arrival = DateTime.Now,
                    },
                    new Flight
                    {
                        Id = 2,
                        Arrival = DateTime.Now.AddDays(1),
                    },
                    new Flight
                    {
                        Id = 3,
                        Arrival = DateTime.Now.AddDays(2),
                    },
                }
            };
        }
    }
}