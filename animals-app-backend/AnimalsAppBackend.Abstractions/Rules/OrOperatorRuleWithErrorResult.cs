namespace AnimalsAppBackend.Abstractions.Rules
{
    public class OrOperatorRuleWithErrorResult<T, TResult> : OrOperatorRule<T>, IValidationRule<T, TResult>
    {
        private readonly TResult _defaultErrorResult;

        public OrOperatorRuleWithErrorResult(TResult defaultErrorResult, params IValidationRule<T, TResult>[] rules) : base(rules)
        {
            _defaultErrorResult = defaultErrorResult;
        }

        public virtual TResult Validate(T input)
        {
            if (IsValid(input))
            {
                return rules.FirstOrDefault(rule => rule.IsValid(input)).Validate(input);
            }
            return _defaultErrorResult;
        }
    }
}
