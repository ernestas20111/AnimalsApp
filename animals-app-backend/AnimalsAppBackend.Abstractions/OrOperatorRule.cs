using System.Collections.Generic;
using System.Linq;

namespace AnimalsAppBackend.Abstractions
{
    public class OrOperatorRule<T, R> : IBaseRule<T, R>
    {
        private readonly List<IBaseRule<T, R>> _rules;

        public OrOperatorRule(params IBaseRule<T, R>[] rules)
        {
            _rules = new List<IBaseRule<T, R>>(rules);
        }

        public bool IsValid(R input)
        {
            return _rules.Any(rule => rule.IsValid(input));
        }

        public T Validate(R input)
        {
            //if (IsValid(input))
            //{
            //    return _rules.FirstOrDefault().Validate(input);
            //}
            //return new ValidationResult(_errorMessage);
        }
    }
}