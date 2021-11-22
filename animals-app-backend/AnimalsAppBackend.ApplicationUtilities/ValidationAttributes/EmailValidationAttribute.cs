using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using AnimalsAppBackend.ApplicationUtilities;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationAttributes
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var pattern = new Regex(@"([a-zA-Z0-9._-]*[a-zA-Z0-9][a-zA-Z0-9._-]*)(@gmail.com)$", RegexOptions.Compiled);

            var email = value as string;
            
            return new BaseRulesEvaluator<ValidationResult, string>(ValidationResult.Success)
                       .AddRule(new EmptyTextInputValidationRule("Email can not be empty."))
                       .AddRule(new EmailValidationAttribute("Email is in the wrong form."))
                       .Evaluate(email);
                                           
        }
    }
}
