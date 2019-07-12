using AutoMapper;
using Newtonsoft.Json;
using Polly;
using System;
using System.Linq;
using System.Threading;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var policy = Policy
                .Handle<NotImplementedException>()
                .Retry(3);

            policy.Execute(() =>
            {
                throw new NotImplementedException();
            });





            var config = new MapperConfiguration(Configure);
            config.AssertConfigurationIsValid();

            IMapper mapper = new Mapper(config);

            var garrosh = mapper.Map<Garrosh>(new Thrall
            {
                Say = "1",
                Bullshit = "LOL"
            });

            var thralls = Enumerable.Range(0 ,1000).Select(i => new Thrall { Say = $"I'm the {i} Thrall" });

           // var garrroshs = mapper.Map<Garrosh[]>(thralls);

            var str = JsonConvert.SerializeObject(garrosh);


            Console.WriteLine(str);
            var thr = mapper.Map<Thrall>(garrosh);
            Console.WriteLine(JsonConvert.SerializeObject(thr));
        }

        private static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Thrall, Garrosh>()
                .ForMember(d => d.Somthing, c => c.MapFrom(s => s.Bullshit))
                .ReverseMap();
            cfg.CreateMap<Hammer, Garrosh>(MemberList.None);
        }

        class Thrall
        {
            public string Say { get; set; }
           
            public string Bullshit { get; set; }
        }

        class Hammer
        {
            public int Strikes { get; set; }
        }

        class Garrosh
        {
            public int Say { get; set; }

            public string Somthing { get; set; }
        }
    }
}
