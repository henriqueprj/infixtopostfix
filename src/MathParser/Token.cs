using System;
using System.Diagnostics;
using System.Linq;

namespace MathParser
{
    [DebuggerDisplay("Token = {Value}")]
    public class Token
    {
        private static readonly string[] Operators = { "+", "-", "/", "*", "^", "%" };

        public string Value { get; }

        public TokenType Type { get; }

        public Token(string token)
        {
            Value = token;
            Type = GetTokenType(token);
        }

        private TokenType GetTokenType(string token)
        {
            double d;
            var isNumber = double.TryParse(token, out d);

            if (isNumber) return TokenType.Number;

            if (Operators.Contains(token)) return TokenType.Operator;

            if (token == "(") return TokenType.OpenParenthesis;

            if (token == ")") return TokenType.CloseParenthesis;

            return TokenType.Unknown;
        }

        public bool IsOperator => Operators.Contains(Value);

        public bool IsNumber
        {
            get
            {
                double d;
                return double.TryParse(Value, out d);
            }
        }

        public double GetNumber()
        {
            double d;
            if (!double.TryParse(Value, out d))
                throw new Exception("Token is not a number.");
            return d;
        }
    }
}