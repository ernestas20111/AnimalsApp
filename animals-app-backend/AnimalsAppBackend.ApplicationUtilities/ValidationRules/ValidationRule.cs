using AnimalsAppBackend.Abstractions.Rules;
using System.ComponentModel.DataAnnotations;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    abstract class ValidationRule<T> : IValidationRule<T, ValidationResult>
    {
        private readonly string _errorMessage;

        public ValidationRule(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public abstract bool IsValid(T input);

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
