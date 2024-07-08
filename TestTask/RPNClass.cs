using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class RPNClass
    {
        private readonly Dictionary<string, IBinaryOperationAction> _operators;

        public RPNClass(IEnumerable<IBinaryOperationAction> operators)
        {
            _operators = operators.ToDictionary(op => op.Operator);
        }
        public List<string> ConvertIntoRPNExpression(List<string> cells)
        {
            List<string> numbers = new List<string>();
            Stack<string> operators = new Stack<string>();

            foreach (var item in cells)
            {
                if (int.TryParse(item, out _))
                {
                    numbers.Add(item);
                }
                else if (item.Equals("("))
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
                    while (operators.Count > 0 
                        && _operators.ContainsKey(operators.Peek())
                        && _operators[operators.Peek()].Priority >= _operators[item].Priority)
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

        public int ExecuteRPN(List<string> rpnExpression)
        {
            Stack<int> numbers = new Stack<int>();
            
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
                    numbers.Push(_operators[element].Apply(a, b));
                }
            }

            return numbers.Pop();
        }
    }
}
