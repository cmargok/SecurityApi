using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Security.Application.Models.Security;
using Security.Domain.Entities;
using Security.Infrastructure.Persistence.Configurations.Security;

namespace Security.Infrastructure.Persistence
{
    public class IdentityDBContext : IdentityDbContext<ApiUser>
    {
        public DbSet<PreRegister> PreRegisters { get; set; }

        public IdentityDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }

  
}

//public IdentityDBContext()
//{

//}

//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//{
//    optionsBuilder.UseSqlServer("Server=DESKTOP-3VP26G1\\CMARGOKCLU1; Database=CmargokSecurityApiDB; Persist Security Info=True; Trusted_Connection=True; MultipleActiveResultSets=True; TrustServerCertificate=true;");
//}