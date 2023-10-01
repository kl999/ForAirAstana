using FluentValidation;
using ForAirAstana.Domain;
using System.ComponentModel.DataAnnotations;

namespace ForAirAstanaApi.Models
{
    public class FlightRequest
    {
        public string Origin { get; set; } = String.Empty;
        public string Destination { get; set; } = String.Empty;
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int Status { get; set; }
    }

    public class FlightRequestValidator : AbstractValidator<FlightRequest>
    {
        public FlightRequestValidator()
        {
            RuleFor(x => x.Origin).NotEmpty().WithMessage("Origin is required");
            RuleFor(x => x.Destination).NotEmpty().WithMessage("Destination is required");
            RuleFor(x => x.Departure).NotEmpty().WithMessage("Departure is required");
            RuleFor(x => x.Arrival).NotEmpty().WithMessage("Arrival is required");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is required");
        }
    }
}
