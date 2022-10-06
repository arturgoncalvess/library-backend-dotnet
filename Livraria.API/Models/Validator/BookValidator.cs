using FluentValidation;
using Livraria.API.Dtos.Books;

namespace Livraria.API.Validator
{
    public class BookValidator : AbstractValidator<BookRequestDto>
    {
        public BookValidator()
        {
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
                .WithMessage("Null Publisher Id.")
                .GreaterThan(0)
                .WithMessage("It has to be an existing Book Id.");


            RuleFor(b => b.Quantity)
                .NotNull()
                .WithMessage("Null quantity.")
                .GreaterThan(-1)
                .WithMessage("Minimum 0.");

            RuleFor(b => b.Launch)
                .NotEmpty()
                .WithMessage("Empty launch.");

        }
    }
}
