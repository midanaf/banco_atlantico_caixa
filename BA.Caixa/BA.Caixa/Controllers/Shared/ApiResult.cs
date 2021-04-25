using BA.Caixa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BA.Caixa.Controllers.Shared
{
    public static class ApiResult
    {
        public static ApiResult<object> Parse(Result commandResult) =>
            ApiResult<object>.Parse(commandResult);

        public static ApiResult<object> Ok() =>
            ApiResult<object>.Ok();

        public static ApiResult<T> Ok<T>(T data) =>
            ApiResult<T>.Ok(data);

        public static ApiResult<object> Fail(string errorMessage) =>
            ApiResult<object>.Fail(errorMessage);

        public static ApiResult<object> Fail(IEnumerable<Notification> errorMessages) =>
            ApiResult<object>.Fail(errorMessages);

        public static ApiResult<object> Fail(IEnumerable<string> errorMessages) =>
            ApiResult<object>.Fail(errorMessages);

        public static ApiResult<T> Fail<T>(T data, string errorMessage) =>
            ApiResult<T>.Fail(data, errorMessage);

        public static ApiResult<T> Fail<T>(T data, IEnumerable<string> errorMessages) =>
            ApiResult<T>.Fail(data, errorMessages);
    }

    public class ApiResult<T>
    {
        public IEnumerable<Notification> ErrorMessages { get; }
        public bool Success { get; }
        public T Data { get; }
        public bool Failure => !Success;

        private static readonly ApiResult<T> OkResult = new ApiResult<T>(true, default(T));

        public static ApiResult<T> Ok()
        {
            return OkResult;
        }

        public static ApiResult<T> Ok(T data) =>
            new ApiResult<T>(true, data);

        public static ApiResult<T> Fail(T data, string errorMessage) =>
            new ApiResult<T>(false, data, new Notification("none", errorMessage));

        public static ApiResult<T> Fail(T data, IEnumerable<string> errorMessages) =>
            new ApiResult<T>(false, data, errorMessages.Select(x => new Notification("none", x)).ToArray());

        public static ApiResult<T> Fail(string errorMessage) =>
            new ApiResult<T>(false, default(T), new Notification("none", errorMessage));

        public static ApiResult<T> Fail(IEnumerable<string> errorMessages) =>
            new ApiResult<T>(false, default(T), errorMessages.Select(x => new Notification("none", x)).ToArray());

        public static ApiResult<T> Fail(IEnumerable<Notification> errorMessages) =>
            new ApiResult<T>(false, default(T), errorMessages.ToArray());

        public static ApiResult<T> Parse(Result commandResult) =>
            new ApiResult<T>(commandResult.Success, default(T), commandResult.ErrorMessages.ToArray());

        private ApiResult(bool isSuccess, T data, params Notification[] errorMessages)
        {
            Data = data;
            Success = isSuccess;
            ErrorMessages = errorMessages;
        }
    }
}
