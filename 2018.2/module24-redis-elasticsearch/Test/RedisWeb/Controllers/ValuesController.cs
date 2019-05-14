using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Nest;
using Newtonsoft.Json;
using RedisWeb.Models;
using StackExchange.Redis;

namespace RedisWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMemoryCache cache;
        private readonly IDistributedCache distributedCache;
        private static readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");

        public ValuesController(IMemoryCache cache, IDistributedCache distributedCache)
        {
            this.cache = cache;
            this.distributedCache = distributedCache;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IDatabase db = redis.GetDatabase();
            RedisValue[] students = db.ListRange("studentsList", 0, -1);

            return students.Select(x => x.ToString()).ToList();
            //var encodedEntry = distributedCache.Get("students");
            //if (encodedEntry == null)
            //{
            //    string fromDb = "Epam Students"; // get from DB
            //    encodedEntry = Encoding.UTF8.GetBytes(fromDb);
            //    distributedCache.Set("students", encodedEntry);
            //    return new[] { fromDb }.ToList();
            //}
            //string entity = Encoding.UTF8.GetString(encodedEntry);
            //return new[] { entity }.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            if (!cache.TryGetValue(id, out Student entry))
            {
                entry = new Student { Id = id, Name = $"student {id}" };
                var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(30));
                cache.Set(id, entry, options);
            }
            return entry;
        }

        [HttpGet("search/{text}")]
        public ActionResult<IEnumerable<Student>> Search(string text)
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("students");
            var client = new ElasticClient(settings);

            var result = client.Search<Student>(s => s.Query(q => q.Match(m => m.Field(o => o.Name).Query(text))));
            if (result.IsValid)
                return result.Hits.Select(x => x.Source).ToList();
            return BadRequest();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            IDatabase db = redis.GetDatabase();
            db.ListRightPush("studentsList", value);
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
    }
}
