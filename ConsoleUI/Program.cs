using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            carManager.Add(new Car { BrandId = 3, CarId = 5, ColorId = 2, DailyPrice = 160, Description = "Fiat Egea 1.3 Multijet", ModelYear = 2109 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.BrandId} {car.CarId} {car.Description} {car.DailyPrice+" Tl"}");

            }

            Console.WriteLine("**********************************");


            
        }

        
    }
}
