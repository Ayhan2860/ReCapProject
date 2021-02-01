using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.BrandId} {car.CarId} {car.Description} {car.DailyPrice+" Tl"}");
            }
        }

        
    }
}
