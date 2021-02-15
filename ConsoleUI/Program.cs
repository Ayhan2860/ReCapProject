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
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            //GetBrandsAll(brandManager);
            //GetAllColor(colorManager);
            //UserRegister(userManager);
            // CarAdd(carManager, colorManager, brandManager);
            // ColorAdd(colorManager);
            //BrandAdd(brandManager);
          




            int valueNum = 0;
            string valueSt = "";

            while (true)
            {
              
                Menus();
                Console.Write("Lütfen Bir Seçim Yapınız:   ");
                valueSt = Console.ReadLine();

                switch (valueSt)
                {
                    case "1":
                        UserRegister(userManager);
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Giriş İçin Bilgilerinizi Giriniz");
                        Console.Write("E-mail Giriniz: "); var emailLogin = Console.ReadLine();
                        Console.Write("Password Giriniz: "); var passwordLogin = Console.ReadLine();
                        Console.Clear();

                        foreach (var user in userManager.GetAll().Data)
                        {
                            if (user.Email == emailLogin && user.Password == passwordLogin)
                            {
                                Console.WriteLine("Giriş Yaptınız İlerlemek için Enter'a Basınız");
                                Console.ReadLine();
                             
                                while (true)
                                {
                                    LoginMenus();
                                    Console.Write("Lütfen İşlem Yapınız: ");
                                    valueSt = Console.ReadLine();
                                    switch (valueSt)
                                    {
                                        case "1":
                                            BrandAdd(brandManager);
                                            break;
                                        case "2":
                                            ColorAdd(colorManager);
                                            break;
                                        case "3":
                                            CarAdd(carManager, colorManager, brandManager);
                                            break;
                                        case "4":
                                            Console.Clear();
                                            Console.Write("Aradığınız Aracın Id Numarasını Giriniz: ");
                                            var carIdValue = int.Parse(Console.ReadLine());
                                            var carResultId = carManager.GetById(carIdValue).Data;
                                            Console.WriteLine("Araç Adı: {0} - Açıklama: {1} - Günlük Fiyat: {2}", carResultId.CarName, carResultId.Description, carResultId.DailyPrice);
                                            Console.ReadLine();
                                            Console.Clear();
                                            break;
                               
                                      
                                      
                                    }


                                }
                            }

                            Console.Clear(); Console.WriteLine("Bilgilerinizi Lütfen Kontrol Ediniz");
                            Console.ReadLine(); Console.Clear();
                        }
                        
                        break;




                }
            }



        }

        

        private static void UserRegister(UserManager userManager)
        {
            Console.Clear();
            Console.WriteLine("Kullanıcı Bilgilerinizi Giriniz");
            var userRegister = new User { };
            Console.Write("Adı: "); userRegister.FirstName = Console.ReadLine();
            Console.Write("Soyadı: "); userRegister.LastName = Console.ReadLine();
            Console.Write("E-mail: "); userRegister.Email = Console.ReadLine();
            Console.Write("Şifre: "); userRegister.Password = Console.ReadLine();
            userManager.Add(userRegister);
            Console.Clear();
        }

        private static void BrandAdd(BrandManager brandManager)
        {
            Console.Clear();
            Console.Write("Lütfen Eklemek İstediğiniz Araç Markasını Giriniz:    ");
            brandManager.Add(new Brand { BrandName = Console.ReadLine() });
        }

        private static void ColorAdd(ColorManager colorManager)
        {
            Console.Clear();
            Console.Write("Lütfen Eklemek İstediğiniz Rengi Giriniz:    ");
            colorManager.Add(new Color { ColorName = Console.ReadLine() });
        }

        private static void CarAdd(CarManager carManager, ColorManager colorManager, BrandManager brandManager)
        {
            Console.Clear();
            Console.WriteLine("Araç Bilgilerinizi Giriniz");
            var infoCarAdded = new Car { };
            Console.Write("Araç Adı:  "); infoCarAdded.CarName = Console.ReadLine();
            GetAllColor(colorManager); Console.Write("Renk Id: "); infoCarAdded.ColorId = int.Parse(Console.ReadLine());
            GetBrandsAll(brandManager); Console.Write("Brand Id: "); infoCarAdded.BrandId = int.Parse(Console.ReadLine());
            Console.Write("Günlük Fiyat: "); infoCarAdded.DailyPrice = int.Parse(Console.ReadLine());
            Console.Write("Model Yılı: "); infoCarAdded.ModelYear = int.Parse(Console.ReadLine());
            Console.Write("Açıklama: "); infoCarAdded.Description = Console.ReadLine();
            carManager.Add(infoCarAdded);
            Console.Clear();
        }

        private static void GetAllColor(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0} {1}", color.ColorId, color.ColorName);
            }
        }

        private static void Menus()
        {
            string[] menus = new string[] { "Kayıt Ol", "Giriş Yap" };
            for (int i = 0; i < menus.Length; i++)
            {
                Console.WriteLine($"{i + 1} {menus[i]}");
            }
        }
        private static void GetBrandsAll(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetBrandsAll().Data)
            {
                Console.WriteLine("{0} {1}", brand.BrandId, brand.BrandName);
            }
        }
        private static void LoginMenus()
        {
            string[] menus = new string[] { "Marka Ekleme", "Renk Ekleme", "Araç Ekleme","Araç Bul" };
            for (int i = 0; i < menus.Length; i++)
            {
                Console.WriteLine($"{i + 1} {menus[i]}");
            }
        }

    }


}
