using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public static class OperationsFactory
    {
        public static IBinaryOperationAction<int> CreateAddOperation()
        {
            return new BinaryOperation<int>("+", 1, (num1, num2) => num1 + num2);
        }

        public static IBinaryOperationAction<int> CreateSubtractOperation()
        {
            return new BinaryOperation<int>("-", 1, (num1, num2) => num1 - num2);
        }

        public static IBinaryOperationAction<int> CreateMultiplyOperation()
        {
            return new BinaryOperation<int>("*", 2, (num1, num2) => num1 * num2);
        }

        public static IBinaryOperationAction<int> CreateDivideOperation()
        {
            return new BinaryOperation<int>("/", 2, (num1, num2) =>
            {
                if (num2 == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }
                return num1 / num2;
            });
        }

        public static IBinaryOperationAction<double> CreateAddOperationDouble()
        {
            return new BinaryOperation<double>("+", 1, (num1, num2) => num1 + num2);
        }

        public static IBinaryOperationAction<double> CreateSubtractOperationDouble()
        {
            return new BinaryOperation<double>("-", 1, (num1, num2) => num1 - num2);
        }

        public static IBinaryOperationAction<double> CreateMultiplyOperationDouble()
        {
            return new BinaryOperation<double>("*", 2, (num1, num2) => num1 * num2);
        }

        public static IBinaryOperationAction<double> CreateDivideOperationDouble()
        {
            return new BinaryOperation<double>("/", 2, (num1, num2) =>
            {
                if (num2 == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }
                return num1 / num2;
            });
        }
    }

}
