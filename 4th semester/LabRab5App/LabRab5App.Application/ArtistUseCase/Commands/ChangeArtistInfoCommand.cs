
namespace LabRab5App.Application.ArtistUseCase.Commands
{
    public sealed record ChangeArtistInfoCommand(Artist artist) : IRequest<Artist> { }
    internal class ChangeArtistInfoCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<ChangeArtistInfoCommand, Artist>
    {
        public async Task<Artist> Handle(ChangeArtistInfoCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.ArtistsRepository.UpdateAsync(request.artist, cancellationToken);
            await unitOfWork.SaveAllAsync();
            
            return request.artist;
        }
    }
}
