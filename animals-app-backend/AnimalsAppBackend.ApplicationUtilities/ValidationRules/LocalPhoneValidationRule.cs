using System.Text.RegularExpressions;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    class LocalPhoneValidationRule : ValidationRule<string>
    {
        private const string _defaultErrorMessage = "Phone is in the wrong form it must start with 8.";
        private readonly Regex _pattern = new Regex(@"8\d{8}$", RegexOptions.Compiled);

        public LocalPhoneValidationRule(string errorMessage) : base(errorMessage)
        {
        }

        public LocalPhoneValidationRule() : base(_defaultErrorMessage)
        {
        }

        public override bool IsValid(string input)
        {
            return _pattern.IsMatch(input);
        }
    }
}