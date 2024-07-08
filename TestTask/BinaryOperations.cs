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

        public int Apply(int num1, int num2) => num1 + num2;
    }

    public class SubtractOperation : IBinaryOperationAction
    {
        public string Operator => "-";

        public int Priority => 1;

        public int Apply(int num1, int num2) => num1 - num2;
    }

    public class MultiplyOperation : IBinaryOperationAction
    {
        public string Operator => "*";

        public int Priority => 2;

        public int Apply(int num1, int num2) => num1 * num2;
    }

    public class DivideOperation : IBinaryOperationAction
    { 
        public string Operator => "/";
        public int Priority => 2;
        public int Apply(int num1, int num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException();
            }

            return num1 / num2;
        }
    }
}
