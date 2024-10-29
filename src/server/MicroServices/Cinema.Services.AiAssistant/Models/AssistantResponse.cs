namespace Cinema.Services.AiAssistant.Models
{
    public class AssistantResponse
    {
        public string? Message { get; set; }
        public string? ThreadId { get; set; }
        public Information Information { get; set; }
    }

    public class Information
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
