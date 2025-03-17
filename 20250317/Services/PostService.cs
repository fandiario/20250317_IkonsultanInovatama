using _20250317.Factories;
using _20250317.Interfaces;
using _20250317.Models;
using System.Text.Json;

using static System.Net.WebRequestMethods;

namespace _20250317.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;
        private readonly PostFactory _postFactory;

        public PostService(HttpClient httpClient, PostFactory postFactory)
        {
            _httpClient = httpClient;
            _postFactory = postFactory;
        }

        public async Task <object> GetPost(int pagination, int sizes)
        {
            var url = "https://jsonplaceholder.typicode.com/posts" ;
            var response = await _httpClient.GetStringAsync(url);
            var data = JsonSerializer.Deserialize<List<PostResponse>>(response);

            if (data != null) {
                var total = data.Count;

                if (pagination == 0)
                {
                    pagination = 1;
                }

                if (sizes == 0)
                {
                    sizes = 5;
                }

                var paginatedData = data.Skip((pagination - 1) * sizes).Take(sizes).ToList();

                var respData = new
                {
                    page = pagination,
                    pageSizes = sizes,
                    totalItems = total,
                    totalPages = (int)Math.Ceiling((double)total/ sizes),
                    data = paginatedData
                };

                return respData;
            }
           

            throw new Exception("Data can't be found");
        }
    }
}
