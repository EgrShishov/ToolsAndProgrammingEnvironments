using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LabRab5App.Application.ArtistUseCase.Commands;

namespace LabRab5App.ViewModels
{
    [QueryProperty("Name", "Name")]
    [QueryProperty("Country", "Country")]
    [QueryProperty("birth", "birth")]

    public partial class AddNewArtistViewModel: ObservableObject
    {
        private readonly IMediator _mediator;

        public AddNewArtistViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string country;

        [ObservableProperty]
        DateTime birth;

        [RelayCommand]
        public async Task AddArtist()
        {
            if (name is null || country is null) return;
            await _mediator.Send(new AddArtistCommand(name, birth, country));
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
