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

        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="request">A request with username and password</param>
        /// <returns>Returns a token if authentication succeeds</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpPost]
        [Route("account/signin")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var user = await this.userService.GetByEmailAsync(request.Email);
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