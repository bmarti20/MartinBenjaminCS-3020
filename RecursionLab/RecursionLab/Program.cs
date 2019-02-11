using System;
using System.IO;

namespace RecursionLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"FolderTree";
            findpath(path);
            Console.ReadKey();
        }

        static string findpath(string path)
        {

            foreach (DirectoryInfo directory in new DirectoryInfo(path).GetDirectories())
            {
                
                Console.WriteLine(directory.ToString());
            }
            return "whatever";
        }
    }
}
