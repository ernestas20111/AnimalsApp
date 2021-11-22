﻿using System.Collections.Generic;

namespace AnimalsAppBackend.Abstractions
{
    public class BaseRulesEvaluator<T, R>
    {
        private readonly List<IBaseRule<T, R>> _rules;

        private readonly T _defaultOutcomeResult;

        public BaseRulesEvaluator(T defaultOutcomeResult)
        {
            _rules = new List<IBaseRule<T, R>>();
            _defaultOutcomeResult = defaultOutcomeResult;
        }

        public virtual BaseRulesEvaluator<T, R> AddRule(IBaseRule<T, R> rule)
        {
            _rules.Add(rule);
            return this;
        }

        public virtual T Evaluate(R input)
        {
            foreach (var rule in _rules)
            {
                var result = rule.Validate(input);

                if (IsDifferentFromDefaultOutcome(result))
                {
                    return result;
                }
            }
            return _defaultOutcomeResult;
        }

        private bool IsDifferentFromDefaultOutcome(T result)
        {
            return (result is null && _defaultOutcomeResult is object)
                || (result is object && _defaultOutcomeResult is null)
                || (result is object && _defaultOutcomeResult is object && !result.Equals(_defaultOutcomeResult));
        }
    }
}