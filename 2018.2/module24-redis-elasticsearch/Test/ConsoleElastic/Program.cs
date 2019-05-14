using Elasticsearch.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nest;
using RedisWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleElastic
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ElasticClient(new Uri("http://localhost:9200"));
            var universities = new[]
            {
                new University { Name = "Leti", GovNum = "SPBGETU" },
                new University { Name = "SPBGU", GovNum = "SPBGU" },
                new University { Name = "Ship", GovNum = "SPBCTU" },
                new University { Name = "MGU", GovNum = "MGU" },
                new University { Name = "MTU", GovNum = "MTU" },
            };

            var names = File.ReadAllText("CSV_Database_of_First_Names.csv");
            var students = names.Split('\r').Select((name, id) => new Student { Id = id, Name = name, University = universities[id % universities.Length] });

            var bulk = new BulkRequest
            {
                Refresh = Refresh.True,
                Operations = students.Select(x => new BulkIndexOperation<Student>(x) { Index = "students", Type = "doc" }).Cast<IBulkOperation>().ToList()
            };

            var result = client.Bulk(bulk);

        }


    }
}
