
namespace LabRab5App.Application.ArtistUseCase.Commands
{
    public sealed record AddArtistCommand(string Name, DateTime BirthDate, string Country): IRequest<Artist> { }
    internal class AddArtistCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddArtistCommand, Artist>
    {
        public async Task<Artist> Handle(AddArtistCommand request, CancellationToken cancellationToken)
        {
            Artist newArtist = new Artist(request.Name, request.BirthDate, request.Country);
            await unitOfWork.ArtistsRepository.AddAsync(newArtist);
            await unitOfWork.SaveAllAsync();

            return newArtist;
        }
    }
}
