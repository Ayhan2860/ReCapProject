using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
             CarTest();
            //ColorTest();
            //BrandTest();

        }









        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandId = 6, BrandName = "Citroen" });

            foreach (var brand in brandManager.GetBrandsAll())
            {
                Console.WriteLine($"{brand.BrandName} / {brand.BrandId}");
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color { ColorId = 6, ColorName = "Turuncu" });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.ColorName} / {color.ColorId}");
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { ColorId = 4, BrandId = 3, CarId = 6, CarName = "Cadillac", DailyPrice = 340, ModelYear = 2021, Description = "Cadillac X-T5" });
          
            //carManager.Delete(new Car { CarId = 8 });
            //carManager.Update(new Car { ColorId = 4, BrandId = 2, CarName="Mercedes",  CarId = 4, DailyPrice = 259, ModelYear = 2018, Description = "Mercedes-AMG A 35" });

            foreach (var car in carManager.GetCarsDetail())
            {
                Console.WriteLine(car.CarName);
                Console.WriteLine("#########################");
            }
        }
    }
}
