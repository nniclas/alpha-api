using alpha_api.Controllers;
using alpha_api.Models;
using alpha_api.Services;
using alpha_api.Tests.Common;
using Moq;

namespace alpha_api.Tests.ControllerTests
{
    //  https://www.c-sharpcorner.com/blogs/implementation-of-unit-test-using-xunit-and-moq-in-net-core-6-web-api

    public class AccountControllerTests
    {
        private readonly Mock<IUserService> userService;
        public AccountControllerTests()
        {
            userService = new Mock<IUserService>();
        }

        [Fact(Skip = "Not implemented")]
        public async Task SignIn_WithInvalidRequest_BadRequestResult()
        {
            //arrange
            var request = new SignInRequest { Email = "john@doe.com", Password = "secret" };

            throw new NotImplementedException();
        }

        [Fact(Skip = "Not implemented")]
        public async Task SignIn_WithValidRequest_OkResult()
        {
            ////arrange
            var request = new SignInRequest { Email = "john@doe.com", Password = "eple" };

            throw new NotImplementedException();
        }
    }
}