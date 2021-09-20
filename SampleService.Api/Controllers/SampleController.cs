using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleService.Contract.Contract;
using SampleService.Contract.Interface;

namespace SampleService.Api.Controllers
{
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _service;

        public SampleController(ISampleService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<EmployeeDto>> Get()
        {
            return Ok(_service.GetEmployees());
        }
    }
}
