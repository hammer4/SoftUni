using System;
using System.Collections.Generic;
using System.Text;

public class SubtractionStrategy : ICalculationStrategy
{
    public int Calculate(int leftOperand, int rightOperand)
    {
        return leftOperand - rightOperand;
    }
}