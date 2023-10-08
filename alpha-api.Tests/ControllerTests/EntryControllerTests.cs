using alpha_api.Controllers;
using alpha_api.Models;
using alpha_api.Services;
using alpha_api.Tests.Common;

namespace alpha_api.Tests.ControllerTests
{
    public class EntryControllerTests
    {
        private readonly Mock<IEntryService> entryService;
        public EntryControllerTests()
        {
            entryService = new Mock<IEntryService>();
        }

        [Fact]
        public async Task Get_NoParams_EntryList()
        {
            //arrange
            var testEntries = MockData.Entries.ToList();
            entryService.Setup((x) => x.GetAllAsync()).ReturnsAsync(testEntries.ToList());
            var entryController = new EntryController(entryService.Object);

            //act
            var entryListResult = await entryController.Get();

            //assert
            entryListResult.Value.Should()
                .NotBeNull()
                .And.Match<IEnumerable<Entry>>(d => d.Count() == testEntries.Count())
                .And.BeEquivalentTo(testEntries); 
        }

        [Fact]
        public async Task GetById_WithId_Entry()
        {
            //arrange
            var testEntries = MockData.Entries.ToList();
            entryService.Setup((x) => x.GetAsync(2)).ReturnsAsync(testEntries[1]);
            var entryController = new EntryController(entryService.Object);

            //act
            var entryResult = await entryController.Get(2);

            //assert
            entryResult.Value.Should()
                .NotBeNull()
                .And.Match<Entry>(d => d.Id == testEntries[1].Id);
        }

        [Fact]
        public async Task AddEntry_WithEntry_Entry()
        {
            //arrange
            var testEntry = MockData.Entries.ToList()[1];
            entryService.Setup(x => x.AddAsync(testEntry)).ReturnsAsync(testEntry);
            var entryController = new EntryController(entryService.Object);

            //act
            var entryResult = await entryController.Post(testEntry);

            //assert
            entryResult.Value.Should()
                .NotBeNull()
                .And.Match<Entry>(d => d.Id == testEntry.Id);
        }

        [Fact]
        public async Task UpdateEntry_WithIdAndEntry_Entry()
        {
            //arrange
            var testEntry = MockData.Entries.ToList()[1];
            entryService.Setup(x => x.UpdateAsync(testEntry)).ReturnsAsync(testEntry);
            var entryController = new EntryController(entryService.Object);

            //act
            var entryResult = await entryController.Put(testEntry.Id, testEntry);

            //assert
            entryResult.Value.Should()
                .NotBeNull()
                .And.Match<Entry>(d => d.Id == testEntry.Id);
        }

        [Fact]
        public async Task DeleteEntry_WithId_True()
        {
            //arrange
            var testEntry = MockData.Entries.ToList()[1];
            entryService.Setup(x => x.DeleteAsync(testEntry.Id)).ReturnsAsync(true);
            var entryController = new EntryController(entryService.Object);

            //act
            var entryBoolResult = await entryController.Delete(testEntry.Id);

            //assert
            entryBoolResult.Should()
                .BeTrue();  
        }
    }
}