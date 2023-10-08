using alpha_api.Controllers;
using alpha_api.Models;
using alpha_api.Services;
using alpha_api.Tests.Common;
using alpha_api.Data;
using System.Linq;

namespace alpha_api.Tests.ControllerTests
{
    public class UnitServiceTests
    {
        private readonly Mock<IRepository<Unit>> unitRepository;
        public UnitServiceTests()
        {
            unitRepository = new Mock<IRepository<Unit>>();
        }

        [Fact]
        public async Task GetAllAsync_NoParams_UnitList()
        {
            //arrange
            var testUnits = MockData.Units.ToList();
            unitRepository.Setup((x) => x.GetAllAsync()).ReturnsAsync(testUnits.ToList());
            var unitService = new UnitService(unitRepository.Object);

            //act
            var entryListResult = await unitService.GetAllAsync();

            //assert
            entryListResult.Should()
                .NotBeNull()
                .And.Match<IEnumerable<Unit>>(d => d.Count() == testUnits.Count())
                .And.BeEquivalentTo(testUnits); 
        }

        [Fact]
        public async Task GetAsync_WithId_Unit()
        {
            //arrange
            var testUnits = MockData.Units.ToList();
            unitRepository.Setup((x) => x.GetAsync(2)).ReturnsAsync(testUnits[1]);
            var unitService = new UnitService(unitRepository.Object);

            //act
            var unitResult = await unitService.GetAsync(2);

            //assert
            unitResult.Should()
                .NotBeNull()
                .And.Match<Unit>(d => d.Id == testUnits[1].Id);
        }

        [Fact]
        public async Task AddAsync_WithUnit_Unit()
        {
            //arrange
            var testUnit = MockData.Units.ToList()[1];
            unitRepository.Setup(x => x.CreateAsync(testUnit)).ReturnsAsync(testUnit);
            var unitService = new UnitService(unitRepository.Object);

            //act
            var unitResult = await unitService.AddAsync(testUnit);

            //assert
            unitResult.Should()
                .NotBeNull()
                .And.Match<Unit>(d => d.Id == testUnit.Id);
        }

        [Fact]
        public async Task UpdateAsync_WithUnit_Unit()
        {
            //arrange
            var testUnit = MockData.Units.ToList()[1];
            unitRepository.Setup(x => x.UpdateAsync(testUnit)).ReturnsAsync(testUnit);
            var unitService = new UnitService(unitRepository.Object);

            //act
            var unitResult = await unitService.UpdateAsync(testUnit);

            //assert
            unitResult.Should()
                .NotBeNull()
                .And.Match<Unit>(d => d.Id == testUnit.Id);
        }

        [Fact]
        public async Task DeleteAsync_WithId_True()
        {
            //arrange
            var testUnit = MockData.Units.ToList()[1];
            unitRepository.Setup(x => x.DeleteAsync(testUnit.Id)).ReturnsAsync(true);
            var unitService = new UnitService(unitRepository.Object);

            //act
            var unitBoolResult = await unitService.DeleteAsync(testUnit.Id);

            //assert
            unitBoolResult.Should()
                .BeTrue();
        }
    }
}