using Microsoft.AspNetCore.Mvc;

namespace Lokcshot.Bannwords.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;

        public SettingsController(ILogger<SettingsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all settings");
            return Ok(new { Message = "Settings received" });
        }
    }
}
