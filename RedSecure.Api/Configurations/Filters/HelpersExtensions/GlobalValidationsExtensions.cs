using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RedSecure.Api.Configurations.Filters.HelpersExtensions
{
    public static class GlobalValidationsExtensions
    {
        public static Dictionary<string, object> GetErrorsToDictionary(this ModelStateDictionary modelState)
        {
            try
            {
                Dictionary<string, object> keyValuePairs = [];
                if (modelState == null)
                {
                    return null!;
                }
                foreach (var keyModelStatePair in modelState)
                {
                    var key = keyModelStatePair.Key;
                    var errors = keyModelStatePair.Value.Errors;
                    if (errors != null && errors.Count > 0)
                    {
                        var errorMessages = errors.Select(error =>
                        {
                            return string.IsNullOrEmpty(error.ErrorMessage) ? "error" : error.ErrorMessage;
                        }).ToArray();

                        keyValuePairs.Add(key, errorMessages);
                    }
                }

                return keyValuePairs;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException("Errors are null or Empty or " + ex.Message);
            }

        }
    }
}