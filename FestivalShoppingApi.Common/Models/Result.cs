using System.Net;
using System.Text.Json.Serialization;

namespace FestivalShoppingApi.Common.Models;

public class Result<T>
{
    public required bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    [JsonIgnore]
    public int ResponseCode { get; init; }
    public T? Data { get; init; }
    
    public static Result<T> SuccessResult(T data, string message = "", HttpStatusCode responseCode = HttpStatusCode.OK) =>
        new() { Success = true, Message = message, ResponseCode = (int)responseCode, Data = data };

    public static Result<T> FailureResult(string message, HttpStatusCode responseCode = HttpStatusCode.InternalServerError) =>
        new() { Success = false, Message = message, ResponseCode = (int)responseCode, Data = default };
}

public class Result
{
    public required bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    [JsonIgnore]
    public int ResponseCode { get; init; }

    public static Result SuccessResult(string message = "", HttpStatusCode responseCode = HttpStatusCode.OK) =>
        new() { Success = true, Message = message, ResponseCode = (int)responseCode };

    public static Result FailureResult(string message, HttpStatusCode responseCode = HttpStatusCode.InternalServerError) =>
        new() { Success = false, Message = message, ResponseCode = (int)responseCode };
}