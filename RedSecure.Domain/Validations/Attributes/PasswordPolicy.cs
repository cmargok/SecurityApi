using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RedSecure.Domain.Validations.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class PasswordPolicy : ValidationAttribute
    {
        private const string Pattern = @"^(?=.*[A-Z]{2})(?=.*[a-z]{2})(?=.*\d{3})(?=.*[^\w\d]{2})[A-Za-z\d^\W]*$";
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
