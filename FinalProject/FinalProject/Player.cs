using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Player
    {
        public string name;
        public int money, position, jailcounter, houses, hotels;
        public bool injail, outofjailfree, canbuyhouses;
        public int[] monopCounter = { 0, 0, 0, 0 };
        public bool[] monopOwned = { false, false, false, false };
        public List<Property> propsOwned = new List<Property>();

        public Player(string x, int y)   // Constructor that receives name and starting money. Sets initial position to 0
        {
            name = x;
            money = y;
            position = 0;
            jailcounter = 0;
            houses = 0;
            hotels = 0;
            injail = false;
            outofjailfree = false;
            canbuyhouses = false;
        }

        public void passGo()            // Prints out that player passed Go, adds $200 to money
        {
            money += 200;
            Console.WriteLine("{0} passed Go! {0} now has ${1}.", name, money);
        }

        public void setMoney(int x)     // Updates player's money and prints out their new amount
        {
            money += x;
            Console.WriteLine("{0} now has ${1}.", name, money);
        }

        public void setPosition(int x)      // Updates position and wraps around when passing Go
        {
            int prevposition = position;
            position = (position + x) % 19;
            if (prevposition > position)
            {
                passGo();
            }
        }

        public void goTo(int x)             // Sends player to a specific position while still checking to see if they pass go
        {
            int prevposition = position;
            position = x;
            if (prevposition > position)
            {
                passGo();
            }
        }

        public void goToJail()              // Sends a player to Jail and does not check if they pass go
        {
            position = 5;
            injail = true;

            if (outofjailfree)              // Get out of jail free card is consumed automatically and player is placed in just visiting
            {
                injail = false;
                outofjailfree = false;
                Console.WriteLine("{0} used their Get Out of Jail Free card and is no longer in Jail.", name);
            }
        }

        public void buyProp(Property prop)  // Buys the property player landed on
        {
            Console.WriteLine("{0} now owns {1}!", name, prop.name);
            prop.owner = name;
            setMoney(-prop.price);
            propsOwned.Add(prop);
            switch (prop.color)
            {
                case "blue": monopCounter[0]++; break;
                case "yellow": monopCounter[1]++; break;
                case "red": monopCounter[2]++; break;
                case "green": monopCounter[3]++; break;
                default: break;
            }
        }
    }
}
