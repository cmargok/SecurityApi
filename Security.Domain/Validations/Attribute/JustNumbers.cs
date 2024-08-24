using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Security.Domain.Validations.Attribute
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


    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NJustNumbers : ValidationAttribute
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
