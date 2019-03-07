using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LINQProblems
{
    public class Program
    {
        static void Main(string[] args)
        {
            FindStringsInAThatArentInB();           // Done
            GetStraightAStudents();                 // Done
            DetermineWhichItemWasMostProfitable();
            QueryPhoneBookEntries();
            GetAllPNG(@"C:\Users\Ryan\Pictures\"); //NOTE: READ SUMMARY COMMENT ABOVE METHOD
            GetFibonacciNumbers();
            SumPrimes();
            Console.ReadKey();
            return;
        }

        /// <summary>
        /// Result should equal any string in a that isn't also in b.
        /// Result = { "y", "n" }
        /// </summary>
        public static List<string> FindStringsInAThatArentInB()
        {
            List<string> a = new List<string>() { "r", "y", "a", "n" };
            List<string> b = new List<string>() { "d", "a", "r", "r", "a", "s" };
            List<string> result = a.Except(b).ToList();
            foreach (string str in result)
                Console.WriteLine(str);

            // for (int i = 0; i < a.Count; i++)
            // {
            //     int exists = 0;
            //     for (int j = 0; j < b.Count; j++)
            //     {
            //         if (b[j] == a[i])
            //         {
            //             exists = 1;
            //         }
            //     }
            //     if (exists == 0)
            //     {
            //         result.Add(a[i]);
            //     }
            // }
            return result;
        }

        /// <summary>
        /// Gets a subset of students that maintain all A's.
        /// Result = { 2, 6, 8 }
        /// </summary>
        public static List<Student> GetStraightAStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student(1, 87, 89, 91, 92),
                new Student(2, 90, 92, 93, 99),
                new Student(3, 87, 91, 97, 100),
                new Student(4, 86, 88, 93, 100),
                new Student(5, 86, 89, 94, 98),
                new Student(6, 93, 94, 99, 100),
                new Student(7, 87, 89, 95, 99),
                new Student(8, 91, 94, 95, 97),
                new Student(9, 85, 94, 99, 100),
                new Student(10, 85, 92, 93, 95),
            };

            List<Student> a_students = students.Where(t => t.MathGrade >= 90 && t.ScienceGrade >= 90 && t.EnglishGrade >= 90 && t.HistoryGrade >= 90).ToList();
            foreach (Student str in a_students)
                Console.WriteLine(str.StudentID);

            // foreach (Student s in students)
            // {
            //     if (s.MathGrade >= 90.0
            //         && s.HistoryGrade >= 90.0
            //         && s.ScienceGrade >= 90.0
            //         && s.EnglishGrade >= 90.0)
            //             a_students.Add(s);
            // }
            return a_students;
        }



        /// <summary>
        /// Determines which item profited the most
        /// </summary>
        public static Item DetermineWhichItemWasMostProfitable()
        {
            List<Item> items = new List<Item>()
            {
                new Item("TV", 5, 515.15f),
                new Item("DVD Player", 10, 100.05f),
                new Item("Toy Horse", 2, 25.25f),
                new Item("Shovel", 1, 10.99f),
                new Item("Kite", 4, 5.77f),
                new Item("Stapler", 15, 5.98f),
                new Item("Pen", 25, 2.25f),
                new Item("Candy Bar", 102, 1.5f),
                new Item("DVD", 45, 20),
                new Item("Soda", 66, 1.5f),
            };

            Item highestEarner = new Item("TEMP", 0, 0);
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ItemPrice * items[i].NumberOfSales > highestEarner.ItemPrice * highestEarner.NumberOfSales)
                {
                    highestEarner = items[i];
                }
            }
            return highestEarner;
        }

        /// <summary>
        /// Queries various things from a phone book
        /// </summary>
        public static Dictionary<string, List<PhoneBookEntry>> QueryPhoneBookEntries()
        {
            List<PhoneBookEntry> phoneBook = new List<PhoneBookEntry>()
            {
                new PhoneBookEntry("Sarah", "Jones", "1887 Flat Iron Court", "Colorado Springs", "CO", "80921", "(719) 354-1857"),
                new PhoneBookEntry("Josh", "Jones", "1887 Flat Iron Court", "Colorado Springs", "CO", "80921", "(719) 354-1855"),
                new PhoneBookEntry("Bryan", "Adams", "1665 Snowflake Lane", "Boston", "MA", "02101", "(617) 143-1566"),
                new PhoneBookEntry("John", "Smith", "4745 Meadowland Blvd", "San Diego", "CA", "22434", "(619) 354-6543"),
                new PhoneBookEntry("Josh", "Jackson", "1145 Piros Drive", "Orlando", "FL", "32789", "(407) 650-8333"),
                new PhoneBookEntry("Hannah", "Maben", "1710 Main Street", "Boston", "MA", "02101", "(617) 765-1857"),
                new PhoneBookEntry("Harrison", "James", "1010 Maple Lane", "Denver", "CO", "80014", "(720) 123-4567"),
                new PhoneBookEntry("Xavier", "Carlyle", "1552 Washington Avenue", "San Diego", "CA", "22434", "(619) 987-5465"),
                new PhoneBookEntry("Michael", "Jones", "6510 Cherry Creek Lane", "Springfield", "TX", "75853", "(361) 234-985"),
                new PhoneBookEntry("Sarah", "Smith", "1223 Mirage Drive", "Springfield", "TX", "75853", "(361) 127-5643"),
            };

            Dictionary<string, List<PhoneBookEntry>> results = new Dictionary<string, List<PhoneBookEntry>>();


            results.Add("Name", new List<PhoneBookEntry>());
            foreach (PhoneBookEntry entry in phoneBook)
            {
                if (entry.Name == "Josh Jackson")
                    results["Name"].Add(entry);
            }

            results.Add("LastName", new List<PhoneBookEntry>());
            foreach (PhoneBookEntry entry in phoneBook)
            {
                if (entry.LastName == "Jones")
                    results["LastName"].Add(entry);
            }

            results.Add("City", new List<PhoneBookEntry>());
            foreach (PhoneBookEntry entry in phoneBook)
            {
                if (entry.City == "Colorado Springs")
                    results["City"].Add(entry);
            }

            results.Add("PhoneAreaCode", new List<PhoneBookEntry>());
            foreach (PhoneBookEntry entry in phoneBook)
            {
                if (entry.PhoneNumber.Substring(0, 3) == "617")
                    results["PhoneAreaCode"].Add(entry);
            }
            return results;
        }

        /// <summary>
        /// HW 3. Finds all jpgs in the given path
        /// 
        /// You will need to change your path in multiple locations to test this.
        /// 1. In Main of this file.
        /// 2. In GetAllPNG_Test in LINQProblems_Test_Cases.cs
        /// 
        /// PLEASE CHANGE BOTH BACK TO @"C:\Users\Ryan\Pictures\" WHEN YOU FINALIZE AND SUMBIT!!!!
        /// </summary>
        public static List<FileInfo> GetAllPNG(string path)
        {
            /* Hints for this problem:
             * new DirectoryInfo(path).EnumerateDirectories("*", SearchOption.AllDirectories);
             * directory.EnumerateFiles("*.png")
             * 
             * However, the enumerated method above might throw exceptions on files that cannot be accessed.
             * To solve this, just test on a path that you know is safe.
             */

            List<FileInfo> files = new List<FileInfo>();
            foreach (DirectoryInfo directory in new DirectoryInfo(path).GetDirectories())
            {
                files.AddRange(GetAllPNG(directory.FullName));
            }

            foreach (FileInfo file in new DirectoryInfo(path).GetFiles("*.png"))
            {
                files.Add(file);
            }
            return files;
        }

        /// <summary>
        /// Gets the fibonacci numbers for a list of integers
        /// </summary>
        public static List<int> GetFibonacciNumbers()
        {
            List<int> input = new List<int>();
            for (int i = 1; i < 40; i += 5)
                input.Add(i);
            List<int> results = new List<int>();
            
            foreach(int i in input)
            {
                results.Add(Fibonacci(i));
            }
            
            //Local function for recursive search
            int Fibonacci(int i)
            {
                if (i == 1 || i == 2)
                    return 1;
                return Fibonacci(i - 1) + Fibonacci(i - 2);
            }
            return results;
        }

        /// <summary>
        /// Finds and sums the values of all primes between 2 and 1,000
        /// Result = 76,127
        /// </summary>
        public static int SumPrimes()
        {
            int primeSum = 0;
            for (int i = 2; i < 1000; i++)
            {
                bool isPrime = true;
                for (int c = 2; c < i / 2 + 1; c++)
                {
                    if (i % c == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime == true)
                {
                    primeSum += i;
                }
            }
            return primeSum;
        }
    }
}
