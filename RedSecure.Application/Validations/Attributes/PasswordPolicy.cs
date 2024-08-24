using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RedSecure.Application.Validations.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PasswordPolicy : ValidationAttribute
    {
        private const string Pattern = @"^(?=.*\d{3})(?=.*[^\w\d]{2})(?=.*[A-Z]{2})[^\w\d]*$";
        public override bool IsValid(object? value)
        {
            if (value is not null and string pass)
            {
                if (Regex.IsMatch(pass, Pattern))
                    return true;
            }
           
            return false;
        }
    }
}
