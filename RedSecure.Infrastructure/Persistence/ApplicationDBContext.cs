using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using RedSecure.Application.Models.Security;
using RedSecure.Domain.Entities;
using RedSecure.Infrastructure.Persistence.Configurations.Security;

namespace RedSecure.Infrastructure.Persistence
{
    public class ApplicationDBContext : IdentityDbContext<ApiUser>
    {
        public DbSet<PreRegister> PreRegisters { get; set; }
        public virtual DbSet<TokenLog> Tokens { get; set; }

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost,1433; Initial Catalog=CmargokSecurityApiDB; Persist Security Info=True; User ID=sa;Password=Dikelu0102@1; MultipleActiveResultSets=True; TrustServerCertificate=true; Encrypt=True;");
        //     optionsBuilder.ConfigureWarnings(c => c.Ignore(RelationalEventId.PendingModelChangesWarning));
        //}


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
