namespace Backend_API.Models.Responses
{
    public class GetCategoryResponse
    {

        public int categoryID { get; set; }
        public Guid userID { get; set; }
        public string category { get; set; }
    }
}
