using Microsoft.EntityFrameworkCore;
using _20250317.Models;

namespace _20250317.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options) { }

        public DbSet<AccountModel> Accounts { get; set; }
    }
}
