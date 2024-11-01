using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SciMagazine.Core.Entities;
using SciMagazine.Infrastructure.Identity;

namespace SciMagazine.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }

        public DbSet<Paper> Papers {  get; set; }
        public DbSet<Academic> Academics { get; set; }
        public DbSet<Researcher> Researchers  { get; set; }
        public DbSet<Review> Reviews  { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
