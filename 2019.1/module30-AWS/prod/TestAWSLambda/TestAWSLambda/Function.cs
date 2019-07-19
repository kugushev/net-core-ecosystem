using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace TestAWSLambda
{
    public class Function
    {

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<Output> FunctionHandler(Input input, ILambdaContext context)
        {
            using (var client = new HttpClient())
            using (var response = await client.GetAsync("http://172.31.42.104:5000/api/values"))
            {
                var json = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<string[]>(json);
                return new Output
                {
                    Keys = string.Join(", ", obj)
                };
            }
        }
    }

    public class Input
    {
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
    }

    public class Output
    {
        public string Keys { get; set; }

        public TaskAwaiter<string> GetAwaiter()
        {
            throw new Exception();
        }
    }
}
