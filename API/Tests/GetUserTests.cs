using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using API.Models;
using System.Net;
using System.Text.Json;

namespace API.Tests
{
    [AllureNUnit]
    public class GetUserTests : BaseApiTest
    {
        [Test]
        [AllureTag("API")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Michał Sługocki")]
        [AllureSuite("User Endpoints")]
        [AllureSubSuite("Positive Tests")]
        [AllureFeature("Get User By Id")]
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
            Assert.Multiple(async () =>
            {
                await AllureApi.Step("Verify Status Code", async () =>
                {
                    Assert.That(getResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                });
                await AllureApi.Step("Verify Content", async () =>
                {
                    Assert.That(getResponse.Content, Is.Not.Null.And.Not.Empty);
                });
                await AllureApi.Step("Verify User Id", async () =>
                {
                    Assert.That(actualUser.Data.Id, Is.EqualTo(expectedUser.Data.Id));
                });
                await AllureApi.Step("Verify User Email", async () =>
                {
                    Assert.That(actualUser.Data.Email, Is.EqualTo(expectedUser.Data.Email));
                });
                await AllureApi.Step("Verify User First Name", async () =>
                {
                    Assert.That(actualUser.Data.First_Name, Is.EqualTo(expectedUser.Data.First_Name));
                });
                await AllureApi.Step("Verify User Last Name", async () =>
                {
                    Assert.That(actualUser.Data.Last_Name, Is.EqualTo(expectedUser.Data.Last_Name));
                });
                await AllureApi.Step("Verify User Avatar", async () =>
                {
                    Assert.That(actualUser.Data.Avatar, Is.EqualTo(expectedUser.Data.Avatar));
                });               
                
            });
        }
    }
}
