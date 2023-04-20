using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtHelpers jwt;

        public AccountController(JwtHelpers jwt)
        {
            this.jwt = jwt;
        }

        [HttpPost("~/api/signin")]
        public IActionResult Sigin(LoginViewModel login)
        {
            if (login.Password == "123")
            {
                var isAdmin = (login.Username == "will") ? true : false;
                var token = jwt.GenerateToken(login.Username, isAdmin: isAdmin);
                return Ok(new
                {
                    token = token
                });
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("~/api/claims")]
        [Authorize]
        public IActionResult GetClaims()
        {
            return Ok(User.Claims.Select(p => new { p.Type, p.Value }));
        }

    }
}
