namespace RedSecure.Application.Utils
{
    public class ApiResponse<T>
    {
        public T? Value { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool Error { get; set; }

    }
}
