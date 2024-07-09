using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class BinaryOperation<T> : IBinaryOperationAction<T>
    {
        public string Operator { get; }
        public int Priority { get; }
        public Apply<T> Operation { get; }

        public BinaryOperation(string operatorSymbol, int priority, Apply<T> operation)
        {
            Operator = operatorSymbol;
            Priority = priority;
            Operation = operation;
        }
    }
}
