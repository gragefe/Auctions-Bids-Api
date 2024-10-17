namespace Bids.API.Validations;

using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Crosscutting.Validations;

public class ValidationExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is CustomValidationException ex)
        {
            context.Result = new BadRequestObjectResult(new { ErrorsFound = ex.ErrorsFound, Errors = ex.Errors });
            context.ExceptionHandled = true;
        }
    }
}
