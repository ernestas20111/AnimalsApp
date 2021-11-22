using System.Collections.Generic;
using System.Linq;

namespace AnimalsAppBackend.Abstractions.Rules
{
    public class OrOperatorRule<T, TResult> : IBaseRule<T, TResult>
    {
        private readonly List<IBaseRule<T, TResult>> _rules;

        public OrOperatorRule(params IBaseRule<T, TResult>[] rules)
        {
            _rules = new List<IBaseRule<T, TResult>>(rules);
        }

        public virtual bool IsValid(T input)
        {
            return _rules.Any(rule => rule.IsValid(input));
        }
    }
}
