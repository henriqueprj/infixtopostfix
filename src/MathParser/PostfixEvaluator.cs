using System;
using System.Collections.Generic;
using System.Linq;

namespace MathParser
{
    public class PostfixEvaluator
    {
        public Expression BuildExpressionTree(string postfixExpression)
        {
            var tokenList = Tokenizer.Extract(postfixExpression);
            var tokens = new Stack<Token>(tokenList.Reverse());
            var output = new Stack<Expression>();

            while (tokens.Count > 0)
            {
                var token = tokens.Pop();
                if (token.IsNumber)
                {
                    output.Push(new NumberExpression(token.GetNumber()));
                }
                else
                {
                    var result = CreateExpressionForOperator(token.Value, output);
                    output.Push(result);
                }
            }

            var finalResult = output.Pop();
            return finalResult;
        }

        private Expression CreateExpressionForOperator(string @operator, Stack<Expression> output)
        {
            switch (@operator)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "^":
                    var rightOperand = output.Pop();
                    var leftOperand = output.Pop();
                    return new BinaryExpression(@operator, leftOperand, rightOperand);
                default:
                    throw new Exception($"Invalid operator '{@operator}'.");
            }
        }

        public double Evaluate(string expression)
        {
            var tokenList = Tokenizer.Extract(expression);
            var tokens = new Stack<Token>(tokenList.Reverse());
            var output = new Stack<double>();

            while (tokens.Count > 0)
            {
                var token = tokens.Pop();
                if (token.IsNumber)
                {
                    output.Push(token.GetNumber());
                }
                else
                {
                    var y = output.Pop();
                    var x = output.Pop();
                    var result = EvalOperator(token.Value, x, y);
                    output.Push(result);
                }
            }

            var finalResult = output.Pop();
            return finalResult;
        }

        private double EvalOperator(string op, double a, double b)
        {
            switch (op)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a*b;
                case "/":
                    return a/b;
                case "^":
                    return Math.Pow(a, b);
                default:
                    throw new Exception($"Invalid operator '{op}'.");
            }
        }

        private Stack<Token> GetTokens(string expression)
        {
            return new Stack<Token>(expression.Split(' ').Select(token => new Token(token.Trim())));
        }
    }
}