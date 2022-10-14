using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        private ICustomerService _customerService;
        private ICarService _carService;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator), Priority = 1)]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(IsCarAvailable(rental.CarId), CheckIfFindeks(rental.CarId, rental.CustomerId));

            if (result != null)
            {
                return new ErrorResult();
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new Result(true, Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new DataResult<List<Rental>>(_rentalDal.GetAll(), true, Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int RentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.RentalId == RentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new Result(true);
        }

        public IResult CheckIfFindeks(int carId, int customerId)
        {
            var customer = _customerService.GetById(customerId).Data;
            var car = _carService.GetById(carId).Data;
            if (customer.FindeksPoint <= car.MinFindexPoint)
            {
                return new ErrorResult(Messages.FindeksPointNotEnough);
            }
            return new SuccessResult();
        }

        private IResult IsCarAvailable(int carId)
        {
            var result = _rentalDal.GetAll(c => c.CarId == carId && (c.ReturnDate == null || c.ReturnDate > DateTime.Now)).Any();
            if (result)
            {
                return new ErrorResult(Messages.NotAvailable);
            }

            return new SuccessResult();
        }

    }
}
