using Moq;
using FluentAssertions;
using alpha_api.Controllers;
using alpha_api.Models;
using alpha_api.Services;

namespace alpha_api.Tests.ControllerTests
{
    //  https://www.c-sharpcorner.com/blogs/implementation-of-unit-test-using-xunit-and-moq-in-net-core-6-web-api

    public partial class UnitControllerTests
    {
        private readonly Mock<IUnitService> unitService;
        public UnitControllerTests()
        {
            unitService = new Mock<IUnitService>();
        }

        [Fact]
        public async Task Get_NoParams_UnitList()
        {
            //arrange
            var testUnits = GetUnits();
            unitService.Setup((x) => x.GetAllAsync()).ReturnsAsync(testUnits.ToList());
            var unitController = new UnitController(unitService.Object);

            //act
            var unitListResult = await unitController.Get();

            //assert
            unitListResult.Value.Should()
                .NotBeNull()
                .And.Match<IEnumerable<Unit>>(d => d.Count() == GetUnits().Count())
                .And.BeEquivalentTo(testUnits); 
            
            //Assert.NotNull(unitListResult);
            //Assert.Equal(GetUnits().Count(), unitListResult.Value.Count());
            //Assert.Equal(GetUnits().ToString(), unitListResult.Value.ToString());
        }

        [Fact]
        public async Task GetById_WithId_Unit()
        {
            //arrange
            var testUnits = GetUnits().ToList();
            unitService.Setup((x) => x.GetAsync(2)).ReturnsAsync(testUnits[1]);
            var unitController = new UnitController(unitService.Object);

            //act
            var unitResult = await unitController.Get(2);

            //assert
            unitResult.Value.Should()
                .NotBeNull()
                .And.Match<Unit>(d => d.Id == testUnits[1].Id);

            //Assert.NotNull(unitResult);
            //Assert.Equal(testUnits[1].Id, unitResult.Value.Id);
            //Assert.True(testUnits[1].Id == unitResult.Value.Id);
        }
    }
}