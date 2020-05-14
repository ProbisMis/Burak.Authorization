using Burak.Authorization.Models.Requests;
using Burak.Authorization.Utilities.ValidationHelper;
using FluentValidation;
using FluentValidation.Results;

namespace Burak.Authorization.Business.Validators
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        protected override bool PreValidate(ValidationContext<UserRequest> context, ValidationResult result)
           => PreValidations.NotNullPreValidation(context, result);

        public UserRequestValidator()
        {
            RuleFor(r => r.Username).NotNull();
        }
    }
}
