using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NumberFinder
{
    public class UniqueConstraint : ConstraintBase
    {
        public UniqueConstraint(string variables)
        {
            Variables = variables.ToUpper().Split(",", StringSplitOptions.TrimEntries);
        }

        public override ConstraintResult Evaluate(IList<int> numbers)
        {
            Dictionary<int, string> digits = new();
            foreach (var v in Variables)
            {
                var digit = EvaluateExpression(numbers, v);
                if (digits.ContainsKey(digit))
                {
                    return new ConstraintResult(false, digits[digit] + v, "Unique(" + string.Join(", ", Variables) + ")");
                }
                else
                {
                    digits.Add(digit, v);
                }
            }
            return ConstraintResult.True;
        }
    }
}
