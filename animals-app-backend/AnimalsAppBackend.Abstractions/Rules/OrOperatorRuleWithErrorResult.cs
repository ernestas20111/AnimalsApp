namespace AnimalsAppBackend.Abstractions.Rules
{
    public class OrOperatorRuleWithErrorResult<T, TResult> : IValidationRule<T, TResult>, OrOperatorRule<T>
    {
        private readonly TResult _defaultErrorResult;

        public OrOperatorRuleWithErrorResult(TResult defaultErrorResult, params IValidationRule<T, TResult>[] rules) : base(rules)
        {
            _defaultErrorResult = defaultErrorResult;
        }

        public override TResult Validate(T input)
        {
            if (IsValid(input))
            {
                return _rules.FirstOrDefault(rule => rule.IsValid(input)).Validate(input);
            }
            return _defaultErrorResult;
        }
    }
}
