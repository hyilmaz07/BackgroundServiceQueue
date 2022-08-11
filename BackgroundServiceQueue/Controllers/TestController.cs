using BackgroundServiceQueue.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackgroundServiceQueue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly INameQueueService nameQueueService;

        public TestController(INameQueueService nameQueueService)
        {
            this.nameQueueService = nameQueueService;
        }

        [HttpPost]
        public IActionResult AddQueue(string[] names)
        {
            foreach (var name in names)
            {
                nameQueueService.AddQueue(name);
            }
            return Ok();
        }
    }
}
