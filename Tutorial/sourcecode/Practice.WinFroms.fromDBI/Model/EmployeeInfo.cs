namespace Practice.WinFroms.fromDBI.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeeInfo")]
    public partial class EmployeeInfo
    {
        [Key]
        [Column("ID Employee")]
        [StringLength(50)]
        public string ID_Employee { get; set; }

        [Column("Name Employee")]
        [Required]
        [StringLength(250)]
        public string Name_Employee { get; set; }
    }
}
