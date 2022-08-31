using FluentValidation;
using Livraria.API.Models;

namespace Livraria.API.Validator
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.Id)
                .Empty()
                .WithMessage("Id must be empty.");

            RuleFor(b => b.Name)
                .NotEmpty()
                .WithMessage("Empty name.")
                .MinimumLength(3)
                .WithMessage("Minimum 3.")
                .MaximumLength(120)
                .WithMessage("Maximum 35."); 

            RuleFor(b => b.Author)
                .NotEmpty()
                .WithMessage("Empty name.")
                .MinimumLength(3)
                .WithMessage("Minimum 3.")
                .MaximumLength(35)
                .WithMessage("Maximum 35.");

            RuleFor(b => b.PublisherId)
                .NotNull()
                .WithMessage("Null Publisher Id")
                .GreaterThan(0)
                .WithMessage("Minimum 1.");


            RuleFor(b => b.Quantity)
                .NotNull()
                .WithMessage("Null quantity.")
                .GreaterThan(0)
                .WithMessage("Minimum 1.");

            RuleFor(b => b.Launch)
                .NotEmpty()
                .WithMessage("Empty launch.");

        }
    }
}
