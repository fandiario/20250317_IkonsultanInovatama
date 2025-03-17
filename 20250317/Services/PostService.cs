using _20250317.Models;
using System.Text.Json;

using static System.Net.WebRequestMethods;

namespace _20250317.Services
{
    public class PostService
    {
        private readonly HttpClient _httpClient;

        protected PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task <List<PostResponse>> GetPost(int pagination, int sizes)
        {
            var url = "https://jsonplaceholder.typicode.com/posts" ;
            var response = await _httpClient.GetStringAsync(url);
            var data = JsonSerializer.Deserialize<PostResponse>(response);

            if (data != null) {
               return new List<PostResponse> { data };
            }

            throw new Exception("Data can't be found");

        }
    }
}
