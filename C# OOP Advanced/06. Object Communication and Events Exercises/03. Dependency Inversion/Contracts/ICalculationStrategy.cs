using System;
using System.Collections.Generic;
using System.Text;

public interface ICalculationStrategy
{
    int Calculate(int leftOperand, int rightOperand);
}