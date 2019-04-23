using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Property
    {
        public string name;
        public int price, rent, housePrice, position, numHouses;
        public string owner, color;

        public Property(string name, int price, int rent, int housePrice, int position, string color)
        {
            this.name = name;
            this.price = price;
            this.rent = rent;
            this.housePrice = housePrice;
            this.position = position;
            this.color = color;
            owner = "Unowned";
            numHouses = 0;
        }
    }
}
