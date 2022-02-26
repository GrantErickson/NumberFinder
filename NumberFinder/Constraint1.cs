using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFinder
{
    public class Constraint1 : ConstraintBase
    {
        public readonly Func<int, bool> Function;

        public Constraint1(string variables, Func<int, bool> function)
        {
            Variables = variables.ToUpper().Split(",", StringSplitOptions.TrimEntries);
            Function = function;
        }

        public override ConstraintResult Evaluate(IList<int> numbers)
        {
            foreach (var v in Variables)
            {
                int number = EvaluateExpression(numbers, v);
                if (!Function(number))
                {
                    return new ConstraintResult(false, v);
                }
            }
            return ConstraintResult.True;
        }
    }
}
