using System;
using Microsoft.AspNetCore.Mvc;

namespace DdfApi.Controllers
{
   [Route("api/[controller]")]
   public class RandomController : Controller
   {
      /// <summary>
      /// Gets a random number.
      /// </summary>
      /// <returns>A random number.</returns>
      [HttpGet("next")]
      public int Next()
      {
         return new Random().Next();
      }

      [HttpGet("throw")]
      public void Throw()
      {
         throw new Exception($"Thrown at {DateTime.Now}");
      }
   }
}
