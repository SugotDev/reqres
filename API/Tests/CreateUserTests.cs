using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Tests
{
    public class CreateUserTests : BaseApiTest
    {
        [Test]
        public async Task CreateUser()
        {
            //Arrange
            var user = _users["JohnTester"];

            //Act
            var postResponse = await _userApi.CreateUserAsync(user);
            var createdUser = JsonSerializer.Deserialize<CreateUserResponse>(postResponse.Content!, _serializerOptions);

            //Assert
            Assert.That(postResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.That(createdUser.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdUser.Email, Is.EqualTo(user.Email));
            Assert.That(createdUser.FirstName, Is.EqualTo(user.FirstName));
            Assert.That(createdUser.LastName, Is.EqualTo(user.LastName));
            Assert.That(createdUser.CreatedAt, Is.Not.EqualTo(default(DateTime)));
            Assert.That(createdUser.CreatedAt, Is.InRange(
                DateTime.UtcNow.AddMinutes(-1),
                DateTime.UtcNow.AddMinutes(1)
            ));

        }
    }
}
