using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Consumable : VendingMachineOption
    {
        public int CalorieCount { get; private set; }
        public bool IsVegetarian { get; private set; }

        public Consumable(string name, float price, int quantity, int calorieCount, bool isVegetarian)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            CalorieCount = calorieCount;
            IsVegetarian = isVegetarian;
        }
    }
}
