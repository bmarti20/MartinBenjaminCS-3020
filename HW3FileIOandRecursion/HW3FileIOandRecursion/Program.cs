using System;
using System.IO;

namespace HW3FileIOandRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            string filetype;
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Pictures";
            Console.Write("Please enter what file type you would like to search for: ");
            filetype = Console.ReadLine();
            path += @"\*." + filetype;
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                    Console.WriteLine(line);
            }
            Console.ReadKey();
        }
    }
}
