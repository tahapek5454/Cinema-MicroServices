﻿using Newtonsoft.Json;

namespace SharedLibrary.Models.Dtos
{
    public class ResponseDto<T>
    {
        [JsonProperty("data")]
        public T? Data { get; private set; }
        [JsonProperty("statusCode")]
        public int StatusCode { get; private set; }
        [JsonProperty("error")]
        public ErrorDto? Error { get; private set; }
        [JsonProperty("isSuccessful")]
        public bool IsSuccessful { get; private set; }
        public static ResponseDto<T> Sucess(T data, int statusCode)
            => new ResponseDto<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };

        public static ResponseDto<T> Sucess(int statusCode)
            => new ResponseDto<T> { StatusCode = statusCode, IsSuccessful = true };

        public static ResponseDto<T> Fail(ErrorDto error, int statusCode)
            => new ResponseDto<T> { Error = error, StatusCode = statusCode, IsSuccessful = false };

        public static ResponseDto<T> Fail(string errorMessage, bool isShow, int statusCode)
        {
            ErrorDto errorDto = new(errorMessage, isShow);
            return new ResponseDto<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }

        public bool ValidateWithData()
        {
            if(this.Data is not null & this.IsSuccessful)
                return true;

            return false;
        }
    }
}
