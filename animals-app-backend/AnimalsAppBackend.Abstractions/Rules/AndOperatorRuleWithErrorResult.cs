namespace AnimalsAppBackend.Abstractions.Rules
{
    public class AndOperatorRuleWithErrorResult<T, TResult> : AndOperatorRule<T, TResult>
    {
        private readonly TResult _defaultErrorResult;

        public AndOperatorRuleWithErrorResult(TResult defaultErrorResult, params IValidationRule<T, TResult>[] rules) : base(rules)
        {
            _defaultErrorResult = defaultErrorResult;
        }

        public override TResult Validate(T input)
        {
            if (IsValid(input))
            {
                return base.Validate(input);
            }
            return _defaultErrorResult;
        }
    }
}
