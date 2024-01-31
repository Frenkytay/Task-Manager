using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models.Requests
{
    public class GetUserIdRequest
    {
        [Required]
        public Guid userID { get; set; }
    }
}
