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
    public class CarsController : BaseController<ICarService, Car>
    {
        public CarsController(ICarService carService)
        {
            _service = carService;
        }

        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            return Response(_service.GetCarsByBrandId(brandId));
        }
        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            return Response(_service.GetCarsByColorId(colorId));
        }
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            return Response(_service.GetCarDetails());
        }


    }
}
