using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.BraketAction
{
    public class LeftBracketAction : IExpressionAction
    {
        public char Operator => '(';

        public OperationPriority Priority => OperationPriority.High;

        public Action<string, List<string>, Stack<string>> Action => (expression, outputList, operatorStack) =>
        {
            operatorStack.Push(expression);
        };
    }
}
