using System;
using System.IO;
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
            Console.WriteLine("Hello World!");
            Console.WriteLine(props[0].color);
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
            foreach(Property prop in props)
            {
                if (prop.color == "Red")
                    reds.Add(prop);
            }

            List<Property> blues = new List<Property>();
            foreach (Property prop in props)
            {
                if (prop.color == "Blue")
                    blues.Add(prop);
            }

            List<Property> yellows = new List<Property>();
            foreach (Property prop in props)
            {
                if (prop.color == "Yellow")
                    yellows.Add(prop);
            }

            List<Property> greens = new List<Property>();
            foreach (Property prop in props)
            {
                if (prop.color == "Green")
                    greens.Add(prop);
            }
        }

        static void GoodWay(List<Property> props)
        {
            List<Property> reds = props.Where(t => t.color == "Red").ToList();
            List<Property> blues = props.Where(t => t.color == "Blue").ToList();
            List<Property> yellows = props.Where(t => t.color == "Yellow").ToList();
            List<Property> greens = props.Where(t => t.color == "Green").ToList();
        }
    }
}
