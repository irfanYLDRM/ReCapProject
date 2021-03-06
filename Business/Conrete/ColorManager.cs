using Business.Abstract;
using Business.Contants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Conrete
{
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length > 2)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(Messages.NameInvalid);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<Color> GetCarsColorById(int ColorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == ColorId));
        }

        public IResult Update(Color color)
        {
            if (color.ColorName.Length > 2)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.Updated);
            }
            return new ErrorResult(Messages.NameInvalid);
        }
    }
}
