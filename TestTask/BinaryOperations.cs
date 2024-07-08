using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class AddOperation : IBinaryOperationAction
    {
        public string Operator => "+";

        public int Priority => 1;

        public int Apply(int a, int b) => a + b;
    }

    public class SubtractOperation : IBinaryOperationAction
    {
        public string Operator => "-";

        public int Priority => 1;

        public int Apply(int a, int b) => a - b;
    }

    public class MultiplyOperation : IBinaryOperationAction
    {
        public string Operator => "*";

        public int Priority => 2;

        public int Apply(int a, int b) => a * b;
    }

    public class DivideOperation : IBinaryOperationAction
    { 
        public string Operator => "/";
        public int Priority => 2;
        public int Apply(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            return a / b;
        }
    }
}
