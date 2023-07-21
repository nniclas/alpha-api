using alpha_api.Data;
using alpha_api.Models;
using alpha_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Org.BouncyCastle.Crypto.Generators;
using System.Security.Authentication;
using alpha_api.Core;

namespace alpha_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("account")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        public IConfiguration configuration;

        public AccountController(IUserService service, IConfiguration configuration)
        {
            this.userService = service;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("signIn")]
        public async Task<IActionResult> Post(SignInRequest request)
        {
            var user = this.userService.GetByEmail(request.Email);
            if (user == null || request.Email == null || request.Password == null)
                return BadRequest("Invalid request");

            if (!Authentication.VerifyUser(user, request.Password))
                return BadRequest("Invalid credentials");

            return Ok(Authentication.CreateToken(user, configuration.GetSection("Identity").Get<Identity>()!));
        }
    }

    public class SignInRequest
    {
        public string Email { get; set;}
        public string Password { get; set; }
    }
}