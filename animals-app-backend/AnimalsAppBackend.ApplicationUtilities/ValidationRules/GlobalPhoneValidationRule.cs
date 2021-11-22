using System.Text.RegularExpressions;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationRules
{
    class GlobalPhoneValidationRule : ValidationRule<string>
    {
        private const string _defaultErrorMessage = "Phone is in the wrong form it must start with +370 or 86.";

        public GlobalPhoneValidationRule(string errorMessage) : base(errorMessage)
        {
        }

        public GlobalPhoneValidationRule() : base(_defaultErrorMessage)
        {
        }

        public override bool IsValid(string input)
        {
            var patternWithPlus = new Regex(@"\+370\d{8}$", RegexOptions.Compiled);
            var patternWithoutPlus = new Regex(@"86\d{7}$", RegexOptions.Compiled);

            if (patternWithPlus.IsMatch(input) || patternWithoutPlus.IsMatch(input))
            {
                return true;
            }
            return false;
        }
    }
}