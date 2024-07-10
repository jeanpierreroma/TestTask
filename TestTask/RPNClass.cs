using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BraketAction;

namespace TestTask
{
    public class RpnClass
    {
        private readonly Dictionary<char, IBinaryOperationAction> _operators;

        private readonly Dictionary<char, IExpressionAction> _expressionActions;


        public RpnClass(List<IBinaryOperationAction> operators)
        {
            _operators = operators.ToDictionary(op => op.Operator);

            _expressionActions = new Dictionary<char, IExpressionAction>
            {
                { '\0', new NumberAction() },
                { '(', new LeftBracketAction() },
                { ')', new RightBracketAction() }
            };
        }

        public List<string> ConvertIntoRPNExpression(List<string> expressions)
        {
            List<string> outputList = new List<string>();
            Stack<string> operatorStack = new Stack<string>();

            foreach (var item in expressions)
            {
                if (float.TryParse(item, out _))
                {
                    _expressionActions['\0'].Action(item, outputList, operatorStack);
                }
                else if (_expressionActions.ContainsKey(char.Parse(item)))
                {
                    _expressionActions[char.Parse(item)].Action(item, outputList, operatorStack);
                }
                else
                {
                    ExpressionHandler.HandleOperator(char.Parse(item), outputList, operatorStack, _operators);
                }
            }

            while (operatorStack.Count > 0)
            {
                outputList.Add(operatorStack.Pop());
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
                    float value2 = outputList.Pop();
                    float value1 = outputList.Pop();
                    outputList.Push(_operators[char.Parse(element)].Apply(value1, value2));
                }
            }

            return outputList.Pop();
        }
    }
}
