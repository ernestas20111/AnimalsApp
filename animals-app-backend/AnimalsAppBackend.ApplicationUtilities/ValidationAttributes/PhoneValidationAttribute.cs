using AnimalsAppBackend.Abstractions.Rules;
using AnimalsAppBackend.ApplicationUtilities.ValidationRules;
using System.ComponentModel.DataAnnotations;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationAttributes
{
    public class PhoneValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phone = value as string;

            return new BaseRulesEvaluator<string, ValidationResult>()
                .OuterAnd(new EmptyTextInputValidationRule("Phone can not be empty."))
                .InnerOr(
                    new GlobalPhoneValidationRule(),
                    new LocalPhoneValidationRule()
                )
                .Evaluate(phone);
        }
    }
}
