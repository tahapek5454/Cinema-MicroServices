

using SharedLibrary.Models.Dtos;

namespace SharedLibrary.Behaviors
{
    public class CommonResponse<T>
    {
        public ResponseDto<T> Result { get; set; }
    }
}
