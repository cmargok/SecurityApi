using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RedSecure.Api.Configurations.Filters.HelpersExtensions
{
    public static class GlobalValidationsExtensions
    {

        /// <summary>
        /// Take the keys (parameters) and their errors from a ModelStateDictionary Into A "Dictionary"(<string, object>)  
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentExtensionsNullException"></exception>
        public static Dictionary<string, object> GetErrorsToDictionary(this ModelStateDictionary modelState)
        {
            try
            {
                Dictionary<string, object> keyValuePairs = new Dictionary<string, object>();
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
