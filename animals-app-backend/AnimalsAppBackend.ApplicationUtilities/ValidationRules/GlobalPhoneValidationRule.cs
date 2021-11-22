using System.Text.RegularExpressions;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    class GlobalPhoneValidationRule : ValidationRule<string>
    {
        private const string _defaultErrorMessage = "Phone is in the wrong form it must start with +370.";

        public GlobalPhoneValidationRule(string errorMessage) : base(errorMessage)
        {
        }

        public GlobalPhoneValidationRule() : base(_defaultErrorMessage)
        {
        }

        public override bool IsValid(string input)
        {
            var pattern = new Regex(@"\+370\d{8}$", RegexOptions.Compiled);
            return pattern.IsMatch(input);
        }
    }
}