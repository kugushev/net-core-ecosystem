using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatsService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatsService.Controllers
{
    [Route("api/cat")]
    [ApiController]
    public class CatController : ControllerBase
    {
        [ResponseCache(Duration =42)]
        [HttpGet("{id}/toys/{toyId?}")]
        public ActionResult<Toy> Get(int id, int toyId = 0)
        {
            if (id > 0)
            {
                return new Toy
                {
                    Id = toyId
                };
            }

            return NotFound();
        }

        [HttpPost("{id}/toys")]
        public IActionResult PostToy(int id, [FromBody] Toy toy)
        {
            if(id > 0)
            {
                return Ok();
            }
            
            return NotFound();
        }
    }
}