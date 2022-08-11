using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars=new List<Car> {
            new Car{CarId=1,BrandId=1,ColorId=1, DailyPrice=5000, ModelYear="2007", Description="Undamaged"},
            new Car{CarId=2,BrandId=2,ColorId=1, DailyPrice=15000, ModelYear="2009", Description="Damaged"},
            new Car{CarId=3,BrandId=2,ColorId=5, DailyPrice=25000, ModelYear="2008", Description="Undamaged"},
            new Car{CarId=4,BrandId=3,ColorId=3, DailyPrice=500, ModelYear="2009", Description="Damaged"},
            new Car{CarId=5,BrandId=4,ColorId=2, DailyPrice=35000, ModelYear="2009", Description="Undamaged"},
            new Car{CarId=6,BrandId=5,ColorId=1, DailyPrice=45000, ModelYear="2000", Description="Damaged"},

                };
        }
        public void Add(Car Car)
        {
            _cars.Add(Car);
        }

        public void Delete(Car car)
        {
            
                Car carToDelete = _cars.SingleOrDefault(item => item.CarId == car.CarId);
                _cars.Remove(carToDelete);
            
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDto(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetCarDtoById(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(item => item.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
            carToUpdate.ColorId = car.ColorId;
          

        }
    }
}
