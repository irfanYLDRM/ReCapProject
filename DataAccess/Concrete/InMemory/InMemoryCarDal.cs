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
            _cars = new List<Car>
            {
                new Car { CarId=1, BrandId=1, ColorId=1, ModelYear="2005", DailyPrice=67000, Description="İlk sahibinden hatasız." },
                new Car { CarId=2, BrandId=1, ColorId=2, ModelYear="2015", DailyPrice=120000, Description="5 yaşında 21000 km'de." },
                new Car { CarId=3, BrandId=3, ColorId=1, ModelYear="2006", DailyPrice=57000, Description="Tofaş patasına." },
                new Car { CarId=4, BrandId=3, ColorId=1, ModelYear="2012", DailyPrice=93000, Description="HATASIZ BOYASIZ." },
                new Car { CarId=5, BrandId=5, ColorId=5, ModelYear="2019", DailyPrice=250000, Description="SON KASA M PAKET." },
                new Car { CarId=6, BrandId=9, ColorId=3, ModelYear="2017", DailyPrice=215000, Description="BOYASIZ TRAMERSİZ." },
                new Car { CarId=7, BrandId=1, ColorId=5, ModelYear="1980", DailyPrice=19000, Description="Sadece 50.000 km'de sıfır kokusu duruyor." }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
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

        public int GetById(Car car)
        {
            return car.CarId;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
