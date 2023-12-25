using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FT.Travelako.Services.UserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;
        private readonly string _baseUrl;
        private readonly HttpContext _context;

        public HealthController(ILogger<HealthController> logger, IHttpContextAccessor context)
        {
            if (context.HttpContext != null)
            {
                _context = context.HttpContext;
                var request = _context.Request;
                _baseUrl = $"{request.Scheme}://{request.Host}";
            }
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var ocelotReqId = _context.Request.Headers["OcRequestId"];
            if (string.IsNullOrEmpty(ocelotReqId))
            {
                ocelotReqId = "N/A";
            }
            var result = $"Url: {_baseUrl}, Method: {_context.Request.Method}, Path: {_context.Request.Path}, OcelotRequestId: {ocelotReqId}";
            _logger.LogInformation(result);
            return Ok(result);
        }

        [HttpGet("healthcheck")]
        public IActionResult Healthcheck()
        {
            var msg = $"{_context.Request.Host} is healthy";
            _logger.LogInformation(msg);
            return Ok(msg);
        }

        [HttpGet("status")]
        public IActionResult Status()
        {
            var msg = $"Running on {_context.Request.Host}";
            _logger.LogInformation(msg);
            return Ok(msg);
        }
    }
}
