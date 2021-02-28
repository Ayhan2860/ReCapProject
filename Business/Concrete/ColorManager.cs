using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Color + Messages.Added);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Color + Messages.Deleted);

        }

        public IDataResult<List<Color>> GetAll()
        {
            
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.Color + Messages.Listed);
        }

        public IDataResult<Color> GetColorId(int colorId)
        {
            
            return new SuccessDataResult<Color>(_colorDal.Get(cl => cl.ColorId == colorId),Messages.Color + "Color" + Messages.GetById);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.Color + Messages.Updated);
        }
    }
}
