using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAirAstana.Infrastructure.Models
{
    public class UpdateFlightRequest
    {
        public int Id { get; set; }
        public string Origin { get; set; } = String.Empty;
        public string Destination { get; set; } = String.Empty;
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int Status { get; set; }
    }

    public class UpdateFlightRequestValidator : AbstractValidator<UpdateFlightRequest>
    {
        public UpdateFlightRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(x => x.Origin).NotEmpty().WithMessage("Origin is required");
            RuleFor(x => x.Destination).NotEmpty().WithMessage("Destination is required");
            RuleFor(x => x.Departure).NotEmpty().WithMessage("Departure is required");
            RuleFor(x => x.Arrival).NotEmpty().WithMessage("Arrival is required");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Status is required");
        }
    }
}
