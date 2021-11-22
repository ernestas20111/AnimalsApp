using System.ComponentModel.DataAnnotations;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    class EmptyTextInputValidationRule : IBaseRule<ValidationResult, string>, ValidationRule<string>
    {
        public EmptyTextInputValidationRule(string errorMessage) : base(errorMessage)
        {
        }

        public EmptyTextInputValidationRule() : base("Input can not be empty.")
        {
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
