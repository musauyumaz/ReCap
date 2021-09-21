using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService : IBaseService<CarImage>
    {
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IResult UploadCarImage(IFormFile imageFile, CarImage carId);
    }
}
