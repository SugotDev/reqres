using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using API.Models;
using System.Net;
using System.Text.Json;

namespace API.Tests
{
    [AllureNUnit]
    public class CreateUserTests : BaseApiTest
    {
        [Test]
        [AllureTag("API")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Michał Sługocki")]
        [AllureSuite("User Endpoints")]
        [AllureSubSuite("Positive Tests")]
        [AllureFeature("Create New User")]
        public async Task CreateUser()
        {
            //Arrange
            var user = _users["JohnTester"];

            //Act
            var postResponse = await _userApi.CreateUserAsync(user);
            var createdUser = JsonSerializer.Deserialize<CreateUserResponse>(postResponse.Content!, _serializerOptions);

            //Assert
            await AllureApi.Step("Verify Status Code", async () =>
            {
                Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            });
            await AllureApi.Step("Verify Create User Response", async () =>
            {
                Assert.That(postResponse.Content, Is.Not.Null.And.Not.Empty);
            });
            await AllureApi.Step("Verify Created User Id Exist", async () =>
            {
                Assert.That(createdUser.Id, Is.Not.Null.And.Not.Empty);
            });
            await AllureApi.Step("Verify Created User Email", async () =>
            {
                Assert.That(createdUser.Email, Is.EqualTo(user.Email));
            });
            await AllureApi.Step("Verify Created User First Name", async () =>
            {
                Assert.That(createdUser.FirstName, Is.EqualTo(user.FirstName));
            });
            await AllureApi.Step("Verify Created User Last Name", async () =>
            {
                Assert.That(createdUser.LastName, Is.EqualTo(user.LastName));
            });
            await AllureApi.Step("Verify Created User Date", async () =>
            {
                Assert.That(createdUser.CreatedAt, Is.Not.EqualTo(default(DateTime)));
                Assert.That(createdUser.CreatedAt, Is.InRange(
                    DateTime.UtcNow.AddMinutes(-1),
                    DateTime.UtcNow.AddMinutes(1)
                    ));
            });
        }
    }
}
