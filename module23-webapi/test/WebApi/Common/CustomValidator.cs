using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Common
{
    public class CustomValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string str)
            {
                return str.Split(" ").Length == 2;
            }
            return false;
        }
    }
}
