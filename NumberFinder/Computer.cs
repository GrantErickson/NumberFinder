using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFinder
{
    public class Computer
    {
        public Computer()
        {
        }

        public int Attempts = 0;


        public Dictionary<string, int[]> Calculate()
        {

            int[] numbers = new int[Unknowns.Length];
            //for (int i = 0; i < numbers.Length + 1; i++) numbers[i] = 0;

            Dictionary<string, int[]> results = new();

            CalculateRecursively(numbers, 0, results);

            return results;
        }

        private void CalculateRecursively(int[] numbers, int index, Dictionary<string, int[]> results)
        {
            Attempts++;
            // Try all the values for this spot.
            for (int x = numbers[index]; x < 10; x++)
            {
                numbers[index] = x;
                var result = EvaluateNumbers(numbers);
                if (result.Success) 
                {
                    // This result 
                    var currentNumbers = string.Join(",", numbers);
                    if (!results.ContainsKey(currentNumbers))
                        results.Add(currentNumbers, numbers);
                    Console.WriteLine($"{currentNumbers}:Works!");
                }
                else
                {
                    // This doesn't work, so start checking if the failing numbers can be adjusted
                    if (Attempts % 100 == 0)
                    {
                        var currentNumbers = string.Join(",", numbers);
                        Console.WriteLine($"{currentNumbers}:No {string.Join(",",result.EvaluatedChars)}");
                    }
                    foreach (var c in result.EvaluatedChars)
                    {
                        // Find the position of this number. 
                        var cIndex = Unknowns.IndexOf(c);
                        if (cIndex > index && numbers[cIndex] < 9)
                        {
                            // Create a new array to hold the new thing to try.
                            var newNumbers = (int[])numbers.Clone();
                            // Increment the area that didn't work and try recursively
                            newNumbers[cIndex]++;
                            CalculateRecursively(newNumbers, cIndex, results);
                        }
                    }
                }
            }
        }

        private ConstraintResult EvaluateNumbers(int[] numbers)
        {
            foreach (var constraint in constraints)
            {
                var result = constraint.Evaluate(numbers);
                if (!result.Success) return result;
            }
            return ConstraintResult.True;
        }

        private string? unknowns = null;
        public string Unknowns
        {
            get
            {
                if (unknowns == null)
                {
                    List<char> chars = new();
                    foreach (var constraint in constraints)
                    {
                        foreach (var c in constraint.GetUnknowns())
                        {
                            if (!chars.Contains(c)) chars.Add(c);
                        }
                    }
                    unknowns = string.Join("", chars.OrderBy(f => f));
                }
                return unknowns;
            }
        }


        private readonly List<ConstraintBase> constraints = new();

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
