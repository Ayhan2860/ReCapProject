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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var rentalsReturn = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            if (rentalsReturn.Count > 0)
            {
                foreach (var rentalReturn in rentalsReturn)
                {
                    if (rentalReturn.ReturnDate == null)
                    {
                        return new ErrorResult(Messages.NotRentalAdded);
                    }
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.Rental+Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Rental + Messages.Listed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
           
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId),Messages.Rental + Messages.GetByListId);
           

        }


        public IResult Update(Rental rental)
        {
           
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.Rental + Messages.Updated);
          
        }
    }
}
