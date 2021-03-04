using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {

           
            
            _brandDal.Add(brand);
            return new SuccessResult(Messages.Brand + Messages.Added);

        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Brand + Messages.Deleted);

        }

        public IDataResult<Brand> GetBrandId(int brandId)
        {
            
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId),Messages.Brand +"Brand"+ Messages.GetById);
        }

        [SecuredOperation("admin")]
        public IDataResult<List<Brand>> GetBrandsAll()
        {
            
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.Brand + Messages.Listed);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.Brand + Messages.Updated);
        }
    }
}
