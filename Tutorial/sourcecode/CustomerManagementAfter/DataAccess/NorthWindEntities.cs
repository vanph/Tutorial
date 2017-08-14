using System.Data.Entity;

namespace CustomerManagement.DataAccess
{
    public partial class NorthWindEntities : DbContext
    {
        public NorthWindEntities()
            : base("name=NorthWindEntities1")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerID)
                .IsFixedLength();
        }
    }
}
