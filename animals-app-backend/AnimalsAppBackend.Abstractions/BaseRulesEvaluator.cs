using System.Collections.Generic;

namespace AnimalsAppBackend.Abstractions
{
    public class BaseRulesEvaluator<T,TResult>
    {
        private readonly List<IBaseRule<T,TResult>> _rules;

        private readonly TResult _defaultOutcomeResult;

        public BaseRulesEvaluator(TResult defaultOutcomeResult)
        {
            _rules = new List<IBaseRule<T,TResult>>();
            _defaultOutcomeResult = defaultOutcomeResult;
        }

        public virtual BaseRulesEvaluator<T,TResult> AddRule(IBaseRule<T,TResult> rule)
        {
            _rules.Add(rule);
            return this;
        }

        public virtual TResult Evaluate(T input)
        {
            foreach (var rule in _rules)
            {
                var result = rule.Validate(input);

                if (GenericTypesUtilities<TResult>.Equals(result, _defaultOutcomeResult))
                {
                    return result;
                }
            }
            return _defaultOutcomeResult;
        }
    }
}