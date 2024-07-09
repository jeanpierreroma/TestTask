using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.NewFolder1
{
    public class MultiplyOperation : IBinaryOperationAction
    {
        public char Operator => '*';

        public OperationPriority Priority => OperationPriority.MediumPriority;

        public Func<int, int, int> Apply => (value1, value2) => value1 * value2;
    }
}
