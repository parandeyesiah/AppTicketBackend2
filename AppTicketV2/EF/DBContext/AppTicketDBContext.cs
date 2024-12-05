using AppTicketV2.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTicketV2.EF.DBContext
{
    public class AppTicketDBContext:DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(optionsBuilder.GetConnectionString("ConnectionString"));
        }
        public AppTicketDBContext(DbContextOptions<AppTicketDBContext> options) : base(options)
        {
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
        public DbSet<AppTicketV2.EF.Models.Widget> Widget { get; set; } = default!;
        public DbSet<AppTicketV2.EF.Models.Portal> Portal { get; set; } = default!;
        public DbSet<AppTicketV2.EF.Models.Message> Message { get; set; } = default!;
        public DbSet<AppTicketV2.EF.Models.Operator> Operator { get; set; } = default!;
        public DbSet<AppTicketV2.EF.Models.Role> Role { get; set; } = default!;

        
    }
}

