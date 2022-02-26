using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFinder
{
    public class UniqueConstraint : ConstraintBase
    {
        public readonly IEnumerable<string> Variables;

        public UniqueConstraint(string variables)
        {
            Variables = variables.Split(",", StringSplitOptions.TrimEntries);
        }

        public override ConstraintResult Evaluate(IList<int> numbers)
        {
            Dictionary<int, string> digits = new();
            foreach (var v in Variables)
            {
                var digit = EvaluateExpression(numbers, v);
                if (digits.ContainsKey(digit))
                {
                    return new ConstraintResult(false, digits[digit] + v);
                }
                else
                {
                    digits.Add(digit, v);
                }
            }
            return new ConstraintResult(false);
        }
    }
}
