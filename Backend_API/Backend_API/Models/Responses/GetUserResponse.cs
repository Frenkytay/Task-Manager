using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models.Responses
{
    public class GetUserResponse
    {
        public Guid userID { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string userEmail { get; set; }
    }
}
