using System.Collections.Generic;

namespace AnimalsAppBackend.Abstractions.Rules
{
    public class ValidationRulesEvaluator<T, TResult>
    {
        private readonly List<IValidationRule<T, TResult>> _rules;

        private readonly TResult _defaultOutcomeResult;

        public ValidationRulesEvaluator(TResult defaultOutcomeResult)
        {
            _rules = new List<IValidationRule<T, TResult>>();
            _defaultOutcomeResult = defaultOutcomeResult;
        }

        public virtual ValidationRulesEvaluator<T, TResult> AddRule(IValidationRule<T, TResult> rule)
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
