using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.BraketAction
{
    public class RightBracketAction : IExpressionAction
    {
        public char Operator => ')';

        public OperationPriority Priority => OperationPriority.High;

        public Action<string, List<string>, Stack<string>> Action => (expression, outputList, operatorStack) =>
        {
            while (!operatorStack.Peek().Equals("("))
            {
                outputList.Add(operatorStack.Pop());
            }
            operatorStack.Pop();
        };
    }
}
