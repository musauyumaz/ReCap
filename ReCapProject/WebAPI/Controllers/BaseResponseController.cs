//using Core.Utilities.Results.Abstract;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BaseResponseController<TResult>:ControllerBase where TResult:IResult 
//    {
//        public IActionResult Response(TResult result)
//        {
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }
//    }
//}
