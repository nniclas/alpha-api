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
    [Route("entries")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class EntryController : ControllerBase
    {
        private readonly IEntryService service;

        public EntryController(IEntryService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entry>>> Get()
        {
            return await this.service.GetAllAsync();
        }

        [HttpGet("unit/{unitId}")]
        public async Task<ActionResult<IEnumerable<Entry>>> GetByUnit(int unitId)
        {
            return await this.service.GetAllByUnitAsync(unitId);
        }

        [HttpGet("unit/{unitId}/week/{week}")]
        public async Task<ActionResult<IEnumerable<Entry>>> GetByUnitAndWeek(int unitId, string week)
        {
            return await this.service.GetAllByUnitAndWeekAsync(unitId, week);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> Get(int id)
        {
            var entry = await service.GetAsync(id);
            if (entry == null) return NotFound();
            return entry;
        }

        [HttpPost]
        public async Task<ActionResult<Entry>> Post(Entry entry)
        {
            await service.AddAsync(entry);
            return entry;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Entry>> Put(int id, Entry entry)
        {
            if (id != entry.Id)
                return BadRequest();
            
           await service.UpdateAsync(entry);

            //try
            //{
            //    service.Update(entry);
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!Exists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            return await Task.FromResult(entry);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await service.DeleteAsync(id);
        }

      
    }
}