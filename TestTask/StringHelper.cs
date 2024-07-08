using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public static class StringHelper
    {
        public static List<string> DivideIntoSubStrings(string expression)
        {
            List<string> cells = new List<string>();
            StringBuilder number = new StringBuilder();

            foreach (char c in expression)
            {
                if (char.IsDigit(c))
                {
                    number.Append(c);
                }
                else
                {
                    if (number.Length > 0)
                    {
                        cells.Add(number.ToString());
                        number.Clear();
                    }
                    cells.Add(c.ToString());
                }
            }

            if (number.Length > 0)
            {
                cells.Add(number.ToString());
            }

            return cells;
        }
    }
}
