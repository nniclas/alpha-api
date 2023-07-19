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
    [Route("units")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService service;

        public UnitController(IUnitService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> Get()
        {
            return await Task.FromResult(this.service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Unit>> Get(int id)
        {
            var unit = await Task.FromResult(service.Get(id));
            if (unit == null)
            {
                return NotFound();
            }
            return unit;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(Unit unit)
        {
            service.Add(unit);
            return await Task.FromResult(unit);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Put(int id, Unit unit)
        {
            if (id != unit.Id)
                return BadRequest();
            
           service.Update(unit);

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
            return await Task.FromResult(unit);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            service.Delete(id);
            await Task.CompletedTask;
        }

      
    }
}