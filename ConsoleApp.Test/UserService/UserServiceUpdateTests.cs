using ConsoleApp.Models;
using ConsoleApp.Services;
using System;
using Xunit;

namespace ConsoleApp.Test
{
    public class UserServiceUpdateTests
    {
        private readonly UserService _userService;

        public UserServiceUpdateTests()
            => _userService = new UserService();

        [Theory(DisplayName = "Given user without name, when updating should be fail")]
        [InlineData("")]
        [InlineData(null)]
        public void GivenUserWithoutNameWhenUpdatingShouldBeFail(string name)
        {
            // Arrange
            var userModel = new UserModel(1, name, new DateTime(1989, 05, 13));

            // Act
            var created = _userService.UpdateUser(userModel);

            // Assert
            Assert.False(created);
        }

        [Fact(DisplayName = "Given user underage, when updating should be fail")]
        public void GivenUserUnderageWhenUpdatingShouldBeFail()
        {
            // Arrange
            var userModel = new UserModel(1, "Bruce", new DateTime(DateTime.Now.Year - 15, 01, 01));

            // Act
            var created = _userService.UpdateUser(userModel);

            // Assert
            Assert.False(created);
        }

        [Theory(DisplayName = "Given user with invalid id, when updating should be fail")]
        [InlineData(-5)]
        [InlineData(0)]
        public void GivenUserWitInvalidIdWhenUpdatingShouldBeFail(int id)
        {
            // Arrange
            var userModel = new UserModel(id, "Bruce", new DateTime(1989, 05, 13));

            // Act
            var created = _userService.UpdateUser(userModel);

            // Assert
            Assert.False(created);
        }
    }
}