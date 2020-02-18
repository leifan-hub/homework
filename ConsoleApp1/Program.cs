using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculater_console
{
        class Calculator
        {
            public static double DoCalculate(double num1, double num2, string op)
            {
                double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.

                // Use a switch statement to do the math.
                switch (op)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        // Ask the user to enter a non-zero divisor.
                        while (num2 == 0)
                        {
                        Console.Write("This number can not be zero, please type another number:");
                        num2 = double.Parse(Console.ReadLine());
                        }
                    result = num1 / num2;
                    break;
                    default:
                        break;
                }
                return result;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                bool flag = false;
                // Display title as the C# console calculator app.
                Console.WriteLine("Welcome to Console Calculator \r");
                Console.WriteLine("------------------------\n");

                while (!flag)
                {
                    string numInput1 = "";
                    string numInput2 = "";
                    double result = 0;

                    // Ask the user to type the first number.
                    Console.Write("Please type a number, and then press Enter: ");
                    numInput1 = Console.ReadLine();

                    double cleanNum1 = 0;
                    while (!double.TryParse(numInput1, out cleanNum1))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput1 = Console.ReadLine();
                    }

                    // Ask the user to type the second number.
                    Console.Write("Please type another number, and then press Enter: ");
                    numInput2 = Console.ReadLine();

                    double cleanNum2 = 0;
                    while (!double.TryParse(numInput2, out cleanNum2))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput2 = Console.ReadLine();
                    }
                
                    // Ask the user to choose an operator.
                    Console.WriteLine("Choose an operator from the following list:");
                    Console.WriteLine("\t+ --- Add");
                    Console.WriteLine("\t- --- Subtract");
                    Console.WriteLine("\t* --- Multiply");
                    Console.WriteLine("\t/ --- Divide");

                    string op = Console.ReadLine();

                    try
                    {
                        result = Calculator.DoCalculate(cleanNum1, cleanNum2, op);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("This operation will result in a mathematical error.\n");
                        }
                        else Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An exception occurred trying to do the math.\n - Details: " + e.Message);
                    }
                    Console.Write("If you want to close the app, please press 'n' , or press any other key and Enter to continue: ");
                    if (Console.ReadLine() == "n") flag = true;

                    Console.WriteLine("\n");
                }
                return;
            }
        }
}
