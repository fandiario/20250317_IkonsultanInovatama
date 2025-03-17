using _20250317.Models;

namespace _20250317.Interfaces
{
    public interface IPostService
    {
        Task<object> GetPost(int pagination, int sizes);
    }
}
