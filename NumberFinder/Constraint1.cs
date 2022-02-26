using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFinder
{
    public class Constraint1 : ConstraintBase
    {
        public readonly IEnumerable<string> Variables;
        public readonly Func<int, bool> Function;

        public Constraint1(string variables, Func<int, bool> function)
        {
            Variables = variables.Split(",", StringSplitOptions.TrimEntries);
            Function = function;
        }

        public override bool Evaluate(IList<int> numbers)
        {
            bool result = true;
            foreach (var v in Variables)
            {
                int number = EvaluateExpression(numbers, v);
                result = result && Function(number);
            }
            return result;
        }
    }
}
