using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public class InfixLexicalAnalyzer
    {
        

        public IEnumerable<Token> Analyze(string infixExpression)
        {
            var tokens = Tokenizer.Extract(infixExpression);

            var validTokens = new List<Token>();

            foreach (var token in tokens)
            {
                
            }

            return validTokens;
        }
    }

    class InfixLexicalStateMachine
    {
        class StateTransition
        {

        }
    }
}
