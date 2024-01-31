using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_API.Models
{
    [Table("MsCategory")]
    public class Category
    {
        [Key]
        public int categoryID { get; set; }

        [ForeignKey("User")]

        public Guid userID { get; set; }
        [MaxLength(255)]
        public string category { get; set; }
        public User User { get; set; }

    }
}
