using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class StringHelper
    {
        private string _example;

        public StringHelper(string example)
        {
            _example = example;
        }

        public int ResolveExample()
        {
            var subString = NumbersAndSigns(_example);
            var rpnExpression = convertIntoRPN(subString);
            var res = ExecuteRPN(rpnExpression);

            return res;
        }

        private List<string> convertIntoRPN(List<string> cells)
        {
            List<string> numbers = new List<string>();
            Stack<string> operators = new Stack<string>();
            var priority = new Dictionary<string, int>
            {
                { "+", 1 }, 
                { "-", 1 },
                { "*", 2 }, 
                { "/", 2 }
            };

            foreach (var item in cells)
            {
                if (int.TryParse(item, out _))
                {
                    numbers.Add(item);
                }
                else if(item.Equals("("))
                {
                    operators.Push(item);
                }
                else if (item.Equals(")"))
                {
                    while (!operators.Peek().Equals("("))
                    {
                        numbers.Add(operators.Pop());
                    }
                    operators.Pop();
                }
                else
                {
                    while (operators.Count > 0 && priority.ContainsKey(operators.Peek())
                        && priority[operators.Peek()] >= priority[item])
                    {
                        numbers.Add(operators.Pop());
                    }
                    operators.Push(item);
                }
            }

            while (operators.Count > 0)
            {
                numbers.Add(operators.Pop());
            }

            return numbers;
        }

        private int ExecuteRPN(List<string> rpnExpression)
        {
            Stack<int> numbers = new Stack<int>();
            Dictionary<string, Func<int, int, int>> operators = new Dictionary<string, Func<int, int, int>>
            {
                { "+", (a, b) => a + b },
                { "-", (a, b) => a - b },
                { "/", (a, b) => a / b },
                { "*", (a, b) => a * b },
            };

            foreach (string element in rpnExpression)
            {
                if (int.TryParse(element, out int number))
                {
                    numbers.Push(number);
                }
                else
                {
                    int b = numbers.Pop();
                    int a = numbers.Pop();
                    numbers.Push(operators[element](a, b));
                }
            }

            return numbers.Pop();
        }

        // Devide line into numbers and signs
        private static List<string> NumbersAndSigns(string expression)
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
