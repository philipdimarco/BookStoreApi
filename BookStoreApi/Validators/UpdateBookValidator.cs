using BookStoreApi.Models;
using FluentValidation;

namespace BookStoreApi.Validators
{
    public class UpdateBookValidator : AbstractValidator<BookDto>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.AuthorId)
                .NotNull()
                .WithMessage("AuthorId is required")
                .NotEqual(Guid.Empty)
                .WithMessage("Invalid AuthorId");
            RuleFor(x => x.Title)
                .NotNull()
                .WithMessage("Title is required")
                .NotEmpty()
                .WithMessage("Title must not be blank");
            RuleFor(x => x.Description)
                .NotNull()
                .WithMessage("Description is required")
                .NotEmpty()
                .WithMessage("Description must not be blank");
            RuleFor(x => x.Price)
                .NotNull()
                .WithMessage("Price is required")
                .ScalePrecision(2, 5, false)
                .GreaterThan(00.00m)
                .WithMessage("Price must be greater than zero");

        }

    }
}
