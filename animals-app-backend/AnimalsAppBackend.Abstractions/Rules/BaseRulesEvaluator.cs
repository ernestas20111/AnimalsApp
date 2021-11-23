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

        public virtual BaseRulesEvaluator<T, TResult> AddRule(IBaseRule<T, TResult> rule)
        {
            _rules.Add(rule);
            return this;
        }

        public virtual BaseRulesEvaluator<T, TResult> AddRulesWithOrOperator(TResult defaultErrorResult, params IBaseRule<T, TResult>[] rules)
        {
            _rules.Add(new OrOperatorRule<T, TResult>(defaultErrorResult, rules));
            return this;
        }


        public virtual TResult Evaluate(T input)
        {
            return new AndOperatorRule<T, TResult>(_rules.ToArray()).Validate(input);
        }
    }
}
