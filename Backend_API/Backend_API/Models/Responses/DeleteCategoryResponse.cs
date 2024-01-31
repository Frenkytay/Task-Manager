namespace Backend_API.Models.Responses
{
    public class DeleteCategoryResponse
    {
        public int categoryID { get; set; }
        public Guid userID { get; set; }
        public string category { get; set; }
    }
}
