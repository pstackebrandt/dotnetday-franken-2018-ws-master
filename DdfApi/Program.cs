using System;
using Microsoft.AspNetCore.Hosting;

namespace DdfApi
{
   class Program
   {
      static void Main(string[] args)
      {
         var webhost = new WebHostBuilder()
                       .UseKestrel()
                       .UseStartup<Startup>()
                       .Build();

         webhost.Run();
      }
   }
}
