using SharedLibrary.Models.Enums;

namespace SharedLibrary.Models.Dtos
{
    public class RequestDto<T>
    {
        public ActionType ActionType { get; set; } = ActionType.GET;
        public string Url { get; set; }
        public T? Data { get; set; }
        public string? AccessToken { get; set; }
        public SystemLanguage Language { get; set; } = SystemLanguage.tr_TR;
    }
}
