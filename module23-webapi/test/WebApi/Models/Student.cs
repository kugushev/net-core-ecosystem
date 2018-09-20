using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;

namespace WebApi.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [CustomValidator]
        public string Name { get; set; }

    }
}
