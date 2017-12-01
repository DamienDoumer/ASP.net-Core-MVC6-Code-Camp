using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyCodeCamp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCodeCamp.Controllers
{
    /// <summary>
    /// We dont derive it from BaseController because 
    /// We wont really need the URL helper since this is 
    /// a Functional controller.
    /// </summary>
    [Route("api/[controller]")]
    public class OperationsController : Controller
    {
        private ILogger<OperationsController> _logger;
        private IConfigurationRoot _config;

        public OperationsController(ILogger<OperationsController> logger, IConfigurationRoot config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet("reloadConfig")]
        public IActionResult ReloadConfiguration()
        {
            try
            {
                _config.Reload();

                return Ok("Configuration Reload");
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception thrown while reloading Configurations: {e.Message}");
            }

            return BadRequest("Could not reload the configurations.");
        }
    }
}
