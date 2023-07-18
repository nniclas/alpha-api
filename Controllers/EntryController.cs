using alpha_api.Data;
using alpha_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class EntryController : ControllerBase
    {
        private readonly IEntryRepository repository;

        public EntryController(IEntryRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/entries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entry>>> Get()
        {
            return await Task.FromResult(this.repository.GetEntries());
        }

        // GET api/entries/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> Get(int id)
        {
            var employees = await Task.FromResult(repository.GetEntry(id));
            if (employees == null)
            {
                return NotFound();
            }
            return employees;
        }

        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<Entry>> Post(Entry entry)
        {
            repository.AddEntry(entry);
            return await Task.FromResult(entry);
        }

        // PUT api/entries/4
        [HttpPut("{id}")]
        public async Task<ActionResult<Entry>> Put(int id, Entry entry)
        {
            if (id != entry.Id)
            {
                return BadRequest();
            }
            try
            {
                repository.UpdateEntry(entry);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(entry);
        }

        // DELETE api/entries/4
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            repository.DeleteEntry(id);
            await Task.CompletedTask;
        }

        private bool EntryExists(int id)
        {
            return repository.CheckEntry(id);
        }
    }
}
}