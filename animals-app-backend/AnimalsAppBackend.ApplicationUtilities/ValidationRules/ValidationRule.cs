using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    class ValidationRule<T> : IBaseRule<ValidationResult, T>
    {
        private readonly string _errorMessage;

        public ValidationRule(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        sealed public bool IsValid(T input, Func<T, bool> condition)
        {
            if (condition)
            {
                return true;
            }
            return false;
        }

        public virtual ValidationResult Validate(T input)
        {
            if (IsValid(input))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(_errorMessage);
        }
    }
}
