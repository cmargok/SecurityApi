using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedSecure.Application.Models.Security;
using RedSecure.Domain.Entities;
using RedSecure.Infrastructure.Persistence.Configurations.Security;

namespace RedSecure.Infrastructure.Persistence
{
    public class ApplicationDBContext : IdentityDbContext<ApiUser>
    {
        public DbSet<PreRegister> PreRegisters { get; set; }

   
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = CMARGOK\\SQLEXPRESS; Database = CmargokSecurityApiDB; Persist Security Info = True; Trusted_Connection = True; MultipleActiveResultSets = True; TrustServerCertificate = true; ");
        //}


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
