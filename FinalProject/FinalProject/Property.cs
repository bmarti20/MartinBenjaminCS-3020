using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Property
    {
        public string name;
        public int price, rent, housePrice, position, numhouses;
        public string owner, color;
        public bool mortgaged;

        public Property(string str, int x, int y, int z, int pos, string col)   // Constructor gets name, price, rent, house price, and position of properties. 
        {
            name = str;
            price = x;
            rent = y;
            housePrice = z;
            position = pos;
            owner = "Unowned";
            color = col;
            numhouses = 0;
            mortgaged = false;
        }

        public void buildHouse(Player player)
        {
            if (numhouses == 5)     // Will not let player build more than 4 houses and a hotel
                Console.WriteLine("You have already built 4 houses and a Hotel here, you cannot build any more.");
            else if (player.money < housePrice)     // Will not let player buy houses if they don't have enough money
                Console.WriteLine("You don't have enough money.");
            else
            {
                player.setMoney(-housePrice);       // Player pays for the house and updates the rent depending on which house they buy
                switch (numhouses)               // I had to assess for myself what would be a balanced amount for rent increases. Normal Monopoly has these values a bit higher, but I scaled them down for Minipoly
                {
                    case 0: rent *= 3; player.houses++; break;       // First House - Rent increases by 3x
                    case 1: rent *= 2; player.houses++; break;       // Second House - Rent increases by 2x
                    case 2: rent *= 2; player.houses++; break;       // Third House - Rent increases by 2x
                    case 3: rent = rent * 3 / 2; player.houses++; break;   // Fourth House - Rent increases by 1.5x
                    case 4: rent *= 2; player.hotels++; break;       // Hotel - Rent increases by 2x
                    default: break;
                }
                numhouses++;
                if (numhouses == 5)
                {
                    Console.WriteLine("You built a hotel on {0}! Rent is now ${1}.", name, rent);
                    name += "*";
                }
                else
                {
                    Console.WriteLine("You built a house on {0}! Rent is now ${1}.", name, rent);
                    name += "+";
                }
            }
        }
    }
}
