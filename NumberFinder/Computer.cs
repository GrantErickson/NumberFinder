using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFinder
{
    public class Computer
    {
        private int UnknownCount;
        public Computer(int unknownCount)
        {
            UnknownCount = unknownCount;
        }

        public List<int[]> Calculate()
        {

            int[] numbers = new int[UnknownCount];
            //for (int i = 0; i < numbers.Length + 1; i++) numbers[i] = 0;

            List<int[]> results = new();

            CalculateRecursively(numbers, 0, results);

            return results;
        }

        private void CalculateRecursively(int[] numbers, int unknownIndex, List<int[]> results)
        {
            // TODO

        }

        private bool EvaluateNumbers(int[] numbers)
        {
            foreach (var constraint in constraints)
            {
                if (!constraint.Evaluate(numbers)) return false;
            }
            return true;
        }


        private List<ConstraintBase> constraints = new();

        public Computer Equal(string expression)
        {
            constraints.Add(new Constraint2(expression, (a, b) => a == b));
            return this;
        }
        public Computer Value(string expression, int value)
        {
            // Convenience
            return Equal($"{expression},{value}");
        }
        public Computer Even(string expression)
        {
            constraints.Add(new Constraint1(expression, a => a % 2 == 0));
            return this;
        }
        public Computer Odd(string expression)
        {
            constraints.Add(new Constraint1(expression, a => a % 2 == 1));
            return this;
        }
        public Computer Unique(string expression)
        {
            constraints.Add(new UniqueConstraint(expression));
            return this;
        }


    }
}
