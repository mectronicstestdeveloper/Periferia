using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDevExpress.Models;

namespace WebAppDevExpress.WebAppCore
{
    public class ControlExceptionAttribute : ExceptionFilterAttribute
    {
        public ControlExceptionAttribute()
        {
        }

        public override void OnException(ExceptionContext context)
        {
            // Do Task
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            // Do Task
        }

        private async Task SetResponse(ExceptionContext context)
        {
            context.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(
                    new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {
                    Model = new ErrorModel()
                    {
                        Title = "Error in Controller",
                        Error = context.Exception.Message,
                        TagHelper = string.Empty
                    }
                }
            };
        }
    }
}