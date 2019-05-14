using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatsService.Models
{
    public interface IToy
    {
        int? Id { get; }
        string Name { get; }
    }
}
