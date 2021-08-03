using System;

namespace ExtraLangFeatures
{
    public class Operation
    {
        public int Value { get; set; } = 5;
        public static Operation operator ++(Operation op)
        {
            op.Value++;
            return op;
        }


        public static Operation operator +(Operation op1, Operation op2)
        {
            var op = new Operation();
            op.Value = op1.Value + op2.Value;
            return op;
        }

        public static bool operator ==(Operation op1, Operation op2)
        {
            return op1.Value == op2.Value;
        }

        public static bool operator !=(Operation op1, Operation op2)
        {
            return !(op1 == op2);
        }

        public override string ToString()
        {
            return $"{nameof(Value)}: {Value}";
        }

        public static explicit operator MathOperator(Operation op) => new MathOperator(op.Value*2);
      //  public static implicit operator MathOperator(Operation op) => new MathOperator(op.Value*2);

    }

    public class MathOperator
    {
        public MathOperator(int someValue)
        {
            SomeValue = someValue;
        }

        public MathOperator()
        {
        }

        public int SomeValue { get; set; }
    }
}