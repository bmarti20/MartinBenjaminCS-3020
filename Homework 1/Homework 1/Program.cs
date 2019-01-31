using System;

namespace Homework_1
{
    class Program
    {
        public static void Main(string[] args)
        {
        
            int choice = 0;
            Console.WriteLine("***** Welcome to Program 1! *****\n");   // Displays  choices to user

            Start:
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("1. Fahrenheit to Celsius");
            Console.WriteLine("2. Volume of a Sphere");
            Console.WriteLine("3. Multiple of 3 or 5");
            Console.WriteLine("4. Palindrome");
            Console.WriteLine("5. Exit Program");

            while (choice != 5)     // Loops until the user chooses to exit the program
            {
                if (!int.TryParse(Console.ReadLine(), out choice))      // Catches any invalid input and prompts user to input the correct format
                {
                    Console.WriteLine("Invalid input. Please choose a number between 1 and 5.");
                    goto Start;
                }

                switch (choice)                 // Directs user to the proper method based on their choice
                {
                    case 1: temp(); break;
                    case 2: sphere(); break;
                    case 3: mult(); break;
                    case 4: palin(); break;
                    case 5: break;
                }
            }
        }

        private static void temp()
        {
        Temp:
            double temp = 0;
            Console.Write("Enter the temperature in Fahrenheit: ");

            if (!double.TryParse(Console.ReadLine(), out temp)) // Checks for invalid input
            {
                Console.WriteLine("Invalid input. Please enter a valid temperature.");
                goto Temp;
            }

            temp = (temp - 32) * (5.0 / 9.0);               // Converts temp to Fahrenheit
            Console.WriteLine("The temperature is {0} degrees Celsius.", temp.ToString("0.#")); // Formats decimal to 1 floating point
        }

        public static void sphere()
        {

        }

        public static void mult()
        {

        }

        public static void palin()
        {

        }
    }
}
