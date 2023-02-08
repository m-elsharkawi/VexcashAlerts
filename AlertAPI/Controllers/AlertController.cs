using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmailService.Models;
using EmailService.Controllers;
using Microsoft.Extensions.Configuration;
using EmailService.Interfaces;
using AlertAPI.Models;
using DataAccess.Models;
using AlertAPI.Logic;

namespace AlertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AlertController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] Alert alert)
        {
            AlertLogic alertLogic = new AlertLogic(_configuration);
            var response = await alertLogic.SendAlert(alert);
            if (response.Success) return Ok();
            else return BadRequest(response.Message);
        }
    }
}
