using System.ComponentModel.DataAnnotations;

namespace Backend_API.Models.Requests
{
    public class UpdateCategoryRequest
    {
       
  
        [Required]
        public string category { get; set; }
    }
}
