namespace _20250317.Models
{
    public class PostModel
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

    public class PostResponse
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    
}
