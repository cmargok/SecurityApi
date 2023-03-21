using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Security.Application.Models.Security;
using Security.Domain.Entities;
using Security.Infrastructure.Persistence.Configurations.Security;

namespace Security.Infrastructure.Persistence
{
    public class ApplicationDBContext : IdentityDbContext<ApiUser>
    {
        public DbSet<PreRegister> PreRegisters { get; set; }

      /*  public ApplicationDBContext()
        {
                
        }*/
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
