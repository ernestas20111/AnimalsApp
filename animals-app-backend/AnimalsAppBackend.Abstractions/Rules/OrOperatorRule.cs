using System.Collections.Generic;
using System.Linq;

namespace AnimalsAppBackend.Abstractions.Rules
{
    public class OrOperatorRule<T> : IBaseRule<T>
    {
        protected readonly List<IBaseRule<T>> rules;

        public OrOperatorRule(params IBaseRule<T>[] rules)
        {
            this.rules = new List<IBaseRule<T>>(rules);
        }

        public virtual bool IsValid(T input)
        {
            return rules.Any(rule => rule.IsValid(input));
        }
    }
}
