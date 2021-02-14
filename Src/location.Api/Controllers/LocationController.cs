using location.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace location.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _locationService;

        public LocationController(ILogger<LocationController> logger,
            ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(";)");
        }

        [HttpGet("Reverse")]
        public async Task<IActionResult> Reverse(double latitude, double longitude, string locale = "en")
        {
            var location = await _locationService.Get(latitude, longitude, locale);

            _logger.LogInformation($"Reversing coordinance {latitude}, {longitude} with locale {locale}...");

            return new JsonResult(new 
            {
                DisplayAddress = $"{location.Road}, {location.Suburb}, {location.City}",
                Address = location
            });
        }
    }
}
