using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public interface IExpressionAction
    {
        char Operator { get; }
        OperationPriority Priority { get; }
        Action<string, List<string>, Stack<string>> Action { get; }

    }
}
