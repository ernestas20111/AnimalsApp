using System.Collections.Generic;
using System.Linq;

namespace AnimalsAppBackend.Abstractions.Rules
{
    public class AndOperatorRule<T> : IBaseRule<T>
    {
        protected readonly List<IBaseRule<T>> rules;

        public AndOperatorRule(params IBaseRule<T>[] rules)
        {
            this.rules = new List<IBaseRule<T>>(rules);
        }

        public virtual bool IsValid(T input)
        {
            return rules.All(rule => rule.IsValid(input));
        }
    }
}
