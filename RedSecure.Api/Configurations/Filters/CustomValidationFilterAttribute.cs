using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RedSecure.Api.Configurations.Filters.HelpersExtensions;
using RedSecure.Domain.Utils;

namespace RedSecure.Api.Configurations.Filters
{
    public class CustomValidationFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            ApiResponse<Dictionary<string, object>> response = new()
            {
                Error = true,
                Message = "One or more problems occurred while processing your request",
                Title = "submitted information is in an incorrect format",
                Values = context.ModelState.GetErrorsToDictionary()
            };

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(response);
            }

            base.OnActionExecuting(context);
        }
    }
}
