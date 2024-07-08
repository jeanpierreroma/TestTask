using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string f = "3+5*(10-5)+50-(5*20-10)";

            var subString = StringHelper.DivideIntoSubStrings(f);

            var operatorsList = new List<IBinaryOperationAction>
            {
                new AddOperation(),
                new SubtractOperation(),
                new MultiplyOperation(),
                new DivideOperation(),
            };

            RPNClass rpnClass = new RPNClass(operatorsList);
            var rpnExpression = rpnClass.ConvertIntoRPNExpression(subString);
            var result = rpnClass.ExecuteRPN(rpnExpression);


            Console.WriteLine(result);
        }        
    }
}
