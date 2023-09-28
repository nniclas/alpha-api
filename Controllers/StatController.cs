using alpha_api.Core.Visualization;
using alpha_api.Data;
using alpha_api.Models;
using alpha_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace alpha_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("stats")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class StatController : ControllerBase
    {
        private readonly IStatService service;

        public StatController(IStatService service)
        {
            this.service = service;
        }

        [HttpGet("machine/unit/{unitId}/res/{res}")]
        public async Task<ActionResult<Dictionary<string, StatData>>> GetMachineStats(int unitId, Resolution res)
        {
            var today = DateTime.Parse("2023-08-14"); // replacing today, for demo purposes

            return await this.service.GetMachineStatisticsAsync(
                unitId, 
                new Parameters { Date = today, Resolution = res });
        }

        [HttpGet("entries/unit/{unitId}/res/{res}")]
        public async Task<ActionResult<StatData>> GetEntryStats(int unitId, Resolution res)
        {
            var today = DateTime.Parse("2023-08-14"); // replacing today, for demo purposes

            return await this.service.GetEntryStatisticsAsync(
              unitId,
              new Parameters { Date = today, Resolution = res });
        }
    }
}