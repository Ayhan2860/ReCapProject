using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2 && car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.Cars + Messages.NotAdded);
            }
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.Cars + Messages.Added);
            }
        }

        public IResult Delete(Car car)
        {

            _carDal.Delete(car);
            return new SuccessResult(Messages.Cars + Messages.Deleted);

        }

        public IDataResult<List<Car>> GetAll()
        {

           
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.Cars + Messages.Listed);
        }

        public IDataResult<Car> GetById(int id)
        {
            
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id) , Messages.Cars + Messages.GetById);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),Messages.Cars + "Brand" + Messages.GetByListId);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id),Messages.Cars + "Color" + Messages.GetByListId);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetail()
        {
           
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetail(),Messages.Cars + Messages.Listed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Cars + Messages.Updated);
        }
    }
}



