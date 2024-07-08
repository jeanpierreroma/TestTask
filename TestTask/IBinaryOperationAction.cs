using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public interface IBinaryOperationAction
    {
        string Operator { get; }
        int Priority { get; }
        int Apply(int num1, int num2);
    }
}
