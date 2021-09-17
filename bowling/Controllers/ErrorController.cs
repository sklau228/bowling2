using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bowling.Controllers
{
    public class ErrorController : ControllerBase
    {
   
        [HttpGet("/error")]
        public IActionResult Error() 
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var stacktrace = context.Error.StackTrace;
            var errorMessage = context.Error.Message;

            // store error somewhere
            return Problem();
        }  
    }
}
