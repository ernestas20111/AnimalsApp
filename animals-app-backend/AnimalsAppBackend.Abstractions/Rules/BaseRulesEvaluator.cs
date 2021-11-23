using System.Collections.Generic;
using System.Linq;

namespace AnimalsAppBackend.Abstractions.Rules
{
    public class BaseRulesEvaluator<T, TResult>
    {
        private readonly List<IBaseRule<T, TResult>> _rules;

        public BaseRulesEvaluator()
        {
            _rules = new List<IBaseRule<T, TResult>>();
        }

        public virtual BaseRulesEvaluator<T, TResult> OuterAnd(params IBaseRule<T, TResult>[] rules)
        {
            _rules.Add(new AndOperatorRule<T, TResult>(rules));
            return this;
        }

        public virtual BaseRulesEvaluator<T, TResult> InnerOr(params IBaseRule<T, TResult>[] rules)
        {
            _rules.Add(new OrOperatorRule<T, TResult>(rules));
            return this;
        }


        public virtual TResult Evaluate(T input)
        {
            return new AndOperatorRule<T, TResult>(_rules.ToArray()).Validate(input);
        }
    }
}