namespace WebServer.ByTheCakeApplication.Controllers
{
    using Infrastructure;
    using Server.Http.Contracts;
    using System.Collections.Generic;

    public class CalculatorController : Controller
    {
        public IHttpResponse Calculate()
        {
            this.ViewData["result"] = string.Empty;

            return this.FileViewResponse(@"calculator\calculator");
        }

        public IHttpResponse Calculate(string number1, string number2, string mathOperator)
        {
            const string InvalidOperation = "Invalid operation!";
            const string InvalidSign = "Invalid sign!";
            var validOperators = new List<string> { "+", "-", "*", "/" };
            var result = string.Empty;

            if (!validOperators.Contains(mathOperator))
            {
                result = InvalidSign;
            }
            else
            {
                var num1 = decimal.Parse(number1);
                var num2 = decimal.Parse(number2);
                decimal calculationResult = 0;

                switch (mathOperator)
                {
                    case "+": calculationResult = num1 + num2; break;
                    case "-": calculationResult = num1 - num2; break;
                    case "*": calculationResult = num1 * num2; break;
                    case "/":
                        if (num2 == 0)
                        {
                            result = InvalidOperation; break;
                        }

                        calculationResult = num1 / num2; break;
                }

                if (result != InvalidOperation)
                {
                    result = calculationResult.ToString();
                }
            }

            this.ViewData["result"] = result;

            return this.FileViewResponse(@"calculator\calculator");
        }
    }
}
