using Microsoft.EntityFrameworkCore;
using news.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news.domain.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets (tabelas)
        public DbSet<User> Users { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NewTag> NewTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NewTag>()
                .HasKey(nt => new { nt.NewId, nt.TagId });

            modelBuilder.Entity<NewTag>()
                .HasOne(nt => nt.New)
                .WithMany(n => n.NewTags)
                .HasForeignKey(nt => nt.NewId);

            modelBuilder.Entity<NewTag>()
                .HasOne(nt => nt.Tag)
                .WithMany(t => t.NewsTag)
                .HasForeignKey(nt => nt.TagId);

            modelBuilder.Entity<New>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId);

        }
    }
}
