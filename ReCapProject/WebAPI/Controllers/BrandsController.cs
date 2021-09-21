using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
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
    public class BrandsController :BaseController<IBrandService,Brand>
    {

        public BrandsController(IBrandService brandService)
        {
            _service = brandService;
        }
        //[HttpGet("fatima")]
        // public IActionResult Fatıma()
        // {
        //     return Response(_service.GetAll());
        // }
        //[HttpGet("getall")]
        //public IActionResult GetAll()
        //{
        //    return Response(_brandService.GetAll());
        //}
        //[HttpGet("getbyid")]
        //public IActionResult GetById(int brandId)
        //{
        //    return Response(_brandService.GetById(brandId));
        //}
        //[HttpPost("add")]
        //public IActionResult Add(Brand brand)
        //{
        //    return Response(_brandService.Add(brand));
        //}
        //[HttpDelete("delete")]
        //public IActionResult Delete(Brand brand)
        //{
        //    return Response(_brandService.Delete(brand));
        //}
        //[HttpPut("update")]
        //public IActionResult Update(Brand brand)
        //{
        //    return Response(_brandService.Update(brand));
        //}
    }
}

