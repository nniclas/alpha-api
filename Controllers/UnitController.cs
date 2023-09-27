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
            return await this.service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Unit>> Get(int id)
        {
            var unit = await service.GetAsync(id);
            if (unit == null) return NotFound();
            return unit;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(Unit unit)
        {
            await service.AddAsync(unit);
            return unit;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Put(int id, Unit unit)
        {
            if (id != unit.Id)
                return BadRequest();
            
           await service.UpdateAsync(unit);
            return unit;
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await service.DeleteAsync(id);
        }

      
    }
}