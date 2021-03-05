using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin,car.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            
            _carDal.Add(car);
            return new SuccessResult(Messages.Cars + Messages.Added);
        }
        
        [TransactionScopeAspect]
        public IResult AddTransationalTest(Car car)
        {
            _carDal.Add(car);
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {

            _carDal.Delete(car);
            return new SuccessResult(Messages.Cars + Messages.Deleted);

        }

        //[CacheAspect]
        [SecuredOperation("admin,car.add")]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {

            Thread.Sleep(5000);
            return new SuccessDataResult<List<Car>>(_carDal.GetAll().ToList(),Messages.Cars + Messages.Listed);
        }

        [CacheAspect]
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

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Cars + Messages.Updated);
        }
    }
}



