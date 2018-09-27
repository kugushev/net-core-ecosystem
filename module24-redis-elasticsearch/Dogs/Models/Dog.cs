using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dogs.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public struct DogId
    {
        public int Id { get; set; }
        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            if (obj is DogId dogId)
            {
                return dogId.Id == Id;
            }
            return false;
        }
    }
}
