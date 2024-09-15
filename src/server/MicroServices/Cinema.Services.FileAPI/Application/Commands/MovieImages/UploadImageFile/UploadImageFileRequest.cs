using MediatR;

namespace Cinema.Services.FileAPI.Application.Commands.MovieImages.UploadImageFile
{
    public class UploadImageFileRequest: IRequest<UploadImageFileResponse>
    {
        public int RelationId { get; set; }
        public IFormFileCollection? FormFileCollection { get; set; }
    }
}
