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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //CarManagerTest(carManager);
            //ColorManagerTest(colorManager);
            //BrandManagerTest(brandManager);
            //UserManagerTest(userManager);
            //CustomerManagerTest(customerManager);

            //var result = rentalManager.Add(new Rental { CarId = 3018, CustomerId = 6033, RentDate = DateTime.Now });
            //Console.WriteLine(result.Message);
            var result = rentalManager.Add(new Rental { RentalId = 3015,  ReturnDate = DateTime.Now});
            Console.WriteLine(result.Message);






        }








        private static void CustomerManagerTest(CustomerManager customerManager)
        {

            //var result = customerManager.Add(new Customer { UserId = 2006, CompanyName = "Mono Aydınlatma" });
            //Console.WriteLine(result.Message);
            //var result = customerManager.Update(new Customer { CustomerId = 6027, CompanyName = "Karaman Tekstil", UserId = 2004 });
            //Console.WriteLine(result.Message);
            //var result = customerManager.Delete(new Customer { CustomerId = 6028 });
            //Console.WriteLine(result.Message);

            Console.WriteLine("GetAll Result");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1} - {2}", customer.CustomerId, customer.UserId, customer.CompanyName);
            }

            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("GetById Result");
            var result = customerManager.GetById(6032).Data;
            Console.WriteLine("{0} - {1} - {2}", result.CustomerId, result.UserId, result.CompanyName);
            Console.ReadLine();
        }

        private static void UserManagerTest(UserManager userManager)
        {
            //userManager.Add(new User { Email = "hh@gmail", FirstName = "İlker", LastName = "Yiğitalp", Password = "111" });
            //userManager.Update(new User {UserId=3004, Email = "cevat@gmail", FirstName = "Cevat", LastName = "Erdoğmuş", Password = "222" });
            //userManager.Delete(new User { UserId = 2008 });

            Console.WriteLine("GetAll Result");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4}", user.UserId, user.FirstName, user.LastName, user.Email, user.Password);
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("GetById Result");

            var result = userManager.GetById(2004).Data;
            Console.WriteLine("{0} - {1} - {2} - {3} - {4}", result.UserId, result.FirstName, result.LastName, result.Email, result.Password);
            Console.ReadLine();
        }

        private static void BrandManagerTest(BrandManager brandManager)
        {
            brandManager.Add(new Brand { BrandName = "Mazda" });
            brandManager.Update(new Brand { BrandId = 2008, BrandName = "Jaguar" });
            brandManager.Delete(new Brand { BrandId = 1036 });

            Console.WriteLine("GetAll Result");
            foreach (var brand in brandManager.GetBrandsAll().Data)
            {
                Console.WriteLine("{0} - {1}", brand.BrandId, brand.BrandName);
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("GetBrandId Result");
            var result = brandManager.GetBrandId(1032).Data;
            Console.WriteLine("{0} - {1}", result.BrandId, result.BrandName);
        }

        private static void ColorManagerTest(ColorManager colorManager)
        {
            //colorManager.Add(new Color { ColorName = "Fındık Yeşili" });
            //colorManager.Update(new Color { ColorId = 3019, ColorName = "Kül Rengi" });
            //colorManager.Delete(new Color { ColorId = 4007 });

            Console.WriteLine("Get All Result");

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1}", color.ColorId, color.ColorName);
            }

            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("GetColorId Result");
            var result = colorManager.GetColorId(3013).Data;
            Console.WriteLine("{0} - {1}", result.ColorId, result.ColorName);

            Console.ReadLine();
        }

        private static void CarManagerTest(CarManager carManager)
        {
            //carManager.Add(new Car { BrandId = 1029, ColorId=3024, CarName="Skoda", DailyPrice=250,Description = "Düz Vites Skoda Fabia", ModelYear=2015 });
            //carManager.Delete(new Car { CarId = 3016 });
            //carManager.Update(new Car { CarId = 3020, ColorId = 3018, CarName = "Volkswagen", DailyPrice = 450, Description = "Volkswagen Golf Gök Mavisi", ModelYear = 2020, BrandId = 1034 });

            Console.WriteLine("Get All Sonucu");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", car.CarId, car.BrandId, car.ColorId, car.CarName, car.DailyPrice, car.ModelYear, car.Description);
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("GetById Sonucu");
            var result = carManager.GetById(3017).Data;


                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", result.CarId, result.BrandId, result.ColorId, result.CarName, result.DailyPrice, result.ModelYear, result.Description);

            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("GetCarsByBrandId Sonucu");

            foreach (var car in carManager.GetCarsByBrandId(1026).Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", car.CarId, car.BrandId, car.ColorId, car.CarName, car.DailyPrice, car.ModelYear, car.Description);
            }
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("GetCarsByColorId Sonucu");

            foreach (var car in carManager.GetCarsByColorId(3018).Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", car.CarId, car.BrandId, car.ColorId, car.CarName, car.DailyPrice, car.ModelYear, car.Description);
            }
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("GetCarsDetail Sonucu");

            foreach (var car in carManager.GetCarsDetail().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4}", car.CarId, car.BrandName, car.ColorName, car.CarName, car.DailyPrice);
            }
            Console.ReadLine();
          
        }

    }



}
