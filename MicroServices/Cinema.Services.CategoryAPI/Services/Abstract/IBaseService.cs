﻿using SharedLibrary.Models.Dtos;

namespace Cinema.Services.CategoryAPI.Services.Abstract
{
    public interface IBaseService
    {
        Task<ResponseDto<TResponse>> SendAsync<TRequest, TResponse>(RequestDto<TRequest> requestDto, bool isAuthorize = true)
            where TResponse : class
            where TRequest : class;
    }
}
