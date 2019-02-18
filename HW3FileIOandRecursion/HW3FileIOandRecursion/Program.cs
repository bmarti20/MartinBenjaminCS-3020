using System;
using System.IO;

namespace HW3FileIOandRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"test.txt";
            StreamReader sr = new StreamReader(path);
            string filetype = sr.ReadLine();
            string line;
            using (sr)
            {
                while ((line = sr.ReadLine()) != null)
                {
                    SearchFiles(line);
                }
            }
            Console.ReadKey();
        }

        static void SearchFiles(string path)
        {
            foreach (DirectoryInfo directory in new DirectoryInfo(path).GetDirectories())
            {
                Console.WriteLine(directory.ToString());
                foreach (FileInfo file in new DirectoryInfo(directory.FullName).GetFiles())
                    Console.WriteLine(file.ToString());
                SearchFiles(directory.ToString());
            }
        }
    }
}
