using ForAirAstana.Domain;
using ForAirAstanaApi.Models;
using System.Diagnostics;

namespace ForAirAstana.Infrastructure.Controllers
{
    public class FlightController : IController
    {
        public IResponse AddFlight(FlightRequest request)
        {
            var validator = new FlightRequestValidator();

            var validResult = validator.Validate(request);

            if (!validResult.IsValid)
            {
                return new EmptyResponse()
                {
                    Code = ResponseCodes.ValidationError,
                    Message = $"{nameof(ResponseCodes.ValidationError)}: {validResult}",
                };
            }

            Trace.WriteLine($"+++> FlightController.AddFlight: {request}");

            return new Response<int>()
            {
                Code = ResponseCodes.Success,
                Message = $"{nameof(ResponseCodes.Success)}",
                Data = Random.Shared.Next(1_000_000),
            };
        }

        public IResponse GetFlights()
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