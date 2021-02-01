using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car { CarId = 1, BrandId = 2, DailyPrice = 450, ModelYear = 1962, Description = "KLASİK VOSVOS RAGTOP" },
                new Car { CarId = 2, BrandId = 3, DailyPrice = 180, ModelYear = 2020, Description = "Ford Focus 1.5 TDCi" },
                new Car { CarId = 3, BrandId = 2, DailyPrice = 350, ModelYear = 2017, Description = "Mercedes Vito 114 Bluetec" },
                new Car { CarId = 4, BrandId = 1, DailyPrice = 120, ModelYear = 2018, Description = "Renault Clio 1.2 İcon" }
            };
        }

       

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.BrandId == car.BrandId);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
          return  _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.CarId = car.CarId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        
    }
}
