using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add( new Car { BrandId = 5, CarId = 7, ColorId = 5, DailyPrice = 0, Description = "", ModelYear = 2015 });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.BrandId} {car.CarId} {car.Description} {car.DailyPrice+" Tl"}");

            }

            Console.WriteLine("**********************************");


            
        }

        
    }
}
