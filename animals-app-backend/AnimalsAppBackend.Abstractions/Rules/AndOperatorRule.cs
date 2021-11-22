using System.Collections.Generic;
using System.Linq;

namespace AnimalsAppBackend.Abstractions.Rules
{
    public class AndOperatorRule<T, TResult> : IValidationRule<T, TResult>
    {
        private readonly List<IValidationRule<T, TResult>> _rules;

        public AndOperatorRule(params IValidationRule<T, TResult>[] rules)
        {
            _rules = new List<IValidationRule<T, TResult>>(rules);
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
