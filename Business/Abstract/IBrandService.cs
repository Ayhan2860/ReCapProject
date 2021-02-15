﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBrandService
    {
        IDataResult<List<Brand>> GetBrandsAll();
        IDataResult<List<Brand>> GetBrandId(int brandId);

        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);



    }
}