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

        public override bool IsValid(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            return false;
        }
    }
}
