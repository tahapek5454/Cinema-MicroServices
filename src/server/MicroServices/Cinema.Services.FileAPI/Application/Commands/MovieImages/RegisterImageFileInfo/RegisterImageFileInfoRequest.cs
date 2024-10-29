using MediatR;

namespace Cinema.Services.FileAPI.Application.Commands.MovieImages.RegisterImageFileInfo
{
    public class RegisterImageFileInfoRequest: IRequest<RegisterImageFileInfoResponse>
    {
        public IEnumerable<RelationData> RelationDatas { get; set; }
    }


    public struct RelationData
    {
        public int RelationId { get; set; }
        public string FileFullName { get; set; }
    }
}
