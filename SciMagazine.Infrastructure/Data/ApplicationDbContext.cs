using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SciMagazine.Core.Entities;
using SciMagazine.Infrastructure.Identity;

namespace SciMagazine.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }


        public DbSet<RegisterApplication> RegisterApplications { get; set; }
        public DbSet<RegisterAttachment> RegisterAttachments { get; set; }
        public DbSet<RequiredAttachment> RequiredRegisterAttachments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RequiredAttachment>()
                .Property(x => x.Type)
                .HasConversion<int>();

            builder.Entity<RegisterAttachment>()
                .Property(x => x.Type)
                .HasConversion<int>();

            builder.Entity<Attachment>()
                .Property(x=>x.EntityType)
                .HasConversion<int>();
        }

    }
}
