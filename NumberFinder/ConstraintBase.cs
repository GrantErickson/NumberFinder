namespace NumberFinder
{
    public abstract class ConstraintBase
    {
        protected IEnumerable<string>? _variables = null;
        protected IEnumerable<string> Variables
        {
            get
            {
                return _variables!;
            }
            set
            {
                _variables = value;
            }


        }

        public abstract ConstraintResult Evaluate(IList<int> numbers);

        private readonly Dictionary<string, Func<int, int, int>> Operators = new()
        {
            { "+", (a, b) => a + b },
            { "-", (a, b) => a - b },
            { "*", (a, b) => a * b },
            { "/", (a, b) => (int)((double)a / (double)b) },
        };

        private static int GetNumber(IList<int> numbers, string v)
        {
            var number = 0.0;
            var power = v.Length - 1;
            foreach (var c in v)
            {
                if (!int.TryParse(c.ToString(), out int digit))
                {
                    digit = (numbers[(int)c - (int)'A']);
                }
                else
                {
                    // This is a number
                    //Console.WriteLine(digit);
                }
                number = number + digit * Math.Pow(10, power);
                power--;
            }
            return (int)number;
        }

        /// <summary>
        /// Parse a string into numers and operands
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        private IEnumerable<string> ParseExpression(string expression)
        {
            List<string> parts = new();
            var operands = string.Join("", Operators.Select(f => f.Key));
            string current = "";
            foreach (var c in expression)
            {
                if (operands.Contains(c))
                {
                    parts.Add(current);
                    parts.Add(c.ToString());
                    current = "";
                }
                else
                {
                    current += c;
                }
            }
            if (current == "") throw new ArgumentException($"The expression {expression} is blank or ends with an operator.");
            parts.Add(current);
            return parts;
        }

        protected int EvaluateExpression(IList<int> numbers, string expression)
        {
            var parts = ParseExpression(expression);
            string? currentOperator = null;
            int result = 0;
            foreach (var c in parts)
            {
                if (Operators.ContainsKey(c))
                {
                    currentOperator = c;
                }
                else
                {
                    int argument = GetNumber(numbers, c);
                    if (currentOperator != null)
                    {
                        result = Operators[currentOperator](result, argument);
                    }
                    else
                    {
                        result = argument;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a string of unknown variables in this constraint.
        /// </summary>
        /// <returns></returns>
        public string GetUnknowns()
        {
            List<char> chars = new();
            foreach (var v in Variables!)
            {
                foreach (var c in v)
                {
                    if (c.IsLetter())
                    {
                        if (!chars.Contains(c)) chars.Add(c);
                    }
                }
            }
            return string.Join("", chars.OrderBy(f => f));
        }
    }
}