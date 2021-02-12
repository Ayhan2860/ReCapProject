using Business.Concrete;
using Core.Entities;
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
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

           var addedColor = colorManager.Add(new Color { ColorName = "Mor" });
            Console.Write(addedColor.Message);
            //brandManager.Add(new Brand { BrandName = "Hyundai" });
            carManager.Add(new Car { CarName = "Hyundai", DailyPrice = 240, BrandId = 8, ColorId = 4, ModelYear = 2018, Description = "Hyundai Accent Düz Vites" });




            //foreach (var car in carManager.GetAll().Data)
            //{
            //    Console.WriteLine(car.CarName + " - " + car.DailyPrice);


            //}
            var carsId = carManager.GetById(2).Data;



            Console.WriteLine(carsId.CarName +"-" +carsId.DailyPrice +"-"+ carsId.Description);
            Console.WriteLine(carManager.GetById(2).Message);
            Console.ReadLine();

        }
    }
}
