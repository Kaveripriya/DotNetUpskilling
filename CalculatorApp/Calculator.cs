using System;

namespace CalculatorApp
{
    static class Calculator
    {
        public static void Start()
        {
            while (true)
            {
                double num1 = GetNumber("Enter the first Number");
                double num2 = GetNumber("Enter the second Number");
                char operation = GetOperation();

                double result = CalculateResult(num1,num2, operation);
                Console.WriteLine("Result : " +result);

                if (!WantToContinue())
                    break;
            }
        }

        static double GetNumber(string message)
        {
            double number;
            while(true)
            {
                Console.WriteLine(message);
                if (double.TryParse(Console.ReadLine(), out number))
                    return number;
                else
                    Console.WriteLine("Invalid Input. Pls enter valid number");
            }
        }

        static char GetOperation()
        {
            while(true)
            {
                Console.WriteLine("Select an operation( +,-): ");
                char operation = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (operation == '+' || operation == '-')
                    return operation;
                else
                    Console.WriteLine("Invalid Operation");
            }
        }

        static double CalculateResult(double num1, double num2, char operation)
        {
            switch(operation)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                default:
                    Console.WriteLine("Invalid operation");
                    return double.NaN;

            }
        }

        static bool WantToContinue()
        {
            while(true)
            {
                Console.WriteLine("Do you want to perform another operation (Y/N)");
                char choice=char.ToUpper(Console.ReadKey().KeyChar);

                Console.WriteLine();

                if (choice == 'Y')
                    return true;
                else if (choice == 'N')
                    return false;
                else
                    Console.WriteLine("Invalid choice");
            }
        }
    }
}
