using System;
using System.IO;

namespace RecursionLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"FolderTree";
            Console.WriteLine(findpath(path));
            Console.ReadKey();
        }

        static string findpath(string path)
        {

            foreach (DirectoryInfo directory in new DirectoryInfo(path).GetDirectories())
            {
                if (directory.GetFiles() == null)
                    return path;
                else
                    return findpath(directory.ToString());
            }
            return "finished";
        }
    }
}
