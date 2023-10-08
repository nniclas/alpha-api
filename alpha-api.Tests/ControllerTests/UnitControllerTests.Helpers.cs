using Moq;
using alpha_api.Controllers;
using alpha_api.Models;
using alpha_api.Services;

namespace alpha_api.Tests.ControllerTests
{
    public partial class UnitControllerTests
    {
        private IEnumerable<Unit> GetUnits()
        {
            return new List<Unit>
            {
                new Unit
                {
                    Id = 1,
                    MachineId = "xyz",
                    Name = "Alpha",
                    State = 1
                },
                 new Unit
                {
                    Id = 2,
                     MachineId = "qlr",
                    Name = "Beta",
                      State = 2

                },
                 new Unit
                {
                    Id = 3,
                    MachineId = "nmp",
                    Name = "Omega",
                    State = 3

                },
            };
        }
    }
}