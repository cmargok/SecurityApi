using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Security.Domain.Validations.Annotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class JustNumbers : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            string pattern = @"^\d+$";

            if (Regex.IsMatch(value.ToString()!, pattern)) return true;
            return false;
        }
    }
}
