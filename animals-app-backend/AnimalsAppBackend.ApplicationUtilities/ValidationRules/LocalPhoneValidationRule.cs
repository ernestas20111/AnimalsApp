using System.Text.RegularExpressions;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    class LocalPhoneValidationRule : ValidationRule<string>
    {
        private const string _defaultErrorMessage = "Phone is in the wrong form it must start with 86.";

        public LocalPhoneValidationRule(string errorMessage) : base(errorMessage)
        {
        }

        public LocalPhoneValidationRule() : base(_defaultErrorMessage)
        {
        }

        public override bool IsValid(string input)
        {
            var pattern = new Regex(@"86\d{7}$", RegexOptions.Compiled);
            return pattern.IsMatch(input);
        }
    }
}