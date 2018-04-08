using System;
using System.Collections.Generic;
using System.Text;

public interface ICalculator
{
    int PerformCalculation(int firstOperand, int secondOperand);

    void ChangeStrategy(ICalculationStrategy calculationStrategy);
}