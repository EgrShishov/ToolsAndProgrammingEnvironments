
namespace LabRab5App.Application.SongUseCase.Commands
{
    public sealed record AddSongCommand(string Title, string Genre, int ChartPosition, double Length, int? ArtistId): IRequest<Song>{ }
    internal class AddSongCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddSongCommand, Song>
    {
        public async Task<Song> Handle(AddSongCommand request, CancellationToken cancellationToken)
        {
            var song = new Song(request.Title, request.ChartPosition, request.Genre, request.Length);
            if (request.ArtistId.HasValue) song.AddToArtist(request.ArtistId.Value);
            await unitOfWork.SongsRepository.AddAsync(song, cancellationToken);
            await unitOfWork.SaveAllAsync();

            return song;
        }
    }
}
