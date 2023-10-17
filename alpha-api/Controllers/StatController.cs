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
    [Authorize]
    [ApiController]
    [Route("stats")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class StatController : ControllerBase
    {
        private readonly string TODAY = "2023-08-14"; // replacing today, for demo purposes

        private readonly IStatService service;

        public StatController(IStatService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Retrieve machine statistics grouped by machine elements
        /// </summary>
        /// <param name="unitId">The id of the unit</param>
        /// <param name="res">A resolution window as the period</param>
        /// <returns>Returns a dictionary of machine statistics</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpGet("machine/unit/{unitId}/res/{res}")]
        public async Task<ActionResult<Dictionary<string, StatData>>> GetMachineStats(int unitId, Resolution res)
        {
            var today = DateTime.Parse(TODAY);

            return await this.service.GetMachineStatisticsAsync(
                unitId, 
                new Parameters { Date = today, Resolution = res });
        }

        /// <summary>
        /// Retrieve entry statistics
        /// </summary>
        /// <param name="unitId">The id of the unit</param>
        /// <param name="res">A resolution window as the period</param>
        /// <returns>Returns entry statistics</returns>
        /// <returns>Returns 200 OK success</returns>
        /// <returns>Returns 400 Bad Request error</returns>
        /// <returns>Returns 500 Internal Server Error</returns>
        [HttpGet("entries/unit/{unitId}/res/{res}")]
        public async Task<ActionResult<StatData>> GetEntryStats(int unitId, Resolution res)
        {
            var today = DateTime.Parse(TODAY);

            return await this.service.GetEntryStatisticsAsync(
              unitId,
              new Parameters { Date = today, Resolution = res });
        }
    }
}