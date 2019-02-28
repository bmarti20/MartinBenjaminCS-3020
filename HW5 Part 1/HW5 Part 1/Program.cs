// Ben Martin
// CS 3020
// 


using System;
using System.Collections.Generic;
using System.Linq;

namespace HW5_Part_1
{
    class Program
    {
        static Property oriental = new Property("Blue", 100);
        static Property vermont = new Property("Blue", 120);
        static Property connecticut = new Property("Blue", 140);
        static Property stjames = new Property("Yellow", 180);
        static Property tennessee = new Property("Yellow", 200);
        static Property newyork = new Property("Yellow", 220);
        static Property atlantic = new Property("Red", 260);
        static Property ventnor = new Property("Red", 280);
        static Property marvin = new Property("Red", 300);
        static Property pacific = new Property("Green", 340);
        static Property carolina = new Property("Green", 360);
        static Property pennsylvania = new Property("Green", 380);

        static void Main(string[] args)
        {
            List<Property> props = new List<Property>{ ventnor, oriental, stjames, vermont, tennessee, atlantic, carolina, pennsylvania, connecticut, marvin, pacific, newyork };
            Console.WriteLine("You have a list of Property objects that all have 1 of 4 colors and a rent amount.");
            Console.WriteLine("Separate the list into 4 different lists based on color, then sort each list by increasing rent amount.");

            // Bad Way (using foreach loops and ifs)
            BadWay(props);
            // Good Way (using LINQ)
            GoodWay(props);
            Console.ReadKey();
        }

        static void BadWay(List<Property> props)
        {
            List<Property> reds = new List<Property>();
            foreach(Property prop in props)         // Loops through every object in the list and adds all the red ones to the new list
            {
                if (prop.color == "Red")
                    reds.Add(prop);
            }
            reds.Sort();                            // Sorts the list based on rent amount using IComparable

            List<Property> blues = new List<Property>();
            foreach (Property prop in props)         // Loops through every object in the list and adds all the blue ones to the new list
            {
                if (prop.color == "Blue")
                    blues.Add(prop);
            }
            blues.Sort();                            // Sorts the list based on rent amount using IComparable

            List<Property> yellows = new List<Property>();
            foreach (Property prop in props)         // Loops through every object in the list and adds all the yellow ones to the new list
            { 
                if (prop.color == "Yellow")
                    yellows.Add(prop);
            }
            yellows.Sort();                            // Sorts the list based on rent amount using IComparable

            List<Property> greens = new List<Property>();
            foreach (Property prop in props)         // Loops through every object in the list and adds all the green ones to the new list
            {
                if (prop.color == "Green")
                    greens.Add(prop);
            }
            greens.Sort();                            // Sorts the list based on rent amount using IComparable
        }

        static void GoodWay(List<Property> props)
        {
            // Uses LINQ to initialize each list by only taking the properties with the right color and ordering them by their rent
            List<Property> reds = props.Where(t => t.color == "Red").OrderBy(t => t.rent).ToList();
            List<Property> blues = props.Where(t => t.color == "Blue").OrderBy(t => t.rent).ToList();
            List<Property> yellows = props.Where(t => t.color == "Yellow").OrderBy(t => t.rent).ToList();
            List<Property> greens = props.Where(t => t.color == "Green").OrderBy(t => t.rent).ToList();

        }




        // Functions made for testing purposes
        static void PrintColors(List<Property> props)
        {
            foreach (Property prop in props)
                Console.WriteLine(prop.color);
        }

        static void PrintRent(List<Property> props)
        {
            foreach (Property prop in props)
                Console.WriteLine(prop.rent);
        }
    }
}
