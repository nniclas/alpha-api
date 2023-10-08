using Moq;
using FluentAssertions;
using alpha_api.Controllers;
using alpha_api.Models;
using alpha_api.Services;
using alpha_api.Tests.Common;
using alpha_api.Data;
using System.Linq;

namespace alpha_api.Tests.ControllerTests
{
    public class EntryServiceTests
    {
        private readonly Mock<IRepository<Entry>> entryRepository;
        public EntryServiceTests()
        {
            entryRepository = new Mock<IRepository<Entry>>();
        }

        [Fact]
        public async Task GetAllAsync_NoParams_EntryList()
        {
            //arrange
            var testEntries = MockData.Entries.ToList();
            entryRepository.Setup((x) => x.GetAllAsync()).ReturnsAsync(testEntries.ToList());
            var entryService = new EntryService(entryRepository.Object);

            //act
            var entryListResult = await entryService.GetAllAsync();

            //assert
            entryListResult.Should()
                .NotBeNull()
                .And.Match<IEnumerable<Entry>>(d => d.Count() == testEntries.Count())
                .And.BeEquivalentTo(testEntries); 
        }

        [Fact]
        public async Task GetAllByUnitAsync_WithUnitId_Entry()
        {
            //arrange
            var testUnitId = 1;
            var testEntries = MockData.Entries.ToList();
            var expectedResultCount = 2;
            var expectedResultEntries = testEntries.Where((x) => x.UnitId == testUnitId).ToList();
            entryRepository.Setup((x) => x.QueryAsync((e) => e.UnitId == testUnitId))
                .ReturnsAsync(expectedResultEntries);
            var entryService = new EntryService(entryRepository.Object);

            //act
            var entryListResult = await entryService.GetAllByUnitAsync(testUnitId);

            //assert
            entryListResult.Should()
                .NotBeNull()
                .And.Match<IEnumerable<Entry>>(d => d.Count() == expectedResultCount)
                .And.BeEquivalentTo(expectedResultEntries);
        }

        [Fact]
        public async Task GetAsync_WithId_Entry()
        {
            //arrange
            var testEntries = MockData.Entries.ToList();
            entryRepository.Setup((x) => x.GetAsync(2)).ReturnsAsync(testEntries[1]);
            var entryService = new EntryService(entryRepository.Object);

            //act
            var entryResult = await entryService.GetAsync(2);

            //assert
            entryResult.Should()
                .NotBeNull()
                .And.Match<Entry>(d => d.Id == testEntries[1].Id);
        }

        [Fact]
        public async Task AddAsync_WithEntry_Entry()
        {
            //arrange
            var testEntry = MockData.Entries.ToList()[1];
            entryRepository.Setup(x => x.CreateAsync(testEntry)).ReturnsAsync(testEntry);
            var entryService = new EntryService(entryRepository.Object);

            //act
            var entryResult = await entryService.AddAsync(testEntry);

            //assert
            entryResult.Should()
                .NotBeNull()
                .And.Match<Entry>(d => d.Id == testEntry.Id);
        }

        [Fact]
        public async Task UpdateAsync_WithEntry_Entry()
        {
            //arrange
            var testEntry = MockData.Entries.ToList()[1];
            entryRepository.Setup(x => x.UpdateAsync(testEntry)).ReturnsAsync(testEntry);
            var entryService = new EntryService(entryRepository.Object);

            //act
            var entryResult = await entryService.UpdateAsync(testEntry);

            //assert
            entryResult.Should()
                .NotBeNull()
                .And.Match<Entry>(d => d.Id == testEntry.Id);
        }

        [Fact]
        public async Task DeleteAsync_WithId_True()
        {
            //arrange
            var testEntry = MockData.Entries.ToList()[1];
            entryRepository.Setup(x => x.DeleteAsync(testEntry.Id)).ReturnsAsync(true);
            var entryService = new EntryService(entryRepository.Object);

            //act
            var entryBoolResult = await entryService.DeleteAsync(testEntry.Id);

            //assert
            entryBoolResult.Should()
                .BeTrue();
        }
    }
}