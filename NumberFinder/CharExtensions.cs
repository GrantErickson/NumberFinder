using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberFinder
{
    public static class CharExtensions
    {

        public static bool IsLetter(this char c)
        {
            return c >= 'A' && c <= 'Z';
        }
    }
}
