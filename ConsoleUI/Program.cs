using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI

    //SOLID
    //O: Open Closed Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();

            //BrandTest();

            //ColorTest();
        }

        private static void CarTest()
        {
            Car myCar = new Car { 
            BrandId=4,
            ColorId=3,
            ModelYear="2009",
            DailyPrice=198000,
            Description="Mercedes A Series"
            };

            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(myCar);

            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(
                           "Car's Description: " + item.CarName + " \n" +
                           "Car's Brand Name: " + item.BrandName + " \n" +
                           "Car's Color: " + item.ColorName + " \n" +
                           "Car's Daily Price: " + item.DailyPrice + " \n" +
                           "******************************************"
                    );
            }

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

       
            
    }
}
