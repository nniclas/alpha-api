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
    [Route("events")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class EventController : ControllerBase
    {
        private readonly IEventService service;

        public EventController(IEventService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            return await Task.FromResult(this.service.GetAll());
        }

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

        [HttpPost]
        public async Task<ActionResult<Event>> Post(Event ev)
        {
            service.Add(ev);
            return await Task.FromResult(ev);
        }

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

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            service.Delete(id);
            await Task.CompletedTask;
        }

      
    }
}