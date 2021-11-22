using System.ComponentModel.DataAnnotations;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    class EmptyTextInputValidationRule : ValidationRule<string>
    {
        public EmptyTextInputValidationRule(string errorMessage) : base(errorMessage)
        {
        }

        public EmptyTextInputValidationRule() : base("Input can not be empty.")
        {
        }

        public bool IsValid(string input)
        {
            return IsValid(input, (input) => !string.IsNullOrWhiteSpace(input));
        }
    }
}
