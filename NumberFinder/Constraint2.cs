using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFinder
{
    public class Constraint2 : ConstraintBase
    {
        public readonly Func<int, int, bool> Function;
        public readonly string Text;

        public Constraint2(string variables, Func<int, int, bool> function, string text)
        {
            Variables = variables.ToUpper().Split(",", StringSplitOptions.TrimEntries);
            Function = function;
            Text = text;
        }

        public override ConstraintResult Evaluate(IList<int> numbers)
        {
            int? lastNumber = null;
            string lastVar = "";
            foreach (var v in Variables)
            {
                if (!lastNumber.HasValue)
                {
                    lastNumber = EvaluateExpression(numbers, v);
                    lastVar = v;
                }
                else
                {
                    int number = EvaluateExpression(numbers, v);
                    if (!Function(lastNumber.Value, number))
                    {
                        return new ConstraintResult(false, lastVar + v, Text + "(" + string.Join(", ", Variables) + ")");
                    }
                    else
                    {
                        //Console.WriteLine($"{lastNumber.Value}=={number}");
                    }
                    lastNumber = number; // Allow things to be chained a bit.
                    lastVar = v;
                }
            }
            return ConstraintResult.True;
        }
    }
}
