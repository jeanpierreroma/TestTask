using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class RPNClass
    {
        private readonly Dictionary<string, IBinaryOperationAction> _operators;

        public delegate void CellHelper(string token, List<string> numbers, Stack<string> operators);

        private readonly Dictionary<string, CellHelper> _cellHelpers;


        public RPNClass(IEnumerable<IBinaryOperationAction> operators)
        {
            _operators = operators.ToDictionary(op => op.Operator);

            _cellHelpers = new Dictionary<string, CellHelper>
            {
                { "number", CellHelpers.NumberHelper},
                { "(", CellHelpers.LeftBracketHelper },
                { ")", CellHelpers.RightBracketHelper }
            };

            foreach (var op in _operators.Keys)
            {
                _cellHelpers[op] = (cell, numbers, currectOperator) => CellHelpers.OperatorHelper(cell, numbers, currectOperator, _operators);
            }
        }

        public List<string> ConvertIntoRPNExpression(List<string> cells)
        {
            List<string> numbers = new List<string>();
            Stack<string> operators = new Stack<string>();

            foreach (var item in cells)
            {
                if (int.TryParse(item, out _))
                {
                    _cellHelpers["number"](item, numbers, operators);
                }
                else
                {
                    _cellHelpers[item](item, numbers, operators);
                }
            }

            while (operators.Count > 0)
            {
                numbers.Add(operators.Pop());
            }

            return numbers;
        }

        public int ExecuteRPN(List<string> rpnExpression)
        {
            Stack<int> numbers = new Stack<int>();
            
            foreach (string element in rpnExpression)
            {
                if (int.TryParse(element, out int number))
                {
                    numbers.Push(number);
                }
                else
                {
                    int num2 = numbers.Pop();
                    int num1 = numbers.Pop();
                    numbers.Push(_operators[element].Apply(num1, num2));
                }
            }

            return numbers.Pop();
        }
    }
}
