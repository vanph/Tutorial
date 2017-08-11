namespace Practice.WinFroms.fromDBI.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=EmployeeContext")
        {
        }

        public virtual DbSet<EmployeeInfo> EmployeeInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
