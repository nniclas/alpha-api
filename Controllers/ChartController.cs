using alpha_api.Core.Visualization;
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
    [Route("chart")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class ChartController : ControllerBase
    {
        private readonly IChartService service;

        public ChartController(IChartService service)
        {
            this.service = service;
        }

        [HttpGet("machineStats")]
        public async Task<ActionResult<ChartData>> GetMachineStats(int unitId, Parameters p, string element)
        {
            return await Task.FromResult(this.service.GetMachineStatistics(unitId, p, element));
        }

        [HttpGet("entryStats")]
        public async Task<ActionResult<ChartData>> GetEntryStats(int unitId, Parameters p)
        {
            return await Task.FromResult(this.service.GetEntryStatistics(unitId, p));
        }
    }
}