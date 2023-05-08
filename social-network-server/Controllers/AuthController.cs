using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetworkServer.Data;
using SocialNetworkServer.Entities;

namespace SocialNetworkServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDatabaseContext context;

        public AuthController(ApplicationDatabaseContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> TestController()
        {

            var posts = await context.Set<Post>().ToListAsync();
            return Ok("Controller is working");
        }
    }
}
