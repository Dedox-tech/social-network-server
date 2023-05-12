using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetworkServer.Data;
using SocialNetworkServer.DTO;
using SocialNetworkServer.Entities;
using System.Net;

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
                var successResponse = new ResponseDTO()
                {
                    Code = HttpStatusCode.OK,
                    Message = "The user was created successfully",
                };
                    
                return Ok(successResponse);
            }

            // Mapping the errors
            var customErrorList = new List<object>();
            userCreationResult.Errors.ToList().ForEach(error => customErrorList.Add(error));

            var failureResponse = new ResponseDTO() { 
                Code = HttpStatusCode.BadRequest,
                Message = "An undeterminated error ocurred during the user creation process",
                Errors = customErrorList
            };

            return BadRequest(failureResponse);
        }

    }
}
