using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models.Requests
{
    public class LoginUserRequest
    {
       
        [Required]
        [EmailAddress]
        public string userEmail { get; set; }
        [Required]
       
        public string userPassword { get; set; }

    }
}
