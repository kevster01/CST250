using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopGui
{
    public class Store
    {
        public List<Car> CarList { get; set; }
        public List<Car> ShoppingList { get; set; }

        public Store() 
        { 
            CarList = new List<Car>();
            ShoppingList = new List<Car>(); 
        }

        public decimal checkout()
        {
            decimal totalCost = 0;
            //Caculating total cost of items in shopping list
            foreach (var c in ShoppingList)
            {
                totalCost += c.Price;
            }
            //Clear the shopping cart
            ShoppingList.Clear();

            //return total
            return totalCost;
        }
    }
}
