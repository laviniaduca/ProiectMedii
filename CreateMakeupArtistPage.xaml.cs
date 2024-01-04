using ProiectMedii.Models;

namespace ProiectMedii;

public partial class CreateMakeupArtistPage : ContentPage
{
	public CreateMakeupArtistPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var makeupArtist = (MakeupArtist)BindingContext;

        // Perform validation or additional logic if needed before saving

        await App.Database.SaveMakeupArtistAsync(makeupArtist);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var makeupArtist = (MakeupArtist)BindingContext;
        await App.Database.DeleteMakeupArtistAsync(makeupArtist);
        await Navigation.PopAsync();
    }
}