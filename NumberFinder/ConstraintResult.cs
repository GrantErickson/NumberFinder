using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFinder
{
    public class ConstraintResult
    {
        public static readonly ConstraintResult True = new(true);

        public bool Success { get; }
        public IEnumerable<char> EvaluatedChars { get; }

        public ConstraintResult(bool success, string expression)
        {
            Success = success;
            List<char> result = new();
            foreach (char c in expression)
            {
                if (c.IsLetter() && !result.Contains(c))
                {
                    result.Add(c);
                }
            }
            EvaluatedChars = result;
        }

        private ConstraintResult(bool success)
        {
            if (!success) throw new ArgumentException("This constructor can only be used for false results.");
            Success = success;
            EvaluatedChars = new List<char>();
        }
    }
}
