using MediatR;

namespace Cinema.Services.FileAPI.Application.Commands.MovieImages.DeleteImageFile
{
    public class DeleteImageFileRequest: IRequest<DeleteImageFileResponse>
    {
        public string FileName { get; set; }
    }
}
