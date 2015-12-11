using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace MathParser.Tests
{
    public class PostfixEvaluatorTest
    {
        [Fact]
        public void Deve_avaliar_operador_soma_com_dois_operandos()
        {
            var eval = new PostfixEvaluator();
            var result = eval.Evaluate("2 2 +");

            result.Should().Be(4.0);
        }

        [Fact]
        public void Deve_avaliar_operador_soma_multiplicacao_com_dois_operandos()
        {
            var eval = new PostfixEvaluator();
            // 2 ^ 4 / (5 * 8) + 10
            var result = eval.Evaluate("2 4 ^ 5 8 * / 10 +");

            result.Should().Be(10.4);
        }

        [Fact]
        public void Expression_tree_complexa()
        {
            var eval = new PostfixEvaluator();
            // 3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3
            var result = eval.BuildExpressionTree("3 4 2 * 1 5 - 2 3 ^ ^ / +");

            result.Should().Be(10.4);
        }
    }
}
