using AnimalsAppBackend.ApplicationUtilities.ValidationRules;
using System.ComponentModel.DataAnnotations;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationAttributes
{
    public class PhoneValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phone = value as string;

            return new BaseRulesEvaluator<ValidationResult, string>(ValidationResult.Success)
                .AddRule(new EmptyTextInputValidationRule("Phone can not be empty."))
                .AddRule(new GlobalPhoneValidationRule())
                .Evaluate(phone);
        }
    }
}
