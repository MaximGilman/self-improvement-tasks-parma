using System;

namespace ExtraLangFeatures
{
    public class OperationOverrider
    {
        public void Run()
        {
            Operation op = new Operation();
            Console.WriteLine(op.ToString());
            
            op++;
            Console.WriteLine(op.ToString());
            
            op += op;
            Console.WriteLine(op.ToString());

            Operation op2 = new Operation();

            Console.WriteLine(op==op2);

            // Преобразование
            MathOperator mathOperator = (MathOperator) op;
        }
    }
}