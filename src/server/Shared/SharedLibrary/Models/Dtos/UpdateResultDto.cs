namespace SharedLibrary.Models.Dtos
{
    public class UpdateResultDto
    {
        public string? PropertyName { get; set; }
        public string? PropertyTypeName { get; set; }
        public object? OldValue { get; set; }
        public object? NewValue { get; set; }
        public int? ModelPk { get; set; }
        public string? ModelTypeName { get; set; }

    }
}
