namespace AnimalsAppBackend.Abstractions.Rules
{
    public class OrOperatorRuleWithErrorResult<T, TResult> : OrOperatorRule<T>, IValidationRule<T, TResult>
    {
        private readonly List<IValidationRule<T, TResult>> _rules;

        private readonly TResult _defaultErrorResult;

        public OrOperatorRuleWithErrorResult(TResult defaultErrorResult, params IValidationRule<T, TResult>[] rules) : base(rules)
        {
            _rules = rules;
            _defaultErrorResult = defaultErrorResult;
        }

        public virtual TResult Validate(T input)
        {
            if (IsValid(input))
            {
                return _rules.FirstOrDefault(rule => rule.IsValid(input)).Validate(input);
            }
            return _defaultErrorResult;
        }
    }
}
