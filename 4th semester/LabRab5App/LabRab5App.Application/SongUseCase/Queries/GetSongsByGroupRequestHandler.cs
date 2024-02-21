

using System.Diagnostics;

namespace LabRab5App.Application.SongUseCase.Queries
{
    public sealed record GetSongsByGroupRequest(int id) : IRequest<IEnumerable<Song>> { }
    internal class GetSongsByGroupRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetSongsByGroupRequest, IEnumerable<Song>>
    {
        public async Task<IEnumerable<Song>> Handle(GetSongsByGroupRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.SongsRepository.GetListAsync(item => item.ArtistId == request.id, cancellationToken);
        }
    }
}
