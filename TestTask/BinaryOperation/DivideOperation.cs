using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.NewFolder1
{
    public class DivideOperation : IBinaryOperationAction
    {
        public char Operator => '/';
        public OperationPriority Priority => OperationPriority.MediumPriority;

        public Func<float, float, float> Apply => (value1, value2) =>
        {
            if (value2 == 0)
            {
                throw new DivideByZeroException();
            }
            return value1 / value2;
        };
    }
}
