namespace AnimalsAppBackend.Abstractions.Rules
{
    public class OrOperatorRuleWithErrorResult<T, TResult> : OrOperatorRule<T, TResult>
    {
        private readonly TResult _defaultErrorResult;

        public OrOperatorRuleWithErrorResult(TResult defaultErrorResult, params IBaseRule<T, TResult>[] rules) : base(rules)
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