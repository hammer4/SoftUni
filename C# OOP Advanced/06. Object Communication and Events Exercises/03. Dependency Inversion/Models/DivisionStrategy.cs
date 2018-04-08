using System;
using System.Collections.Generic;
using System.Text;

public class DivisionStrategy : ICalculationStrategy
{
    public int Calculate(int leftOperand, int rightOperand)
    {
        return leftOperand / rightOperand;
    }
}