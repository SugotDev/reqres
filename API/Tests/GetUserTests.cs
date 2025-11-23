using API.Models;
using System.Net;
using System.Text.Json;

namespace API.Tests
{
    public class GetUserTests : BaseApiTest
    {
        [Test]
        public async Task GetUserById()
        {
            //Arrange
            var userId = 2;
            var path = Path.Combine(AppContext.BaseDirectory, "TestData", "ExistingUserData.json");
            var json = File.ReadAllText(path);
            var expectedUser = JsonSerializer.Deserialize<UserResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            //Act
            var getResponse = await _userApi.GetUserByIdAsync(userId);
            var actualUser = JsonSerializer.Deserialize<UserResponse>(getResponse.Content!, _serializerOptions);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(getResponse.Content, Is.Not.Null.And.Not.Empty);
                Assert.That(actualUser.Data.Id, Is.EqualTo(expectedUser.Data.Id));
                Assert.That(actualUser.Data.Email, Is.EqualTo(expectedUser.Data.Email));
                Assert.That(actualUser.Data.First_Name, Is.EqualTo(expectedUser.Data.First_Name));
                Assert.That(actualUser.Data.Last_Name, Is.EqualTo(expectedUser.Data.Last_Name));
                Assert.That(actualUser.Data.Avatar, Is.EqualTo(expectedUser.Data.Avatar));
            });
        }
    }
}
