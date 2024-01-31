using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_API.Models
{
    [Table("MsUser")]
    public class User
    {
        [Key]
        [StringLength(50)]
        [MaxLength(50)]

        public Guid userID { get; set; }
        [MaxLength(255)]
        public string userName { get; set; }
        [MaxLength(255)]
        public string userEmail { get; set; }
        [MaxLength(255)]
        public string userPassword { get; set; }
    }
}
