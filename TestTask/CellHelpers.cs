using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public static class CellHelpers
    {
        public static void NumberHelper(string cell, List<string> numbers, Stack<string> operators)
        {
            numbers.Add(cell);
        }

        public static void LeftBracketHelper(string cell, List<string> numbers, Stack<string> operators)
        {
            operators.Push(cell);
        }

        public static void RightBracketHelper(string cell, List<string> numbers, Stack<string> operators)
        {
            while (!operators.Peek().Equals("("))
            {
                numbers.Add(operators.Pop());
            }
            operators.Pop();
        }

        public static void OperatorHelper(string cell, List<string> numbers, Stack<string> operators, Dictionary<string, IBinaryOperationAction> _operators)
        {
            while (operators.Count > 0
                        && _operators.ContainsKey(operators.Peek())
                        && _operators[operators.Peek()].Priority >= _operators[cell].Priority)
            {
                numbers.Add(operators.Pop());
            }
            operators.Push(cell);
        }
    }
}
