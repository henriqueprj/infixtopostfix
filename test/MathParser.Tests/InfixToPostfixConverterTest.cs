using System;
using FluentAssertions;
using Xunit;

namespace MathParser.Tests
{
    public class InfixToPostfixConverterTest
    {
        [Fact]
        public void Soma_com_dois_operandos()
        {
            var converter = new InfixToPostfixConverter();
            var result = converter.Convert("2 + 2");

            result.Should().Be("2 2 +");
        }

        [Fact]
        public void Soma_e_multiplicacao()
        {
            var converter = new InfixToPostfixConverter();
            var result = converter.Convert("2 + 2 * 4");

            result.Should().Be("2 2 4 * +");
        }

        [Fact]
        public void Soma_com_parentesis_e_multiplicacao()
        {
            var converter = new InfixToPostfixConverter();
            var result = converter.Convert("(2 + 2) * 4");

            result.Should().Be("2 2 + 4 *");
        }

        [Fact]
        public void Maior_precedencia_com_associatividade_direita_para_esquerda()
        {
            var converter = new InfixToPostfixConverter();
            var result = converter.Convert("4 * 5 ^ 2");

            result.Should().Be("4 5 2 ^ *");
        }

        [Fact]
        public void Expressao_complexa()
        {
            var converter = new InfixToPostfixConverter();
            var result = converter.Convert("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3");

            result.Should().Be("3 4 2 * 1 5 - 2 3 ^ ^ / +");
        }

        private string Foo()
        {
            return "Bar";
        }
    }
}