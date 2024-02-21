

using System.Diagnostics;

namespace LabRab5App.Application.ArtistUseCase.Queries
{
    public sealed record GetArtistsByGroupRequest() : IRequest<IEnumerable<Artist>> { }

    internal class GetArtistByGroupRequestHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetArtistsByGroupRequest, IEnumerable<Artist>>
    {
        public async Task<IEnumerable<Artist>> Handle(GetArtistsByGroupRequest request, CancellationToken cancellationToken)
        {
            return await unitOfWork.ArtistsRepository.GetAllValuesAsync(cancellationToken);
        }
    }
}
