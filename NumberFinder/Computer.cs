using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFinder
{
    public class Computer
    {
        public Computer(int[]? validNumbers = null)
        {
            if (validNumbers == null) validNumbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ValidNumbers = validNumbers;    
        }

        public int Attempts = 0;
        private int[] ValidNumbers;


        public Dictionary<string, int[]> Calculate()
        {
            
            int[] numbers = new int[Unknowns.Length];

            // Make sure 0 is a valid number, if not set the array to a different starting number
            if (!ValidNumbers.Contains(0))
            {
                for(var index = 0; index < Unknowns.Length; index++)
                {
                    numbers[index] = ValidNumbers[0];
                }
            }

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
                if (ValidNumbers.Contains(x))
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
                            Console.WriteLine($"{currentNumbers}:No {string.Join(",", result.HumanExpression)}");
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
        }

        private ConstraintResult EvaluateNumbers(int[] numbers)
        {
            foreach (var constraint in Constraints)
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
                    foreach (var constraint in Constraints)
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


        private readonly List<ConstraintBase> Constraints = new();

        public Computer Equal(string expression)
        {
            Constraints.Add(new Constraint2(expression, (a, b) => a == b, "Equal"));
            return this;
        }
        public Computer Value(string expression, int value)
        {
            // Convenience
            return Equal($"{expression},{value}");
        }
        public Computer Even(string expression)
        {
            Constraints.Add(new Constraint1(expression, a => a % 2 == 0, "Even"));
            return this;
        }
        public Computer Odd(string expression)
        {
            Constraints.Add(new Constraint1(expression, a => a % 2 == 1, "Odd"));
            return this;
        }
        public Computer Unique(string expression)
        {
            Constraints.Add(new UniqueConstraint(expression));
            return this;
        }


    }
}
