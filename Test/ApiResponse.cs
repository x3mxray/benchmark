using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Errors = new List<Error>();
        }
        public bool IsSuccess { get; set; }
        public List<Error> Errors { get; set; }
        public dynamic Data { get; set; }
        public static ApiResponse Success()
        {
            return new ApiResponse()
            {
                IsSuccess = true,
            };
        }


        public static ApiResponse Error(string code, string errorMessage = null, Exception exception = null)
        {
            return new ApiResponse()
            {
                IsSuccess = false,
                Errors = new List<Error> { new Error(code, errorMessage, exception) }
            };
        }

        public static ApiResponse Error(IEnumerable<Error> errors)
        {
            return new ApiResponse()
            {
                IsSuccess = false,
                Errors = new List<Error>(errors)
            };
        }

        public static ApiResponse Error(Error error)
        {
            return new ApiResponse()
            {
                IsSuccess = false,
                Errors = new List<Error>() { error }
            };
        }
    }

    public class Error
    {
        public Error(string code, string message = null, Exception exception = null)
        {
            Code = code;
            ErrorMessage = message;
            Exception = exception;
        }
        public string Code { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }

        public override string ToString()
        {
            return $"{Code}={ErrorMessage}, " + (Exception?.Message ?? "");
        }
    }
}
