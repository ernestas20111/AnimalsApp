using System.Collections.Generic;
using System.Linq;

namespace AnimalsAppBackend.Abstractions.Rules
{
    public class AndOperatorRule<T> : IBaseRule<T>
    {
        private readonly List<IBaseRule<T>> _rules;

        public AndOperatorRule(params IBaseRule<T>[] rules)
        {
            _rules = new List<IBaseRule<T>>(rules);
        }

        public virtual bool IsValid(T input)
        {
            return _rules.All(rule => rule.IsValid(input));
        }
    }
}
