using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models.Requests
{
    public class UserRequest
    {
        [Required]
        public string userName { get; set; }
        [Required]
        [EmailAddress]
        public string userEmail { get; set; }
        [Required]
        public string userPassword {  get; set; }
        [Required]
        public string userConfirmPassword { get; set; }

    }
}
