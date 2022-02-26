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

        public override bool Evaluate(IList<int> numbers)
        {
            List<int> digits = new();
            foreach (var v in Variables)
            {
                digits.Add(EvaluateExpression(numbers, v));
            }
            return digits.Distinct().Count() == digits.Count();
        }
    }
}
