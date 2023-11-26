using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata;
using UnitOfWork.Design.Pattern.BusinessLayer.Models;

namespace UnitOfWork.Design.Pattern.BusinessLayer;
public class CustomValidations : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
            context.Result = new BadRequestObjectResult(context.ModelState);
        
        var parameters = context.ActionArguments.Values.FirstOrDefault();

        if(parameters == null)
            context.Result = new BadRequestObjectResult("Object is null");
        
        await next();
    }
}
