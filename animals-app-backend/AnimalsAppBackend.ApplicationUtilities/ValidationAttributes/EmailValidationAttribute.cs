using System.ComponentModel.DataAnnotations;
using AnimalsAppBackend.ApplicationUtilities.ValidationRules;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationAttributes
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var email = value as string;

            return new BaseRulesEvaluator<ValidationResult, string>(ValidationResult.Success)
                .AddRule(new EmptyTextInputValidationRule("Email can not be empty."))
                .AddRule(new EmailValidationRule())
                .Evaluate(email);
        }
    }
}
