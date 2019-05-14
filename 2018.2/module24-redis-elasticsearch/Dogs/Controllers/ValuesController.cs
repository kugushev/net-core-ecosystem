using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dogs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;

namespace Dogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase, IDisposable
    {
        private readonly IMemoryCache memoryCache;
        private readonly IDistributedCache distributedCache;

        private static readonly ConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect("localhost");

        public ValuesController(IMemoryCache memoryCache, IDistributedCache distributedCache)
        {
            this.memoryCache = memoryCache;
            this.distributedCache = distributedCache;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Dog> Get(int id)
        {
            if (!memoryCache.TryGetValue(id, out Dog dog))
            {
                dog = new Dog
                {
                    Id = id,
                    Name = "Gove"
                }; // get from db
                memoryCache.Set(id, dog);
            }
            return dog;
        }

        [HttpGet("{id}/name")]
        public ActionResult<string> GetName(int id)
        {
            IDatabase db = multiplexer.GetDatabase();

            RedisValue value = db.StringGet(id.ToString());
            if (!value.HasValue)
            {                
                string petName = $"Guffy #{id}";
                db.StringSet(id.ToString(), petName);
                return petName;
            }
            return (string)value;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public void Dispose()
        {

        }
    }
}
