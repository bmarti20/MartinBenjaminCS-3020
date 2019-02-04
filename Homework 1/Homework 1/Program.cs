using System;

namespace Homework_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            int choice = 0;
            Console.WriteLine("***** Welcome to Program 1! *****");   // Displays  choices to user

            Start:
            while (choice != 5)     // Loops until the user chooses to exit the program
            {
                Console.WriteLine("\nPlease select an option: ");
                Console.WriteLine("1. Fahrenheit to Celsius");
                Console.WriteLine("2. Volume of a Sphere");
                Console.WriteLine("3. Multiple of 3 or 5");
                Console.WriteLine("4. Palindrome");
                Console.WriteLine("5. Exit Program");

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
            Console.ReadKey();
        }

        public static void sphere()
        {
        Sphere:
            double radius = 0;
            Console.Write("Enter the radius of the sphere (in inches): ");

            if (!double.TryParse(Console.ReadLine(), out radius)) // Checks for invalid input
            {
                Console.WriteLine("Invalid input. Please enter a valid radius.");
                goto Sphere;
            }

            radius = 4/3 * 3.14159 * Math.Pow(radius, 3);       // Calculates the volume of the sphere
            Console.WriteLine("The volume of the sphere is {0} cubic inches.", radius.ToString("0.#"));
            Console.ReadKey();
        }

        public static void mult()
        {
        Mult:
            int input = 0;
            Console.Write("Please enter an integer greater than 0: ");

            if (!int.TryParse(Console.ReadLine(), out input)) // Checks for invalid input
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                goto Mult;
            }
            if (input < 0)      // Checks to make sure that input is a positive number
            {
                Console.WriteLine("Invalid input. Number must be greater than zero.");
                goto Mult;
            }

            Console.WriteLine("All multiples of 3 and 5 between 0 and {0}:", input);
            for (int i = 1; i <= input; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)       // If value of i is a multiple of either 3 or 5, then it prints out onto the line
                    Console.Write("{0} ", i);
            }
            Console.ReadLine();                     // Empty line of whitespace because I'm picky about my formatting
            Console.ReadKey();
        }

        public static void palin()
        {
            string input = "";
            Console.WriteLine("Please enter a string: ");
            input = Console.ReadLine();             // Gets string from user
            char[] cArray = input.ToCharArray();
            Array.Reverse(cArray);                  // Reverses string
            string output = new string(cArray);
                
            if (input == output)                    // Checks if reversed string is the same as initial string
                Console.WriteLine("Your string is a palindrome!");
            else
                Console.WriteLine("Your string is not a palindrome.");
            Console.ReadKey();
        }
    }
}
