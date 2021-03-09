using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Conrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintanenceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.Listed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetById(int CarId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == CarId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsDto()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.Listed);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.Updated);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                if (car.Description.Length > 2)
                {
                    _carDal.Update(car);
                    return new SuccessResult(Messages.Updated);
                }
                return new ErrorResult(Messages.DescriptionInvalid);
            }
            return new ErrorResult(Messages.PriceInvalid);
        }
    }
}
