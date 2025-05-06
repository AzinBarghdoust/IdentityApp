namespace IdentityApp.Application.Common.Responses
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T Data { get; set; }

        public Response(T data, string message = "", bool success = true)
        {
            Data = data;
            Message = message;
            Success = success;
        }

        public Response(string message, bool success = false)
        {
            Message = message;
            Success = success;
        }

        public Response() { }
    }
}
