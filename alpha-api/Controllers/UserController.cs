using alpha_api.Data;
using alpha_api.Models;
using alpha_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("users")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Retrieve all users
        /// </summary>
        /// <returns>Returns all users</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await this.service.GetAllAsync();
        }

        /// <summary>
        /// Retrieve user by id
        /// </summary>
        /// <param name="id">The id of the user to be retrieved</param>
        /// <returns>Returns a user</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await service.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}