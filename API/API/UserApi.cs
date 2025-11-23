using API.Models;
using RestSharp;

namespace API.API
{
    public class UserApi
    {
        private readonly RestClient _client;

        public UserApi(RestClient client)
        {
            _client = client;
        }

        public async Task<RestResponse> CreateUserAsync(CreateUserRequest user)
        {
            var request = new RestRequest("api/users", Method.Post);
            request.AddJsonBody(user);
            return await _client.ExecuteAsync(request);
        }

        public async Task<RestResponse> GetUserByIdAsync(int userId)
        {
            var request = new RestRequest($"api/users/{userId}", Method.Get);
            return await _client.ExecuteAsync(request);
        }
    }
}
