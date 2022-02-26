using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFinder
{
    public class Constraint2 : ConstraintBase
    {
        public readonly IEnumerable<string> Variables;
        public readonly Func<int, int, bool> Function;

        public Constraint2(string variables, Func<int, int, bool> function)
        {
            Variables = variables.Split(",", StringSplitOptions.TrimEntries);
            Function = function;
        }

        public override bool Evaluate(IList<int> numbers)
        {
            bool result = true;
            int? lastNumber = null;
            foreach (var v in Variables)
            {
                if (!lastNumber.HasValue)
                {
                    lastNumber = EvaluateExpression(numbers, v);
                }
                else
                {
                    int number = EvaluateExpression(numbers, v);
                    result = result && Function(lastNumber.Value, number);
                    lastNumber = number; // Allow things to be chained a bit.
                }
            }
            return result;
        }
    }
}
