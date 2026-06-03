namespace DilcomEducationCenter.Domain.Common;

public sealed class Result<TData>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess; 
    public TData? Data { get; }
    public Error? Error { get; }

    private Result(bool isSuccess, TData? data, Error? error)
    {
        IsSuccess = isSuccess;
        Data = data;
        Error = error;
    }

    public static Result<TData> Success(TData data)
    {
        return new Result<TData>(true, data, default);
    }
    public static Result<TData> Failure(Error error)
    {
        return new Result<TData>(false, default, error);
    }
}