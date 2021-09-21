using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
             new Car {Id=1,BrandId=1,ColorId=1,DailyPrice=500,ModelYear=2020,Description="TOYOTA CAROLLA" },
             new Car {Id=2,BrandId=2,ColorId=1,DailyPrice=900,ModelYear=2021,Description="BMW M5" },
             new Car {Id=3,BrandId=3,ColorId=2,DailyPrice=750,ModelYear=2019,Description="MERCEDES AMG" },
             new Car {Id=4,BrandId=4,ColorId=3,DailyPrice=400,ModelYear=2018,Description="RENAULT FLUENCE" },
             new Car {Id=5,BrandId=5,ColorId=4,DailyPrice=250,ModelYear=2016,Description="DACİA LOGAN" }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {

            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
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

        public Car GetById(int id)
        {
            return _cars.Find(c => c.Id == id);
        }

        public List<CarDetailsDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
