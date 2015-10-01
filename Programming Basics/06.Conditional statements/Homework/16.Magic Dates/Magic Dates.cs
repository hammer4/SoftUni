using System;

class MagicDates
{
    static void Main()
    {
        System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CreateSpecificCulture("bg-BG");
        System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culture;
        int startYear = int.Parse(Console.ReadLine());
        int endYear = int.Parse(Console.ReadLine());
        int magicWeight = int.Parse(Console.ReadLine());
        int counter = 0;
        for (int k = startYear; k <= endYear; k++)
            for (int j = 1; j <= 12; j++)
                for (int i = 1; i <= 31; i++)
                           
                {
                    int number = i * 1000000 + j * 10000 + k;
                    int h = number % 10;
                    int g = number / 10 % 10;
                    int f = number / 100 % 10;
                    int e = number / 1000 % 10;
                    int d = number / 10000 % 10;
                    int c = number / 100000 % 10;
                    int b = number / 1000000 % 10;
                    int a = number / 10000000;

                    int p = a*b + a*c + a*d + a*e + a*f + a*g + a*h + b*c + b*d + b*e + b*f + b*g + b*h + c*d+c*e+c*f+c*g+c*h+d*e+d*f+d*g+d*h+e*f+e*g+e*h+f*g+f*h+g*h;

                    if (p == magicWeight)
                    {
                        string numberToDate = number.ToString();
                        System.Text.StringBuilder sb = new System.Text.StringBuilder(numberToDate);
                        sb.Insert(numberToDate.Length - 4, "-");
                        sb.Insert(numberToDate.Length - 6, "-");
                        numberToDate = sb.ToString();
                        DateTime date;
                        bool isDate = DateTime.TryParse(numberToDate, out date);
                        if (isDate == true)
                        {
                            Console.WriteLine("{0:dd-MM-yyyy}", date);
                            counter++;
                        }
                    }
                }
        if (counter == 0)
            Console.WriteLine("No");
    }
}
