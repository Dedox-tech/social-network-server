using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetworkServer.Entities;

namespace SocialNetworkServer.Data
{
    public class ApplicationDatabaseContext : IdentityDbContext
    {
        public ApplicationDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }

    }
}
