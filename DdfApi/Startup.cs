using System;
using DdfApi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace DdfApi
{
   public class Startup
    {
       private readonly IHostingEnvironment _environment;

       public Startup(IHostingEnvironment environment)
       {
          _environment = environment ?? throw new ArgumentNullException(nameof(environment));
       }

       public void ConfigureServices(IServiceCollection services)
       {
          services.AddLogging(loggingBuilder =>
                              {
                                 loggingBuilder.AddConsole();
                              });

          services.AddMvc(options =>
                          {
                             options.Filters.Add<ExceptionFilter>();
                          });

          services.AddSwaggerGen(options =>
                                 {
                                    options.SwaggerDoc("ddf-api", new Info()
                                                                  {
                                                                     Title = "DDF Demo",
                                                                     Version = "v1"
                                                                  });
                                 });
       }

       public void Configure(IApplicationBuilder app)
       {
          app.UseMvc();
          app.UseSwagger();
          app.UseSwaggerUI(options =>
                           {
                              options.SwaggerEndpoint("/swagger/ddf-api/swagger.json", "DDF Demo");
                           });
       }
    }
}
