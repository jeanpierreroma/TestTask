using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.NewFolder1
{
    public class AddOperation : IBinaryOperationAction
    {
        public char Operator => '+';

        public OperationPriority Priority => OperationPriority.LowPriority;

        public Func<float, float, float> Apply => (value1, value2) => value1 + value2;
    }
}
