using ConsoleApp.Models;
using ConsoleApp.Services;
using System;
using Xunit;

namespace ConsoleApp.Test
{
    public class UserServiceCreateTests
    {
        private readonly UserService _userService;

        public UserServiceCreateTests()
            => _userService = new UserService();

        [Theory(DisplayName = "Given user without name, when creating should be fail")]
        [InlineData("")]
        [InlineData(null)]
        public void GivenUserWithoutNameWhenCreatingShouldBeFail(string name)
        {
            // Arrange
            var userModel = new UserModel(name, new DateTime(1989, 05, 13));

            // Act
            var created = _userService.CreateUser(userModel);

            // Assert
            Assert.False(created);
        }

        [Fact(DisplayName = "Given user underage, when creating should be fail")]
        public void GivenUserUnderageWhenCreatingShouldBeFail()
        {
            // Arrange
            var userModel = new UserModel("Bruce", new DateTime(DateTime.Now.Year - 15, 01, 01));

            // Act
            var created = _userService.CreateUser(userModel);

            // Assert
            Assert.False(created);
        }
    }
}