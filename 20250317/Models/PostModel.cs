namespace _20250317.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class PostResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
