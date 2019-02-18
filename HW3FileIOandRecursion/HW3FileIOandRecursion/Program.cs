// Ben Martin
// CS 3020
// 2/18/2019
// HW3: File IO and Recursion

using System;
using System.IO;

namespace HW3FileIOandRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"data.txt";      // Path for the file that reads in the directory to search
            StreamReader sr;                                                        // Creates StreamReader object to later be instantiated within the loop
            Console.WriteLine("***** Welcome to File Replicator! *****");
            Console.WriteLine("Please enter the directory of the files you would like to replicate in data.txt");
            Console.WriteLine("This file can be found at " + AppDomain.CurrentDomain.BaseDirectory + "\n");
            Console.Write("What filetype would you like to search for? (0 to exit) ");
            string filetype = Console.ReadLine();               // Gets user input for the filetype to search for

            while (filetype != "0")
            {
                sr = new StreamReader(path);                    // Instantiating the StreamReader inside the loop allows it to start from the top of data.txt when a new filetype is chosen
                string line;
                using (sr)
                {
                    while ((line = sr.ReadLine()) != null)      // Calls the SearchFiles method for each directory in data.txt
                    {
                        SearchFiles(line, filetype);
                    }
                }
                Console.WriteLine("Program Complete.\n");       // Appears when the program has finished
                Console.Write("Select a new filetype, or 0 to exit: ");
                filetype = Console.ReadLine();                  // Gets user input to either search for a new filetype or terminate the program
            }
            Console.WriteLine("Program Terminated.");
            Console.ReadKey();
        }

        static void SearchFiles(string path, string filetype)
        {                                                                               // Technically this string could just be removed and inserted into Line 43 where the directory
            string dirpath = @AppDomain.CurrentDomain.BaseDirectory + @"Destination";   // is being created, but I decided to make it its own string to make the code more readable.
                                                                                        
            foreach (DirectoryInfo directory in new DirectoryInfo(path).GetDirectories())       // Goes through every directory within the specified path
            {
                Directory.CreateDirectory(dirpath);                                             // Creates a directory called Destination at dirpath

                string[] files = Directory.GetFiles(directory.FullName, "*" + filetype);        // String array holds all the file's names of type specified by the user
                foreach (string file in files)                                                  // Loops through every file in the directory
                {
                    Console.WriteLine("Found file " + file.Replace(directory.FullName + "\\", "") + " in " + directory.ToString()); // Prints to user what file was found and where it was located
                    File.Copy(file, AppDomain.CurrentDomain.BaseDirectory + "Destination" + file.Replace(directory.FullName, ""));  // Copies file to Desination directory 
                }
                SearchFiles(directory.FullName, filetype);          // Recursively calls SearchFiles to get files in nested directories
            }
        }
    }
}
