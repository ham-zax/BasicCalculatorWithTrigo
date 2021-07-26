using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Calculator
    {

        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.

            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            return result;
        }
        public static double DoTrigoOperation(double num1,string top)
        {
            double result = double.NaN;

            // Use a switch statement to do the math.
            switch (top)
            {
                case "si":
                    result = Math.Asin(num1);
                    break;
                case "s":
                    result = Math.Sin(num1);
                    break;
                case "sh":
                    result = Math.Sinh(num1);
                    break;
                case "ci":
                    result = Math.Acos(num1);
                    break;
                case "c":
                    result = Math.Cos(num1);
                    break;
                case "ch":
                    result = Math.Cosh(num1);
                    break;

                case "ti":
                    result = Math.Atan(num1);
                    break;
                case "t":
                    result = Math.Tan(num1);
                    break;
                case "th":
                    result = Math.Tanh(num1);
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
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                Console.WriteLine("Choose the operation type:");
                Console.WriteLine("\tb - Basic Operation");
                Console.WriteLine("\tt - Trignometric Operation");
                Console.WriteLine("\tPress any other key and Enter to Exit");
                Console.Write("Your option? ");

                string OPtype = Console.ReadLine();
                if (OPtype == "b")
                {
                    // Ask the user to type the first number.
                    Console.Write("Type a number, and then press Enter: ");
                    numInput1 = Console.ReadLine();

                    double cleanNum1 = 0;
                    while (!double.TryParse(numInput1, out cleanNum1))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput1 = Console.ReadLine();
                    }

                    // Ask the user to type the second number.
                    Console.Write("Type another number, and then press Enter: ");
                    numInput2 = Console.ReadLine();

                    double cleanNum2 = 0;
                    while (!double.TryParse(numInput2, out cleanNum2))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput2 = Console.ReadLine();
                    }

                    // Ask the user to choose an operator.
                    Console.WriteLine("Choose an operator from the following list:");
                    Console.WriteLine("\ta - Add");
                    Console.WriteLine("\ts - Subtract");
                    Console.WriteLine("\tm - Multiply");
                    Console.WriteLine("\td - Divide");
                    Console.Write("Your option? ");

                    string op = Console.ReadLine();

                    try
                    {
                        result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("This operation will result in a mathematical error.\n");
                        }
                        else Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                    }

                    Console.WriteLine("------------------------\n");

                    // Wait for the user to respond before closing.
                    Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                    if (Console.ReadLine() == "n") endApp = true;

                    Console.WriteLine("\n"); // Friendly linespacing.
                }
            else if (OPtype == "t")
                {
                    Console.Write("Type a number, and then press Enter: ");
                    numInput1 = Console.ReadLine();

                    double cleanNum1 = 0;
                    while (!double.TryParse(numInput1, out cleanNum1))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput1 = Console.ReadLine();
                    }
                    Console.WriteLine("Choose a trignometric function from the following list:");
                    Console.WriteLine("\tsi - Sin Inverse");
                    Console.WriteLine("\t s - Sin");
                    Console.WriteLine("\tsh - Sin Hyperbolic\r");
                    Console.WriteLine("------------------------\n");
                    Console.WriteLine("\tci - Cos Inverse");
                    Console.WriteLine("\t c - Cos");
                    Console.WriteLine("\tch - Cos Hyperbolic\r");
                    Console.WriteLine("------------------------\n");
                    Console.WriteLine("\tti - Tan Inverse");
                    Console.WriteLine("\t t - Tan");
                    Console.WriteLine("\tth - Tan Hyperbolic\r");
                    Console.WriteLine("------------------------\n");
                    Console.Write("Your option? ");
                    string top = Console.ReadLine();
                    try
                    {
                        result = Calculator.DoTrigoOperation(cleanNum1, top);
                        Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                    }

                    Console.WriteLine("------------------------\n");

                    // Wait for the user to respond before closing.
                    Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                    if (Console.ReadLine() == "n") endApp = true;

                    Console.WriteLine("\n"); // Friendly linespacing.

                }

                return;
            }
        }
    }
}