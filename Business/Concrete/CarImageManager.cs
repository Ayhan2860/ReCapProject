using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileUpload;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage )
        {
            var result = BusinessRules.Run(CheckIfImageLimit(carImage));
            if (result != null) return result;

            if (carImage.Id == 0)
            {
                string path = FileUpload.AddFile(file).Message;
                carImage.ImagePath = path;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.AddedPhoto);
            }
            return new ErrorResult();



        }

       

        public IResult Delete(CarImage carImage)
        {
            var getImage = _carImageDal.Get(ci => ci.Id == carImage.Id).ImagePath;
            if (getImage == null)
            {
                return new ErrorResult();
            }
            FileUpload.Del(getImage);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.PhotoDeleted);

        }

      

        public IDataResult<CarImage> Get(int id)
        {
           return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id),Messages.GetByIdPhoto);

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<string>> GetImageByCarId(int id)
        {
            var result = BusinessRules.Run(CheckCarIdImage(id));
            if (result != null)
            {
                return new SuccessDataResult<List<string>>
                    (
                      new List<string> { Path.Combine(Environment.CurrentDirectory, @"\wwwroot\Images\default.png").ToString() }
                    );
            }

            List<string> images = new List<string>();
            _carImageDal.GetAll(ci => ci.CarId == id).ForEach(ni => { images.Add(ni.ImagePath);});
            
            return new SuccessDataResult<List<string>>(images, Messages.GetById);
        }

      

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var getImage = _carImageDal.Get(ci => ci.Id == carImage.Id);
            if (getImage == null)
            {
                return new ErrorResult();
            }
            FileUpload.Del(getImage.ImagePath);
            var updatePath = FileUpload.AddFile(file).Message;
            carImage.ImagePath = updatePath;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }



        private IResult CheckIfImageLimit(CarImage carImage)
        {
            if (_carImageDal.GetAll(ci => ci.CarId == carImage.CarId).Count >= 5)
            {
                return new ErrorResult(Messages.NotPhotoLimit);
            }
            return new SuccessResult();
        }


        private IResult CheckCarIdImage(int id)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == id).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
       
    }
}
