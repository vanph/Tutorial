using System.Data.Entity;
using MyCountry.DataAccess.Model;

namespace MyCountry.DataAccess.Persistence
{
    public partial class LoginEntities : DbContext
    {
        public LoginEntities()
            : base("name=LoginEntities1")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.UserID)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsFixedLength();
        }
    }
}
