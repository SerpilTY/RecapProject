using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI

    //SOLID
    //O: Open Closed Principle
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetAll()) 
            {
                Console.WriteLine("Car's Description: "+ item.Description);
            }

            foreach (var item in carManager.GetAllByBrandId(2))
            {
                Console.WriteLine("Car with selected Brand Id: " + item.BrandId +", Car's Brand: "+ item.Description);
            }

            foreach (var item in carManager.GetAllByColorId(3))
            {
                Console.WriteLine("Car with selected Color Id: " + item.ColorId + ", Car's Brand: " + item.Description);
            }
        }
    }
}
