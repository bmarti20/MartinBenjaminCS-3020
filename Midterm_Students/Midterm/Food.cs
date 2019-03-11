using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    class Food : VendingMachineOption
    {
        public float Consistency { get; private set; }
        public int ScovilleScale { get; private set; }
        public int CalorieCount { get; private set; }
        public bool IsVegetarian { get; private set; }

        public Food(string name, float price, int quantity, int calorieCount, float consistency, int scovilleScale, bool isVegetarian)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Consistency = consistency;
            ScovilleScale = scovilleScale;
            CalorieCount = calorieCount;
            IsVegetarian = isVegetarian;
        }
    }
}
