﻿using AnimalsAppBackend.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalsAppBackend.ApplicationUtilities.ValidationAttributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Result<string> errorResult = GetErrorResult(context);
                context.Result = new BadRequestObjectResult(errorResult);
            }
        }

        private static Result<string> GetErrorResult(ActionExecutingContext context)
        {
            if (context.ModelState.ErrorCount == 1)
            {
                return GetSingleErrorResult(context);
            }
            else
            {
                return GetMultipleErrorsResult(context);
            }
        }

        private static Result<string> GetSingleErrorResult(ActionExecutingContext context)
        {
            string errorMessage = context.ModelState.Values.First().Errors.First().ErrorMessage;
            return Result<string>.CreateErrorResult(errorMessage);
        }

        private static Result<string> GetMultipleErrorsResult(ActionExecutingContext context)
        {
            Result<string> result = Result<string>.Create(null);
            IEnumerable<string> allErrorMessages = context.ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
            foreach (var errorMessage in allErrorMessages)
            {
                result.AddError(errorMessage);
            }
            return result;
        }
    }
}