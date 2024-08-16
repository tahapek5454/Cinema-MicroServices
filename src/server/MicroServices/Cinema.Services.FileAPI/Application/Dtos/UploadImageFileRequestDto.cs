namespace Cinema.Services.FileAPI.Application.Dtos
{
    public class UploadImageFileRequestDto
    {
        public int RelationId { get; set; }
        public IFormFileCollection? FormFileCollection { get; set; }
    }
}
