using _20250317.Interfaces;

namespace _20250317.Factories
{
    public class PostFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PostFactory (IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPostService GetData(int pagination, int sizes)
        {
            return _serviceProvider.GetRequiredService<IPostService> ();
        }
    }
}
