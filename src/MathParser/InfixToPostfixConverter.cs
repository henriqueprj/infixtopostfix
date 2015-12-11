using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public class Operator
    {
        public static readonly Operator Plus = new Operator("+");
        public static readonly Operator Minus = new Operator("-");
        public static readonly Operator Multiply = new Operator("*");
        public static readonly Operator Division = new Operator("/");
        public static readonly Operator Pow = new Operator("/");


        public string Symbol { get; }

        private Operator(string symbol, bool isRightAssociative = false)
        {
            
        }    
    }

    public class InfixToPostfixConverter
    {
        static readonly Dictionary<string, int> OperatorsPrecedence =
            new Dictionary<string, int>
            {
                ["^"] = 4,
                ["*"] = 3,
                ["/"] = 3,
                ["+"] = 2,
                ["-"] = 2,
                ["("] = 1
            };

        private bool IsRightAssociative(string @operator)
        {
            return @operator == "^" ? true : false;
        }

        public string Convert(string expression)
        {
            var tokens = Tokenizer.Extract(expression);

            var output = new List<Token>();
            var operatorStack = new Stack<Token>();

            foreach (var token in tokens)
            {
                switch (token.Type)
                {
                    case TokenType.Number:
                        output.Add(token);
                        break;

                    case TokenType.Operator:
                        if (operatorStack.Count == 0)
                        {
                            operatorStack.Push(token);
                            continue;
                        }

                        while (operatorStack.Count > 0 && 
                            (OperatorsPrecedence[token.Value] < OperatorsPrecedence[operatorStack.Peek().Value] || 
                            (OperatorsPrecedence[token.Value] == OperatorsPrecedence[operatorStack.Peek().Value] &&
                                !IsRightAssociative(token.Value)))) 
                        {
                            output.Add(operatorStack.Pop());
                        }

                        operatorStack.Push(token);
                        break;

                    case TokenType.OpenParenthesis:
                        operatorStack.Push(token);
                        break;

                    case TokenType.CloseParenthesis:
                        while (operatorStack.Count > 0 && operatorStack.Peek().Value != "(")
                        {
                            output.Add(operatorStack.Pop());
                        }

                        if (operatorStack.Count > 0)
                            operatorStack.Pop(); // remove (

                        break;
                }
            }

            while (operatorStack.Count > 0)
            {
                output.Add(operatorStack.Pop());
            }

            return string.Join(" ", output.Select(token => token.Value));
        }
    }
}
