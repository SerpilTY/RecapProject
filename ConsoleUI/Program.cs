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
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

             customerManager.Add(new Customer {
             CompanyName="North Star Inc."
             });
            

           /* UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User
            {
                Email = "asd@asd.com",
                FirstName = "Serpil",
                LastName="TY",
                Password="1234",
                UserId=1
                
            }) ; 
            */


            // CarTest();

            //BrandTest();

            //ColorTest();
        }
    


        private static void CarTest()
        {
            Car myCar = new Car
            {
                BrandId = 4,
                ColorId = 3,
                ModelYear = "2009",
                DailyPrice = 198000,
                Description = "Mercedes A Series"
            };

            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(myCar);   //..Commented because always adding and adding..

            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(
                               "Car's Description: " + item.ModelName + " \n" +
                               "Car's Brand Name: " + item.BrandName + " \n" +
                               "Car's Color: " + item.ColorName + " \n" +
                               "Car's Daily Price: " + item.DailyPrice + " \n" +
                               "******************************************"
                        );
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }
    }
}
