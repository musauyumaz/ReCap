using Business.Abstract;
using Core.Entities.Abstract;
using Core.Utilities.IoC;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TService,TEntity> : ControllerBase where TService :IBaseService<TEntity> where TEntity : class, IEntity, new()
    {   //IBrandService _service
        public  TService _service;

       //public BaseController()//(IBrandService brandService)
       // {
       //     _service =ServiceTool.ServiceProvider.GetService<TService>();
       // }

        public IActionResult Response(IResult result)
        {
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getall")]
        public virtual IActionResult GetAll()
        {
            return Response(_service.GetAll());
        }
        [HttpGet("getbyid")]
        public virtual IActionResult GetById(int entityId)
        {
            return Response(_service.GetById(entityId));
        }
        [HttpPost("add")]
        public virtual IActionResult Add(TEntity entity)
        {
            return Response(_service.Add(entity));
        }
        [HttpDelete("delete")]
        public virtual IActionResult Delete(TEntity entity)
        {
            return Response(_service.Delete(entity));
        }
        [HttpPut("update")]
        public virtual IActionResult Update(TEntity entity)
        {
            return Response(_service.Update(entity));

        }
    }
}
