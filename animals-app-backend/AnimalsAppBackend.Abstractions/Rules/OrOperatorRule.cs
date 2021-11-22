using System.Collections.Generic;
using System.Linq;

namespace AnimalsAppBackend.Abstractions.Rules
{
    public class OrOperatorRule<T> : IBaseRule<T>
    {
        private readonly List<IBaseRule<T>> _rules;

        public OrOperatorRule(params IBaseRule<T>[] rules)
        {
            _rules = new List<IBaseRule<T>>(rules);
        }

        public virtual bool IsValid(T input)
        {
            return _rules.Any(rule => rule.IsValid(input));
        }
    }
}
