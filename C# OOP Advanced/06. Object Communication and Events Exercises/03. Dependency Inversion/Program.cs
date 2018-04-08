using System;

class Program
{
    static void Main(string[] args)
    {
        ICalculator calculator = new Calculator(new AdditionStrategy());

        string input;

        while((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split();

            if(tokens[0] == "mode")
            {
                char @operator = Char.Parse(tokens[1]);
                ICalculationStrategy strategy = null;

                switch (@operator)
                {
                    case '+':
                        strategy = new AdditionStrategy();
                        break;
                    case '-':
                        strategy = new SubtractionStrategy();
                        break;
                    case '*':
                        strategy = new MultiplicationStrategy();
                        break;
                    case '/':
                        strategy = new DivisionStrategy();
                        break;
                }

                calculator.ChangeStrategy(strategy);
                
            }
            else
            {
                int left = int.Parse(tokens[0]);
                int right = int.Parse(tokens[1]);

                int result = calculator.PerformCalculation(left, right);
                Console.WriteLine(result);
            }
        }
    }
}