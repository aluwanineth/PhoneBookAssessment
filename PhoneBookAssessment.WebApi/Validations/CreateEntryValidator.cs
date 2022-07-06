using FluentValidation;
using PhoneBookAssessment.WebApi.Models.Entry;

namespace PhoneBookAssessment.WebApi.Validations
{
    public class CreateEntryValidator : AbstractValidator<CreateEntryRequest>
    {
        public CreateEntryValidator()
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 10 characters.");
            RuleFor(x => x.PhoneBookId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();      
        }
    }
}
