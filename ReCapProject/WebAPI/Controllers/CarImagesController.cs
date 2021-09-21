using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : BaseController<ICarImageService, CarImage>
    {
        public CarImagesController(ICarImageService carImageService)
        {
            _service = carImageService;
        }
        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int id)
        {
            return Response(_service.GetByCarId(id));
        }
        [HttpPost()]
        public IActionResult UploadCarImage([FromForm] IFormFile imageFile, [FromForm] CarImage carImage)
        {
           return Response(_service.UploadCarImage(imageFile, carImage));
        }
    }

}
