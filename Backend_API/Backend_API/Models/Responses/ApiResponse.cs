namespace Backend_API.Models.Responses
{
    public class ApiResponse<T>
    {
        public int statusCode { get; set; }
        public string requestMethod { get; set; }
        public string massage { get; set; }
        public List<T> data { get; set; }
    }
}
