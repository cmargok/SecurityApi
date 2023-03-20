using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Security.Infrastructure.Persistence.Configurations.Security;

namespace Security.Infrastructure.Persistence
{
    public class ApplicationDBContext : IdentityDbContext<ApiUser>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
