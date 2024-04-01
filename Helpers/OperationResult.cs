namespace App.Helpers
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public T? Result { get; set; }
        public string? ErrorMessage { get; set; }
        public int StatusCode { get; set; }

        public static OperationResult<T> SuccessResult(T? result)
        {
            return new OperationResult<T> { Success = true, Result = result, StatusCode = 200 };
        }

        public static OperationResult<T> FailureResult(string errorMessage, int statusCode = 400)
        {
            return new OperationResult<T> { Success = false, ErrorMessage = errorMessage, StatusCode = statusCode };
        }
    }
}
