

using SharedLibrary.Models.Dtos;

namespace SharedLibrary.Behaviors
{
    public class CommonResponse<T>
        where T : class
    {
        public ResponseDto<T> Response { get; set; }
    }
}
