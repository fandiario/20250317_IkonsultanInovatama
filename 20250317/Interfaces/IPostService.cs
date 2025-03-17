using _20250317.Models;

namespace _20250317.Interfaces
{
    public interface IPostService
    {
        Task<List<PostResponse>> GetPost(int pagination);
    }
}
