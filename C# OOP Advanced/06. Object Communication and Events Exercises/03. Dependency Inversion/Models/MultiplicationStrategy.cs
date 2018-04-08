using System;
using System.Collections.Generic;
using System.Text;

public class MultiplicationStrategy : ICalculationStrategy
{
    public int Calculate(int leftOperand, int rightOperand)
    {
        return leftOperand * rightOperand;
    }
}