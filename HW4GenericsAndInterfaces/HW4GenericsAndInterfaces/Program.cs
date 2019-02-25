using System;
using System.Collections.Generic;
using System.IO;

namespace HW4GenericsAndInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("***** Welcome to the Media Manager! *****\n");

        choose:
            Console.WriteLine("Please choose an option: ");
            Console.WriteLine("1. Scan for Videos");
            Console.WriteLine("2. Scan for Audio");
            Console.WriteLine("3. Scan for Images");
            Console.WriteLine("4. Scan for all");
            Console.WriteLine("5. Access video library");
            Console.WriteLine("6. Access audio library");
            Console.WriteLine("7. Access image library");
            Console.WriteLine("8. Close Program");

            if (!int.TryParse(Console.ReadLine(), out choice)) // Checks for invalid input
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                goto choose;
            }
            switch (choice)
            {
                case 1: break;
                case 2: break;
                case 3: break;
                case 4: break;
                case 5: break;
                case 6: break;
                case 7: break;
                case 8:
                    Console.WriteLine("Program Terminated.");
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 8.");
                    goto choose;
            }
            Console.ReadKey();
        }

        
    }
}
