using Microsoft.Extensions.Configuration.UserSecrets;
using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models.Requests
{
    public class CreateCategoryRequest
    {
        [Required]
        public Guid userID { get; set; }
        [Required]
        public string category {  get; set; }


    }


}
