using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public  interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int id);

        List<Car> GetCarsByColorId(int id);

        void Delete(Car car);

        void Update(Car car);
       
        void Add(Car car);

        List<CarDetailDto> GetCarsDetail();
    }
}
