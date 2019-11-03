using System;

namespace ShadowPropertyInEFCore
{
    using Microsoft.EntityFrameworkCore;

    public class ShadowDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .; Database = ShadowDbContext; Trusted_Connection = True; MultipleActiveResultSets = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //creating navigation or shadow properties for single entity
            modelBuilder.Entity<Article>().Property<DateTime>("CreatedDate");
        }

        public DbSet<Shadow> Shadows { get; set; }

        public DbSet<Article> Articles { get; set; }
    }

    #region The old way to use and access

    public class Shadow : ITracking
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public interface ITracking
    {
        DateTime CreatedDate { get; set; }
    }

    #endregion The old way to use and access

    #region The new way to use and access

    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    #endregion The new way to use and access
}
