using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatsService.Models
{
    public class Toy: IToy
    {
        [Required]
        public int? Id { get; set; }

        [StringLength(5)]
        public string Name { get; set; }

        public string Excess { get; set; }
    }
}
