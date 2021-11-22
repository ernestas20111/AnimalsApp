using System.Text.RegularExpressions;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    class EmailValidationRule : ValidationRule<string>
    {
        private const string _defaultErrorMessage = "Email is in the wrong form.";

        public EmailValidationRule(string errorMessage) : base(errorMessage)
        {
        }

        public EmailValidationRule() : base(_defaultErrorMessage)
        {
        }

        public override bool IsValid(string input)
        {
            var pattern = new Regex(@"([a-zA-Z0-9._-]*[a-zA-Z0-9][a-zA-Z0-9._-]*)(@gmail.com)$", RegexOptions.Compiled);

            return pattern.IsMatch(input);
        }
    }
}
