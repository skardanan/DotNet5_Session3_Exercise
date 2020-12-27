using DotNet5_Session3_Exercise.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace DotNet5_Session3_Exercise.DB
{
    public class Context : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database=Dotnet5Session3;User Id =sa;Password=1540; MultipleActiveResultSets=true");
        }

        public override int SaveChanges()
        {
            this.ChangeTracker.DetectChanges();
            var deleted = this.ChangeTracker.Entries()
                        .Where(t => t.State == EntityState.Deleted)
                        .Select(t => t.Entity)
                        .ToArray();

            foreach (var entity in deleted)
            {
                if (entity is BaseEntity)
                {
                    var track = entity as BaseEntity;
                    track.Deleted = true;
                    this.Entry(entity).State = EntityState.Modified;
                }
            }

            return base.SaveChanges();
        }
    }
}
