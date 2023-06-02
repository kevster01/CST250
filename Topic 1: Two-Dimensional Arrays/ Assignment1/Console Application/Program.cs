using CarClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopConsoleApp
{
    public class Program
    {
        static Store CarStore = new Store();
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Welcome to the car store. First you must create some cars and put them into " +
                "the store inventory. Then you may add cars to the cart. Finally, you may checkout, which will calculate your total bill.");
            int action = chooseAction();
            while (action != 0)
            {
                try
                {
                    switch (action)
                    {
                        case 1:
                            Console.Out.WriteLine("You choose to add a new car to the store");

                            int carYear = 0;
                            String carMake = "";
                            String carModel = "";
                            String carColor = "";
                            decimal carPrice = 0;

                            Console.Out.Write("What year is the car?  ");
                            carYear = int.Parse(Console.ReadLine());

                            Console.Out.Write("What is the car make?  ");
                            carMake = Console.ReadLine();

                            Console.Out.Write("What is the car model?  ");
                            carModel = Console.ReadLine();

                            Console.Out.Write("What Color is the color of the car? ");
                            carColor = Console.ReadLine();

                            Console.Out.Write("What is the car price? Only numbers please ");
                            carPrice = int.Parse(Console.ReadLine());


                            //create new car object & add to the list

                            Car newCar = new Car();
                            newCar.Year = carYear;
                            newCar.Make = carMake;
                            newCar.Model = carModel;
                            newCar.Color = carColor;
                            newCar.Price = carPrice;
                            CarStore.CarList.Add(newCar);
                            printStoreInventory(CarStore);

                            break;

                        case 2:

                            //You chose buy a car
                            printStoreInventory(CarStore);

                            //ask for a car number to purchase
                            int choice = 0;
                            Console.Out.Write("Which car would you like to add to the cart? (number)");
                            choice = int.Parse(Console.ReadLine());

                            //add the car to the shopping cart
                            CarStore.ShoppingList.Add(CarStore.CarList[choice]);

                            printShoppingCart(CarStore);
                            break;

                        case 3:
                            //Checkout
                            printShoppingCart(CarStore);
                            Console.Out.WriteLine("Your total cost is ${0}", CarStore.checkout());

                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine("Error has occured"); 
                }

                    
                action = chooseAction();
            }
           
        }

        static public int chooseAction()
        {
                int choice = 0;
                Console.Out.WriteLine("Choose an action (0) quit (1) add a car (2) add item to cart (3) chechout");
                choice = int.Parse(Console.ReadLine());
                return choice;
           
 
        }

        static public void printStoreInventory(Store carStore)
        {
            Console.Out.WriteLine("These are the cars in the store inventory");
            int i = 0;
            foreach (var c in carStore.CarList)
            {
                Console.Out.WriteLine(String.Format("Car # = {0} {1} ", i, c.Display));
                i++;
            }
        }

        static public void printShoppingCart(Store carStore)
        {
            Console.Out.WriteLine("These are the cars in your shopping cart: ");
            int i = 0;
            foreach (var c in carStore.ShoppingList)
            {
                Console.Out.WriteLine(String.Format("Car # = {0} {1} ", i, c.Display));
            }
        } 
    }
}
