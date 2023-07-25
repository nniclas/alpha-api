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
            return await Task.FromResult(this.service.GetAll());
        }

        [HttpGet("byUnit/{unitId}")]
        public async Task<ActionResult<IEnumerable<Entry>>> GetByUnitId(int unitId)
        {
            return await Task.FromResult(this.service.GetAllByUnitId(unitId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> Get(int id)
        {
            var entry = await Task.FromResult(service.Get(id));
            if (entry == null)
            {
                return NotFound();
            }
            return entry;
        }

        [HttpPost]
        public async Task<ActionResult<Entry>> Post(Entry entry)
        {
            service.Add(entry);
            return await Task.FromResult(entry);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Entry>> Put(int id, Entry entry)
        {
            if (id != entry.Id)
                return BadRequest();
            
           service.Update(entry);

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
        public async Task Delete(int id)
        {
            service.Delete(id);
            await Task.CompletedTask;
        }

      
    }
}