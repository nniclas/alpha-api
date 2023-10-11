using alpha_api.Data;
using alpha_api.Models;
using alpha_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("entries")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService service;

        public EntryController(IEntryService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Retrieve all entries
        /// </summary>
        /// <returns>Returns all entries</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entry>>> Get()
        {
            return await this.service.GetAllAsync();
        }

        /// <summary>
        /// Retrieve entries by unit id
        /// </summary>
        /// <param name="unitId">The id of the unit</param>
        /// <returns>Returns a list of entries</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpGet("unit/{unitId}")]
        public async Task<ActionResult<IEnumerable<Entry>>> GetByUnit(int unitId)
        {
            return await this.service.GetAllByUnitAsync(unitId);
        }

        /// <summary>
        /// Retrieve entries by unit id and week
        /// </summary>
        /// <param name="unitId">The id of the unit</param>
        /// <param name="week">A week in format YYYY-WW</param>
        /// <returns>Returns a list of entries</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpGet("unit/{unitId}/week/{week}")]
        public async Task<ActionResult<IEnumerable<Entry>>> GetByUnitAndWeek(int unitId, string week)
        {
            return await this.service.GetAllByUnitAndWeekAsync(unitId, week);
        }

        /// <summary>
        /// Retrieve entry by id
        /// </summary>
        /// <param name="id">The id of the entry to be retrieved</param>
        /// <returns>Returns an entry</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> Get(int id)
        {
            var entry = await service.GetAsync(id);
            if (entry == null) return NotFound();
            return entry;
        }

        /// <summary>
        /// Add an entry
        /// </summary>
        /// <param name="entry">The entry to add</param>
        /// <returns>Returns the added entry</returns>
        /// <returns>Returns 201 Created success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpPost]
        public async Task<ActionResult<Entry>> Post(Entry entry)
        {
            await service.AddAsync(entry);
            return entry;
        }

        /// <summary>
        /// Updates an entry
        /// </summary>
        /// <param name="id">The id of the entry to update</param>
        /// <param name="entry">The entry to be updated</param>
        /// <returns>Returns the updated entry</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Entry>> Put(int id, Entry entry)
        {
            if (id != entry.Id)
                return BadRequest();
            
           await service.UpdateAsync(entry);
            return await Task.FromResult(entry);
        }

        /// <summary>
        /// Deletes an entry
        /// </summary>
        /// <param name="id">The id of the entry to remove</param>
        /// <returns>Returns a boolean </returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await service.DeleteAsync(id);
        }

      
    }
}