using EFCoreDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EFCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet,HttpPost,HttpPut,HttpPatch,HttpDelete]
        [ProducesResponseType(typeof(ErrorResponseVM), StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public ActionResult<ErrorResponseVM> Error()
        {
            var ex = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return StatusCode(
                (int)HttpStatusCode.InternalServerError,
                new ErrorResponseVM()
                {
                    errorno = 999,
                    message = ex?.Error.Message ?? "Normal Error"
                });
        }

        public class ErrorResponseVM
        {
            public int errorno { get; set; }
            public string? message { get; set; }
        }
    }
}
