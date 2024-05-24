using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PeruTrekkings.API.Models.DTO;

namespace PeruTrekkings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        //Post: Api/auth/register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto) 
        {
            var identityUser = new IdentityUser { 
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if(identityResult.Succeeded)
            {
                //Add roles to this User
                if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if(identityResult.Succeeded) { return Ok("User was registered! Please Login."); }
                } 
            }
            return BadRequest("Something went wrong");
        }

        //Post: Api/auth/login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginReqDto loginReqDto)
        {
            var user = await userManager.FindByEmailAsync(loginReqDto.Username);
            if (user != null) {
                var CheckPassword = await userManager.CheckPasswordAsync(user, loginReqDto.Password);
                if (CheckPassword)
                {
                    //Create Token


                    return Ok("Correct");
                }
            };
            return BadRequest("username or pass incorrect.");


        }

    }
}
