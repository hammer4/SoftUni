using System;
using System.Collections.Generic;
using System.Text;

public class AdditionStrategy : ICalculationStrategy
{
    public int Calculate(int leftOperand, int rightOperand)
    {
        return leftOperand + rightOperand;
    }
}