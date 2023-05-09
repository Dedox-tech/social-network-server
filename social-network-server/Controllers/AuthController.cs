using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetworkServer.Data;
using SocialNetworkServer.DTO;
using SocialNetworkServer.Entities;

namespace SocialNetworkServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDatabaseContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthController(ApplicationDatabaseContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> TestController()
        {
            var posts = await context.Set<Post>().ToListAsync();
            return Ok("Controller is working");
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignupDTO userSignupDTO)
        {
            var newUser = new IdentityUser
            {
                UserName = userSignupDTO.UserName,
                Email = userSignupDTO.Email,
            };

            var userCreationResult = await userManager.CreateAsync(newUser, userSignupDTO.Password);

            if (userCreationResult.Succeeded)
            {
                return Ok("The user was created successfully");
            }

            return BadRequest(userCreationResult.Errors);
        }

    }
}
