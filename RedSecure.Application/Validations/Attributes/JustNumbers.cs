using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RedSecure.Application.Validations.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class JustNumbers : ValidationAttribute
    {
        private const string Pattern = @"^\d+$";
        public override bool IsValid(object? value)
        {
            if (value is not null and string values)
            {
                if (Regex.IsMatch(values, Pattern)) 
                    return true;
            }
            return false;
        }
    }

}
