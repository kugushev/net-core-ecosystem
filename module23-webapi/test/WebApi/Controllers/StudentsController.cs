using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm]Student student)
        {
            return Ok();
        }

        [HttpGet("boys/{power}")]
        public IActionResult Get([FromRoute]int power)
        {
            return Ok();
        }
    }
}