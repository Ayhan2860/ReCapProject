using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public List<Brand> GetBrandId(int brandId)
        {
            return _brandDal.GetAll(b => b.BrandId == brandId);
        }

        public List<Brand> GetBrandsAll()
        {
            return _brandDal.GetAll();
        }
    }
}
