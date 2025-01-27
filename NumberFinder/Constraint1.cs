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
        public readonly string Text;

        public Constraint1(string variables, Func<int, bool> function, string text)
        {
            Variables = variables.ToUpper().Split(",", StringSplitOptions.TrimEntries);
            Function = function;
            Text = text;
        }

        public override ConstraintResult Evaluate(IList<int> numbers)
        {
            foreach (var v in Variables)
            {
                int number = EvaluateExpression(numbers, v);
                if (!Function(number))
                {
                    return new ConstraintResult(false, v, Text + "(" + string.Join(", ", Variables) + ")");
                }
            }
            return ConstraintResult.True;
        }
    }
}
