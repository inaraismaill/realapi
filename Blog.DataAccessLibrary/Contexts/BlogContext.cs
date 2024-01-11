using Blog.Core.Entities;
using Blog.Core.Entities.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Blog.DAL.Contexts
{
    public class BlogContext:IdentityDbContext
    {
        public BlogContext(DbContextOptions options) : base(options) { }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Filee> Filees { get; set; }
        public DbSet<Blogg> Bloggs { get; set; }
        public DbSet<BloggTopic> BloggTopics { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                    entry.Entity.CreatedTime = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(TopicConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<IdentityUser>().Ignore(b => b.PhoneNumber)
            .Ignore(b => b.PhoneNumberConfirmed);
            base.OnModelCreating(modelBuilder);
        }
    }
}
