using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationAttributes
{
    public class PhoneValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var patternWithPlus = new Regex(@"\+370\d{8}$", RegexOptions.Compiled);
            var patternWithoutPlus = new Regex(@"86\d{7}$", RegexOptions.Compiled);
            var phone = value as string;

            return new BaseRulesEvaluator<ValidationResult, string>(ValidationResult.Success)
                       .AddRule(new EmptyTextInputValidationRule("Phone can not be empty."))
                       .AddRule(new GlobalPhoneValidationRule("Phone is in the wrong form it must start with +370 or 86."))
                       .Evaluate(phone);
        }
    }
}
