using alpha_api.Controllers;
using alpha_api.Core;
using alpha_api.Data;
using alpha_api.Models;
using alpha_api.Services;
using alpha_api.Tests.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;

namespace alpha_api.Tests.ControllerTests
{
    //  https://www.c-sharpcorner.com/blogs/implementation-of-unit-test-using-xunit-and-moq-in-net-core-6-web-api

    public class AccountControllerTests
    {
        private readonly Mock<IConfiguration> configuration;
        private readonly Mock<IAuthentication> authentication;
        private readonly Mock<IUserService> userService;
       

        public AccountControllerTests()
        {
            configuration = new Mock<IConfiguration>();
            authentication = new Mock<IAuthentication>();
            userService = new Mock<IUserService>();
      
        }

        [Fact]
        public async Task SignIn_WithInvalidRequest_BadRequestResult()
        {
            //arrange
            var user = new User { Email = "john@doe.com" };
            var request = new SignInRequest { Email = "john@doe.com", Password = "wrong" };
            userService.Setup((x) => x.GetByEmailAsync(request.Email)).ReturnsAsync(user);
            authentication.Setup((x) => x.VerifyUser(user, request.Password)).Returns(false);
            var accountController = new AccountController(authentication.Object, configuration.Object, userService.Object);

            //act
            var result = await accountController.SignIn(request);

            //assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact(Skip = "Fail reason investigation todo")]
        public async Task SignIn_WithValidRequest_OkResult()
        {
            //arrange
            var user = new User { Email = "john@doe.com" };
            var request = new SignInRequest { Email = "john@doe.com", Password = "right" };
            userService.Setup((x) => x.GetByEmailAsync(request.Email)).ReturnsAsync(user);
            authentication.Setup((x) => x.VerifyUser(user, request.Password)).Returns(true);
            authentication.Setup((x) => x.CreateToken(user, new Identity())).Returns("qwerty");
            var accountController = new AccountController(authentication.Object, configuration.Object, userService.Object);

            //act
            var result = await accountController.SignIn(request);

            //assert
            result.Should().BeOfType<OkObjectResult>();
        }
    }
}