using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBrandService
    {
        List<Brand> GetBrandsAll();
        List<Brand> GetBrandId(int brandId);

        void Add(Brand brand);



    }
}
