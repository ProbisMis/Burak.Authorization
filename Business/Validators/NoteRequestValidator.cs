using FluentValidation;
using FluentValidation.Results;
using Burak.Authorization.Models.Requests;
using Burak.Authorization.Utilities.ValidationHelper;

namespace Burak.Authorization.Business.Validators
{
    public class NoteRequestValidator : AbstractValidator<BaseCollectionRequest>

    {
        protected override bool PreValidate(ValidationContext<BaseCollectionRequest> context, ValidationResult result)
           => PreValidations.NotNullPreValidation(context, result);

        public NoteRequestValidator()
        {
            RuleFor(r => r.PageSize).NotNull();
        }
    }
}
