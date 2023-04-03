using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Security.Application.Models;
using Security.Domain.Validations.HelpersExtensions;

namespace Security.API.Configurations
{
    public class CustomValidationFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            ApiResponse<Dictionary<string, object>> response = new()
            {
                Status = 422,
                Message = "One or more problems occurred while processing your request",
                Title = "submitted information is in an incorrect format",
                Response = context.ModelState.GetErrorsToDictionary()
            };

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(response);
            }

            base.OnActionExecuting(context);
        }
    }
}
