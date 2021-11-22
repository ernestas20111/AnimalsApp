using AnimalsAppBackend.ApplicationUtilities.ValidationRules;
using AnimalsAppBackend.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationAttributes
{
    public class PhoneValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phone = value as string;

            return new BaseRulesEvaluator<string, ValidationResult>(ValidationResult.Success)
                .AddRule(new EmptyTextInputValidationRule("Phone can not be empty."))
                .AddRule(
                    new OrOperatorRule<string, ValidationResult>
                    (
                        new ValidationResult("Phone is in the wrong form it must start with +370 or 86."),
                        new GlobalPhoneValidationRule(),
                        new LocalPhoneValidationRule()
                    )
                )
                .Evaluate(phone);
        }
    }
}
