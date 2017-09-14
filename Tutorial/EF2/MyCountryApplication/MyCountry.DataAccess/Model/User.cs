using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCountry.DataAccess.Model
{
    public partial class User
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string Password { get; set; }

        [StringLength(24)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
    }
}
