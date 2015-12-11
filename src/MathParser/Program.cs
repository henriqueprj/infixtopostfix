using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace MathParser
{
    public abstract class Expression
    {
    }

    public enum Operador
    {
        Add,
        Minus,
        Divide,
        Multiply,
        Modulus,
        Power
    }

    public class NumberExpression : Expression
    {
        public double Value { get; private set; }

        public NumberExpression(double value)
        {
            Value = value;
        }
    }

    public class BinaryExpression : Expression
    {
        public BinaryExpression(string @operator, Expression left, Expression right)
        {
            Operator = @operator;
            Left = left;
            Right = right;
        }

        public Expression Left { get; }

        public string Operator { get; }

        public Expression Right { get; }
    }
}
