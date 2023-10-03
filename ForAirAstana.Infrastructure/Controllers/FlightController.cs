using FluentValidation;
using ForAirAstana.Domain;
using ForAirAstana.Infrastructure.Models;
using ForAirAstana.Infrastructure.Services;
using System.Diagnostics;

namespace ForAirAstana.Infrastructure.Controllers
{
    public class FlightController : IController
    {
        private readonly FlightList _flightList;

        public FlightController(FlightList flightList)
        {
            _flightList = flightList;
        }

        public IResponse GetFlights(User? user, int order)
        {
            if (user is null)
                return new EmptyResponse()
                {
                    Code = ResponseCodes.AccessError,
                    Message = $"{nameof(ResponseCodes.AccessError)}",
                };

            return new Response<IEnumerable<Flight>>
            {
                Code = ResponseCodes.Success,
                Message = "Success",
                Data = _flightList.GetFlightList(user, (FlightListOrder)order),
            };
        }

        public IResponse AddFlight(AddFlightRequest request, User? user)
        {
            if (user is null)
                return new EmptyResponse()
                {
                    Code = ResponseCodes.AccessError,
                    Message = $"{nameof(ResponseCodes.AccessError)}",
                };

            var validator = new AddFlightRequestValidator();

            var validResult = validator.Validate(request);

            if (!validResult.IsValid)
                return new EmptyResponse()
                {
                    Code = ResponseCodes.ValidationError,
                    Message = $"{nameof(ResponseCodes.ValidationError)}: {validResult}",
                };

            var flight = new Flight
            {
                Origin = request.Origin,
                Destination = request.Destination,
                Departure = request.Departure,
                Arrival = request.Arrival,
                Status = (Status)request.Status,
            };

            _flightList.AddFlight(flight, user);

            return new Response<int>()
            {
                Code = ResponseCodes.Success,
                Message = $"{nameof(ResponseCodes.Success)}",
                Data = flight.Id,
            };
        }

        public IResponse UpdateFlight(UpdateFlightRequest request, User? user)
        {
            if (user is null)
                return new EmptyResponse()
                {
                    Code = ResponseCodes.AccessError,
                    Message = $"{nameof(ResponseCodes.AccessError)}",
                };

            var validator = new UpdateFlightRequestValidator();

            var validResult = validator.Validate(request);

            if (!validResult.IsValid)
                return new EmptyResponse()
                {
                    Code = ResponseCodes.ValidationError,
                    Message = $"{nameof(ResponseCodes.ValidationError)}: {validResult}",
                };

            var flight = new Flight
            {
                Id = request.Id,
                Origin = request.Origin,
                Destination = request.Destination,
                Departure = request.Departure,
                Arrival = request.Arrival,
                Status = (Status)request.Status,
            };

            _flightList.UpdateFlight(flight, user);

            return new EmptyResponse()
            {
                Code = ResponseCodes.Success,
                Message = $"{nameof(ResponseCodes.Success)}",
            };
        }
    }
}