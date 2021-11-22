using System.ComponentModel.DataAnnotations;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    class BadText : IBaseRule<ValidationResult, string>
    {
        private readonly string _errorMessage;

        public BadText(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public BadText()
        {
            _errorMessage = "Input can not be empty.";
        }

        public bool IsValid(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
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
