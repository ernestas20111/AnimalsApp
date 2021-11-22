using System.ComponentModel.DataAnnotations;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    class EmptyTextInputValidationRule : ValidationRule<string>
    {
        private const string _defaultErrorMessage = "Input can not be empty.";
        
        public EmptyTextInputValidationRule(string errorMessage) : base(errorMessage)
        {
        }

        public EmptyTextInputValidationRule() : base(_defaultErrorMessage)
        {
        }

        public bool IsValid(string input)
        {
            return IsValid(input, (input) => !string.IsNullOrWhiteSpace(input));
        }
    }
}
