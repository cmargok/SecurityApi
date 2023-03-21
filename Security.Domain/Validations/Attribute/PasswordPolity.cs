using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Security.Domain.Validations.Annotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PasswordPolity : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value == null) return false;

            string pattern = @"^(?=.*\d{3})(?=.*[^\w\d]{2})(?=.*[A-Z]{2})[^\w\d]*$";

            if (Regex.IsMatch(value.ToString()!, pattern)) return true; 
            return false;
        }
    }
}
