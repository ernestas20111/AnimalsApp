using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    class GlobalPhoneValidationRule : IBaseRule<ValidationResult, string>
    {
        private readonly string _errorMessage;

        public GlobalPhoneValidationRule(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public GlobalPhoneValidationRule()
        {
            _errorMessage = "Phone is in the wrong form it must start with +370 or 86.";
        }

        public bool IsValid(string input)
        {
            var patternWithPlus = new Regex(@"\+370\d{8}$", RegexOptions.Compiled);
            var patternWithoutPlus = new Regex(@"86\d{7}$", RegexOptions.Compiled);

            if (patternWithPlus.IsMatch(input) || patternWithoutPlus.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        public ValidationResult Validate(string input)
        {
            if (IsValid(input))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(_errorMessage);
        }
    }
}
