using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EFCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IOptions<JwtSettings> jwtSettings;

        public ConfigController(IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }

        [HttpGet("jwt")]
        public IActionResult GetJwtSettings() {
            return Ok(jwtSettings.Value);
        }

    }
}
