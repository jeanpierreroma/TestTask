using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BraketAction;

namespace TestTask
{
    public class RPNClass
    {
        private readonly Dictionary<char, IBinaryOperationAction> _operators;

        private readonly Dictionary<char, IExpressionAction> _expressionActions;


        public RPNClass(List<IBinaryOperationAction> operators)
        {
            _operators = operators.ToDictionary(op => op.Operator);

            _expressionActions = new Dictionary<char, IExpressionAction>
            {
                { '\0', new NumberAction() },
                { '(', new LeftBracketAction() },
                { ')', new RightBracketAction() }
            };
        }

        public List<string> ConvertIntoRPNExpression(List<string> cells)
        {
            List<string> outputList = new List<string>();
            Stack<string> operators = new Stack<string>();

            foreach (var item in cells)
            {
                if (float.TryParse(item, out _))
                {
                    _expressionActions['\0'].Action(item, outputList, operators);
                }
                else if (_expressionActions.ContainsKey(char.Parse(item)))
                {
                    _expressionActions[char.Parse(item)].Action(item, outputList, operators);
                }
                else
                {
                    ExpressionHandler.HandleOperator(char.Parse(item), outputList, operators, _operators);
                }
            }

            while (operators.Count > 0)
            {
                outputList.Add(operators.Pop());
            }

            return outputList;
        }

        public float ExecuteRPN(List<string> rpnExpression)
        {
            Stack<float> outputList = new Stack<float>();
            
            foreach (string element in rpnExpression)
            {
                if (float.TryParse(element, out float number))
                {
                    outputList.Push(number);
                }
                else
                {
                    float num2 = outputList.Pop();
                    float num1 = outputList.Pop();
                    outputList.Push(_operators[char.Parse(element)].Apply(num1, num2));
                }
            }

            return outputList.Pop();
        }
    }
}
