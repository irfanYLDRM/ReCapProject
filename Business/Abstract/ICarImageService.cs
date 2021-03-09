﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        //IDataResult<List<CarImage>> GetAll();
        //IDataResult<CarImage> GetCarsImageById(int carImageId);
        IResult Add(IFormFile file, CarImage carImage);
        //IResult Update(CarImage carImage);
        //IResult Delete(CarImage carImage);
    }
}
