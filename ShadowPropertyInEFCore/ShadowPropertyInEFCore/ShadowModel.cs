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

        public DbSet<Shadow> Shadows { get; set; }
    }

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
}
