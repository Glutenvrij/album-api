using Album.Api.Models;
using Album.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Album.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly GreetingService _service;
        private readonly ILogger<HelloController> _logger;

        public HelloController(GreetingService service,
            ILogger<HelloController> logger )
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Index()
        {
            try
            {
                return this._service.GetName(null);
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, "Get name without param");
            }
            return BadRequest("An error occured returning the object");
        }


        [HttpGet("{name}")]
        public ActionResult<string> GetName(string name)
        {
            try
            {
                return this._service.GetName(name);
            }
            catch (Exception ex)
            {
                this._logger.LogError(0, ex, "Get name with param");
            }
            return BadRequest("An error occured returning your name as an object");
        }   
    }
}
