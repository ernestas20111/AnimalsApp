using System.Collections.Generic;
using System.Linq;

namespace AnimalsAppBackend.Abstractions.Rules
{
    public class AndOperatorRule<T, TResult> : IValidationRule<T, TResult>
    {
        private readonly List<IBaseRule<T, TResult>> _rules;

        public AndOperatorRule(params IBaseRule<T, TResult>[] rules)
        {
            _rules = new List<IBaseRule<T, TResult>>(rules);
        }

        public virtual bool IsValid(T input)
        {
            return _rules.All(rule => rule.IsValid(input));
        }

        public virtual TResult Validate(T input)
        {
            if (IsValid(input))
            {
                return _rules.FirstOrDefault().Validate(input);
            }
            return _rules.FirstOrDefault(rule => !rule.IsValid(input)).Validate(input);
        }
    }
}
