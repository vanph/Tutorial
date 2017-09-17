using System.Data.Entity;
using MyCountry.DataAccess.Model;

namespace MyCountry.DataAccess.Persistence
{
    public partial class MyCountryEntities : DbContext
    {
        public MyCountryEntities()
            : base("name=MyCountryContext")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.Districts)
                .WithRequired(e => e.City)
                .WillCascadeOnDelete(false);
        }
    }
}
