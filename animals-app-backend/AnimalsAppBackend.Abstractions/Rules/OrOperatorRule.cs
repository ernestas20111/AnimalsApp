using System.Collections.Generic;
using System.Linq;

´╗┐namespace AnimalsAppBackend.Abstractions.Rules
{
    public class OrOperatorRule<T, TResult> : IBaseRule<T, TResult>
    {
        private readonly TResult _defaultErrorResult;
        private readonly List<IBaseRule<T, TResult>> _rules;

        public OrOperatorRule(TResult defaultErrorResult, params IBaseRule<T, TResult>[] rules)
        {
            _defaultErrorResult = defaultErrorResult;
            _rules = new List<IBaseRule<T, TResult>>(rules);
        }

        public virtual bool IsValid(T input)
        {
            return _rules.Any(rule => rule.IsValid(input));
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
