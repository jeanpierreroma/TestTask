using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.BraketAction
{
    public class NumberAction : IExpressionAction
    {
        public char Operator => '\0';

        public OperationPriority Priority => OperationPriority.None;

        public Action<string, List<string>, Stack<string>> Action => (expression, outputList, operatorStack) =>
        {
            outputList.Add(expression);
        };
    }
}
