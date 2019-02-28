using System;
using System.Collections.Generic;
using System.Text;

namespace HW5_Part_1
{
    class Property : IComparable<Property>
    {
        public string color;
        public int rent;
        public Property(string color, int rent)
        {
            this.color = color;
            this.rent = rent;
        }

        // This class is necessary for IComparable to work
        public int CompareTo(Property prop)
        {
            return rent.CompareTo(prop.rent);
        }
    }
}
