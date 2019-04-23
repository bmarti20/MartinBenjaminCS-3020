using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Player
    {
        public string name;
        public int money, position;

        public Player(string name, int money)
        {
            this.name = name;
            this.money = money;
            position = 0;
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

        public void changePosition(int x)      // Updates position and wraps around when passing Go
        {
            int prevposition = position;
            position = (position + x) % 19;
            if (prevposition > position)
            {
                passGo();
            }
        }

        public void setPosition(int x)             // Sends player to a specific position while still checking to see if they pass Go
        {
            int prevposition = position;
            position = x;
            if (prevposition > position)
            {
                passGo();
            }
        }
    }
}
