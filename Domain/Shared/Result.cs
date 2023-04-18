namespace Domain.Shared;

public partial class Result
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }

    public Result(bool success, string errorMessage = null)
    {
        Success = success;
        ErrorMessage = errorMessage;
    }

    public static Result SuccessResult()
    {
        return new Result(true);
    }
    public static Result FailureResult(string errorMessage)
    {
        return new Result(false, errorMessage);
    }
}

public partial class Result<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string ErrorMessage { get; set; }

    public Result(bool success, T data, string errorMessage = null)
    {
        Success = success;
        Data = data;
        ErrorMessage = errorMessage;
    }

    public static Result<T> SuccessResult(T data)
    {
        return new Result<T>(true, data);
    }

    public static Result<T> FailureResult(string errorMessage)
    {
        return new Result<T>(false, default(T), errorMessage);
    }
}
