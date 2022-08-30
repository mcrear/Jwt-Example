namespace Jwt.Api.Domain.Response
{
    public class BaseResponse<T> where T : class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        private BaseResponse(bool success, string message, T data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public BaseResponse(string message) : this(false, message, null)
        {

        }
        public BaseResponse(T data) : this(true, string.Empty, data)
        {

        }
    }
}
