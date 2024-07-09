using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public interface IBinaryOperationAction
    {
        char Operator { get; }
        OperationPriority Priority { get; }
        Func<float, float, float> Apply { get; }
    }
}
