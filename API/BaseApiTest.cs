using RestSharp;
using Microsoft.Extensions.Configuration;

namespace API
{
    public abstract class BaseApiTest
    {
        protected RestClient Client;
        protected IConfiguration _config;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var baseUrl = _config["Credentials:BaseUrl"];
            if (string.IsNullOrEmpty(baseUrl))
                throw new ArgumentException("BaseUrl not found in appsettings.json");

            Client = new RestClient(baseUrl);
        }
    }
}
