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
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class EventController : ControllerBase
    {
        private readonly IEventService service;

        public EventController(IEventService service)
        {
            this.service = service;
        }

        // GET: api/events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            return await Task.FromResult(this.service.GetAll());
        }

        // GET api/events/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> Get(int id)
        {
            var ev = await Task.FromResult(service.Get(id));
            if (ev == null)
            {
                return NotFound();
            }
            return ev;
        }

        // POST api/events
        [HttpPost]
        public async Task<ActionResult<Event>> Post(Event ev)
        {
            service.Add(ev);
            return await Task.FromResult(ev);
        }

        // PUT api/events/4
        [HttpPut("{id}")]
        public async Task<ActionResult<Event>> Put(int id, Event ev)
        {
            if (id != ev.Id)
                return BadRequest();
            
           service.Update(ev);

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
            return await Task.FromResult(ev);
        }

        // DELETE api/events/4
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            service.Delete(id);
            await Task.CompletedTask;
        }

      
    }
}