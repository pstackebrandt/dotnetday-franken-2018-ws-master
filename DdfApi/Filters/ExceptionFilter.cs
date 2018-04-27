using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace DdfApi.Filters
{
   public class ExceptionFilter : IExceptionFilter
   {
      private readonly IHostingEnvironment _environment;
      private readonly ILogger<ExceptionFilter> _logger;

      public ExceptionFilter(IHostingEnvironment environment, ILogger<ExceptionFilter> logger)
      {
         _environment = environment ?? throw new ArgumentNullException(nameof(environment));
         _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      }

      /// <inheritdoc />
      public void OnException(ExceptionContext context)
      {
         if (context.Exception != null)
         {
            _logger.LogError(context.Exception, "Unhandled exception");
         }

         if (_environment.IsDevelopment())
         {
            context.Result = new ContentResult()
                             {
                                StatusCode = (int)HttpStatusCode.InternalServerError,
                                Content = context.Exception?.ToString(),
                                ContentType = "text/plain"
                             };
         }
         else
         {
            context.Result = new ContentResult()
                             {
                                StatusCode = (int)HttpStatusCode.InternalServerError,
                                Content = "Ups :(",
                                ContentType = "text/plain"
                             };
         }
      }
   }
}
