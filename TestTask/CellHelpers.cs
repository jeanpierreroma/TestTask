using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public static class CellHelpers
    {
        public static void HandleNumber(string cell, List<string> outputList, Stack<string> operatorStack)
        {
            outputList.Add(cell);
        }

        public static void HandleLeftBracket(string cell, List<string> outputList, Stack<string> operatorStack)
        {
            operatorStack.Push(cell);
        }

        public static void HandleRightBracket(string cell, List<string> outputList, Stack<string> operatorStack)
        {
            while (!operatorStack.Peek().Equals("("))
            {
                outputList.Add(operatorStack.Pop());
            }
            operatorStack.Pop();
        }

        public static void HandleOperator(char cell, List<string> outputList, Stack<string> operatorStack, Dictionary<char, IBinaryOperationAction> _operators)
        {
            while (operatorStack.Count > 0
                        && _operators.ContainsKey(char.Parse(operatorStack.Peek()))
                        && _operators[char.Parse(operatorStack.Peek())].Priority >= _operators[cell].Priority)
            {
                outputList.Add(operatorStack.Pop());
            }
            operatorStack.Push(cell.ToString());
        }
    }
}
