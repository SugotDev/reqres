using API.API;
using API.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Text.Json;

namespace API
{
    public abstract class BaseApiTest
    {
        protected RestClient Client;
        protected IConfiguration _config;
        protected UserApi _userApi;
        protected Dictionary<string, CreateUserRequest> _users;
        protected JsonSerializerOptions _serializerOptions;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var baseUrl = _config["BaseUrl"];

            if (string.IsNullOrEmpty(baseUrl))
                throw new ArgumentException("BaseUrl not found in appsettings.json");

            Client = new RestClient(baseUrl);
            Client.AddDefaultHeader("Accept", "application/json");
            Client.AddDefaultHeader("x-api-key", _config["ApiKey"]);

            _userApi = new UserApi(Client);
        }

        [SetUp]
        public void Setup()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "TestData", "NewUserData.json");
            if (!File.Exists(path))
                throw new FileNotFoundException($"Test data file not found: {path}");

            var json = File.ReadAllText(path);
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _users = JsonSerializer.Deserialize<Dictionary<string, CreateUserRequest>>(json, _serializerOptions)
                    ?? throw new Exception("Failed to deserialize user test data.");
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            Client?.Dispose();
        }

    }
}
