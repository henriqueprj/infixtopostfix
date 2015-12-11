using System.Collections.Generic;
using System.Linq;

namespace MathParser
{
    public class Tokenizer
    {
        public static IEnumerable<Token> Extract(string expression)
        {
            return expression.Split(' ').Where(token => !string.IsNullOrEmpty(token)).Select(token => new Token(token.Trim()));
        }
    }
}