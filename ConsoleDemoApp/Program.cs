﻿using System.Text.RegularExpressions;

namespace ConsoleDemoApp;

class Program 
{
    static void Main(string[] args)
    {
        bool endApplication = false;
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        while (!endApplication)
        {
            string? numInput1 = "";
            string? numInput2 = "";
            double result = 0;

            Console.Write("Type a number and then press Enter: ");
            numInput1 = Console.ReadLine();

            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("This is not a valid input. Please enter a numeric value: ");
                numInput1 = Console.ReadLine();
            }

            Console.Write("Type another number, then press Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("This is not a valid input. Please enter a numeric value: ");
                numInput2 = Console.ReadLine();
            }


            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.Write("Your option? ");

            string? op = Console.ReadLine();

            if (op == null || !Regex.IsMatch(op, "[a | s | m | d ]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else
            {
                try
                {
                    result = Calculator.Operation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in an error. \n");
                    }
                    else
                    {
                        Console.WriteLine("Yor result: {0:0.##}\n", result);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Oh no!! An exception has occurred trying to do math.\n - Details: " + exception.Message);
                }
            }

            Console.WriteLine("-----------------------------\n");
            Console.WriteLine("Press 'n' and Enter to close the app, or press any other key to continue: ");
            if (Console.ReadLine() == "n") endApplication = true;

            Console.WriteLine("\n");
        }

        return;
    }  
}
