using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BraketAction;

namespace TestTask
{
    public static class ExpressionHandler
    {
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
