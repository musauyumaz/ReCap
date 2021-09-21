using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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

        public IResult Add(CarImage carImage)
        {
           IResult result = BusinessRules.Run(CarImageLimitExceded(carImage.CarId));
            if (result.Success)
            {
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(result.Message);
            
        }

        public IResult Delete(CarImage carImage)
        {
            var result = ImageFileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Id == carId), Messages.Listed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == carImageId));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IResult UploadCarImage(IFormFile imageFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CarImageLimitExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }


            string filePath = ImageFileHelper.Upload(imageFile);
            carImage.ImagePath = filePath;
            carImage.Date = DateTime.Now;
            // return new SuccessDataResult<CarImage>(carImage);
            return this.Add(carImage);
        }

        private IResult CarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId ==carId).Count >=5;
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();

        }
        private IResult CarImageControl(int carId)
        {
            var result = GetByCarId(carId).Data.Count();
            if (result <= 0)
            {
                Add(new CarImage
                {
                    Id = 0,
                    CarId = carId,
                    ImagePath = ImageFileHelper.GetDefaultCarImagePath()
                });
            }
           return new SuccessResult();
            

        }
    }
}
