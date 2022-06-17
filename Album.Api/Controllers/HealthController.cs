using Album.Api.Models;
using Album.Api.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Album.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("cors-policy")]
    public class HealthController : ControllerBase
    {
        private readonly GreetingService _service;
        private readonly ILogger<HealthController> _logger;

        public HealthController(GreetingService service,
            ILogger<HealthController> logger )
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Index()
        {
            return Ok();
        }

        public IActionResult health()
        {
            return Ok();
        }
    }

}
