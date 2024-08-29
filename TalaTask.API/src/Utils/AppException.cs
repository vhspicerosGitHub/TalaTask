namespace TalaTask.API.src.Utils
{
    public class AppException : Exception
    {

        public AppException(string message, string details = "")
        {
            StatusCode = 500;
            Message = message;
            Details = details;
        }

        public AppException(int statusCode, string message, string details = "")
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
    }
}