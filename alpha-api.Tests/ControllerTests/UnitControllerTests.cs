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
        }

        [Fact]
        public async Task AddUnit_WithUnit_Unit()
        {
            //arrange
            var testUnit = GetUnits().ToList()[1];
            unitService.Setup(x => x.AddAsync(testUnit)).ReturnsAsync(testUnit);
            var unitController = new UnitController(unitService.Object);

            //act
            var unitResult = await unitController.Post(testUnit);

            //assert
            unitResult.Value.Should()
                .NotBeNull()
                .And.Match<Unit>(d => d.Id == testUnit.Id);
        }

        [Fact]
        public async Task UpdateUnit_WithIdAndUnit_Unit()
        {
            //arrange
            var testUnit = GetUnits().ToList()[1];
            unitService.Setup(x => x.UpdateAsync(testUnit)).ReturnsAsync(testUnit);
            var unitController = new UnitController(unitService.Object);

            //act
            var unitResult = await unitController.Put(testUnit.Id, testUnit);

            //assert
            unitResult.Value.Should()
                .NotBeNull()
                .And.Match<Unit>(d => d.Id == testUnit.Id);
        }

        [Fact]
        public async Task DeleteUnit_WithId_True()
        {
            //arrange
            var testUnit = GetUnits().ToList()[1];
            unitService.Setup(x => x.DeleteAsync(testUnit.Id)).ReturnsAsync(true);
            var unitController = new UnitController(unitService.Object);

            //act
            var unitResult = await unitController.Delete(testUnit.Id);

            //assert
            unitResult.Should()
                .BeTrue();  
        }
    }
}