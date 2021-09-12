using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AnimalsAppBackend.ApplicationUtilities.Validators
{
    public class PhoneValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var patternWithPlus = new Regex(@"\+370\d{8}$", RegexOptions.Compiled);
            var patternWithoutPlus = new Regex(@"86\d{7}$", RegexOptions.Compiled);
            var phone = value as string;

            if (string.IsNullOrWhiteSpace(phone))
            {
                return new ValidationResult("Phone can not be empty.");
            }
            else if (!patternWithPlus.IsMatch(phone) & !patternWithoutPlus.IsMatch(phone))
            {
                return new ValidationResult("Phone is in the wrong form it must start with +370 or 86.");
            }
            else return ValidationResult.Success;
        }
    }
}
