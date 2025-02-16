using DataAccess.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace DataAccess.EF.DBContext
{
    public class AppTicketDBContext(DbContextOptions<AppTicketDBContext> options) : DbContext(options)
    {
        public DbSet<Organization> Organizations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer("Server=localhost;Database=AppTicketV2;User Id=sa; Password=123;TrustServerCertificate=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("SampleEntity");

            
            modelBuilder.Entity<Organization>()
                .HasMany(org => org.Portals)
                .WithOne(p => p.Organization)
                .HasForeignKey(p => p.OrgID);

            modelBuilder.Entity<Organization>()
                .Property(p => p.CreatedDate).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Organization>()
                .Property(p => p.CreatedDateFa).HasDefaultValueSql("dbo.M2S(GETDATE())");

            modelBuilder.Entity<Widget>()
                .HasMany(w => w.Portals)
                .WithOne(p => p.Widget)
                .HasForeignKey(p => p.WidgetID);

            modelBuilder.Entity<Operator>()
                .HasMany<Role>(o => o.Roles)
                .WithMany(r => r.Operators)
                .UsingEntity<OperatorRole>(
                    l => l.HasOne<Role>(or => or.Role).WithMany(r => r.OperatorRoles).HasPrincipalKey(r => r.RoleID),
                    r => r.HasOne<Operator>(or => or.Operator).WithMany(o => o.OperatorRoles).HasPrincipalKey(o => o.OperatorID)
                );

            
        }
        public DbSet<DataAccess.EF.Models.Widget> Widget { get; set; } = default!;
        public DbSet<DataAccess.EF.Models.Portal> Portal { get; set; } = default!;
        public DbSet<DataAccess.EF.Models.Message> Message { get; set; } = default!;
        public DbSet<DataAccess.EF.Models.Operator> Operator { get; set; } = default!;
        public DbSet<DataAccess.EF.Models.Role> Role { get; set; } = default!;

        
    }
}

