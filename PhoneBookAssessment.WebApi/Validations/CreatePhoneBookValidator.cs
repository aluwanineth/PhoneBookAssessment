using FluentValidation;
using PhoneBookAssessment.WebApi.Models.PhoneBook;


namespace PhoneBookAssessment.WebApi.Validations
{
    public class CreatePhoneBookValidator : AbstractValidator<CreatePhoneBookRequest>
    {
        public CreatePhoneBookValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
