namespace WebApplication9.Domain
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public string Message { get; set; }
    }
}
