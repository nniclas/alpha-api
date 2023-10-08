using alpha_api.Data;
using alpha_api.Models;
using alpha_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace alpha_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("units")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService service;

        public UnitController(IUnitService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Retrieve all units
        /// </summary>
        /// <returns>Returns all units</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Unit>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Unit>>> Get()
        {
            return await this.service.GetAllAsync();
        }


        /// <summary>
        /// Retrieve unit by id
        /// </summary>
        /// <param name="id">The id of the unit to be retrieved</param>
        /// <returns>Returns a unit</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Unit>> Get(int id)
        {
            var unit = await service.GetAsync(id);
            if (unit == null) return NotFound();
            return unit;
        }

        /// <summary>
        /// Add a unit
        /// </summary>
        /// <param name="unit">The unit to add</param>
        /// <returns>Returns a unit</returns>
        /// <returns>Returns 201 Created success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Unit>> Post(Unit unit)
        {
            var u = await service.AddAsync(unit);
            return u;
        }

        /// <summary>
        /// Updates a unit
        /// </summary>
        /// <param name="id">The id of the unit to update</param>
        /// <param name="unit">The unit to be updated</param>
        /// <returns>Returns a unit</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Put(int id, Unit unit)
        {
            if (id != unit.Id)
                return BadRequest();
            
           await service.UpdateAsync(unit);
            return unit;
        }


        /// <summary>
        /// Deletes a unit
        /// </summary>
        /// <param name="id">The id of the unit to remove</param>
        /// <returns>Returns a boolean</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await service.DeleteAsync(id);
        }

      
    }
}