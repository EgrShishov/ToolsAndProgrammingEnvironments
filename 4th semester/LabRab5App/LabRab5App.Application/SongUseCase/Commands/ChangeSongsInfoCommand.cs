
using System.Diagnostics;

namespace LabRab5App.Application.SongUseCase.Commands
{
    public sealed record ChangeSongsInfoCommand(Song song): IRequest<Song> { }
    internal class ChangeSongsInfoCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<ChangeSongsInfoCommand, Song>
    {
        public async Task<Song> Handle(ChangeSongsInfoCommand request, CancellationToken cancellationToken)
        {
            Trace.WriteLine(request.song);
            await unitOfWork.SongsRepository.UpdateAsync(request.song, cancellationToken);
            await unitOfWork.SaveAllAsync();
            return request.song;
        }
    }
}
