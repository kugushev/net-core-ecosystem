using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppNuget
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new MapperConfiguration(Config);
            cfg.AssertConfigurationIsValid();
            IMapper mapper = new Mapper(
                cfg);

            var dto = mapper.Map<UserDto>(new User
            {
                Id = 1,
                Name = "Alex",
                Capability = new Capability
                {
                    CanRead = "true",
                    ForSomething = "smth"
                }
            });

            var users = Enumerable.Range(0, 100).Select(i => new User { Id = i });
            var dest = mapper.Map<List<UserDto>>(users);



            var str = JsonConvert.SerializeObject(dto);
            Console.WriteLine(str);

            var entity = mapper.Map<User>(dto);
            Console.WriteLine(JsonConvert.SerializeObject(entity));

        }

        private static void Config(IMapperConfigurationExpression c)
        {
            c.AddProfile<MyProfile>()

            //c.CreateMap<User, UserDto>()
            //    .ForMember(d => d.Something, d => d.MapFrom(s => s.Capability.ForSomething))
            //    .ReverseMap();
        }
    }

    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Capability Capability { get; set; }
    }

    class Capability
    {
        public string CanRead { get; set; }
        public string ForSomething { get; set; }
    }

    class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Capability { get; set; }
        public string Something { get; set; }
    }

    class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(d => d.Something, d => d.MapFrom(s => s.Capability.ForSomething))
                .ReverseMap();
        }
    }
}
