using AnimalsAppBackend.ApplicationUtilities.ValidationRules;
using System.Collections.Generic;

namespace AnimalsAppBackend.ApplicationUtilities
{
    class BaseRulesEvaluator<T, R>
    {
        private readonly List<IBaseRule<T, R>> _rules;

        private readonly T _defaultOutcomeResult;

        public BaseRulesEvaluator(T defaultOutcomeResult)
        {
            _rules = new List<IBaseRule<T, R>>();
            _defaultOutcomeResult = defaultOutcomeResult;
        }

        public BaseRulesEvaluator<T, R> AddRule(IBaseRule<T, R> rule)
        {
            _rules.Add(rule);
            return this;
        }

        public T Evaluate(R input)
        {
            foreach(var rule in _rules)
            {
                var result = rule.Validate(input);

                if (!result.Equals(_defaultOutcomeResult))
                {
                    return result;
                }
            }
            return _defaultOutcomeResult;
        }
    }
}