using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarClassLibrary
{
    public class Car
    {

        //Car myNewSportsCar= new Car(2021, "Ford", "Mustang", "Red", 19500);

        //Car genericCar = new Car();

      public int Year { get; set; }
      public string Make { get; set; }
      public string Model { get; set; }
      public string Color { get; set; }
      public decimal Price { get; set;}
        

        

      public Car(int year, string make, string model, string color, decimal price)
      {
            Year = year;
            Make = make;
            Model = model;
            Color = color;
            Price = price;
      }

      public Car()
      {
            Year =0;
            Make = "Nothing Yet";
            Model = "Nothing Yet";
            Color = "Nothing Yet";
            Price = 0;      
      }

      public string Display
      {
            get
            {
                return string.Format("${0} {1} {2} {3} ${4}", Year, Make, Model, Color, Price);
            }
      }



    }
}
