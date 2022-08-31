using FluentValidation;
using Livraria.API.Models;

namespace Livraria.API.Validator
{
    public class PublisherValidator : AbstractValidator<Publisher>
    {
        public PublisherValidator()
        {
            RuleFor(p => p.Id)
                .Empty()
                .WithMessage("Id must be empty.");

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Empty name.")
                .MinimumLength(3)
                .WithMessage("Minimum 3.")
                .MaximumLength(35)
                .WithMessage("Maximum 35.");

            RuleFor(p => p.City)
                .NotEmpty()
                .WithMessage("Empty name.")
                .MinimumLength(3)
                .WithMessage("Minimum 3.")
                .MaximumLength(35)
                .WithMessage("Maximum 35.");
        }
    }
}
