using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    class EmailValidationRule : IBaseRule<ValidationResult, string>
    {
        private readonly string _errorMessage;

        public EmailValidationRule(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public EmailValidationRule()
        {
            _errorMessage = "Email is in the wrong form.";
        }

        public bool IsValid(string input)
        {
            var pattern = new Regex(@"([a-zA-Z0-9._-]*[a-zA-Z0-9][a-zA-Z0-9._-]*)(@gmail.com)$", RegexOptions.Compiled);

            if (pattern.IsMatch(input))
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
