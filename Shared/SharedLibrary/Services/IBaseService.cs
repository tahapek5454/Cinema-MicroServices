using SharedLibrary.Models.Dtos;

namespace SharedLibrary.Services
{
    public interface IBaseService
    {
        Task<ResponseDto<TResponse>> SendAsync<TRequest, TResponse>(RequestDto<TRequest> requestDto, bool isAuthorize = true)
            where TResponse : class
            where TRequest : class;

        int AdvancedUpdate<TModel, TRequest>(TModel model, TRequest request)
            where TModel : class
            where TRequest : class;
    }
}
