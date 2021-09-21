using Business.Abstract;
using Business.Concrete;
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
    public class CustomersController :BaseController<ICustomerService,Customer>
    {
        public CustomersController(ICustomerService customerService)
        {
            _service = customerService;
        }
    }
}
