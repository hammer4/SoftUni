namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInteger);
            BlackBoxInteger instance = (BlackBoxInteger)Activator.CreateInstance(classType, true);
            string command;

            while((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split('_');
                string methodName = tokens[0];
                int value = int.Parse(tokens[1]);

                classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Invoke(instance, new object[] { value });

                int currentValue = (int)classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .GetValue(instance);

                Console.WriteLine(currentValue);
            }
        }
    }
}
