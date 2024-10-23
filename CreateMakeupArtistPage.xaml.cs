using ProiectMedii.Models;

namespace ProiectMedii;

public partial class CreateMakeupArtistPage : ContentPage
{
	public CreateMakeupArtistPage()
	{
		InitializeComponent();
        SetupPickerAsync();

    }
    private async void SetupPickerAsync()
    {
        var serviceTitles = await App.Database.GetAllServiceTitlesAsync();
        servicePicker.ItemsSource = serviceTitles;
    }

    private async void OnServicePickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedServiceTitle = servicePicker.SelectedItem?.ToString();

        int selectedServiceId = await GetServiceIdByTitleAsync(selectedServiceTitle);

        var makeupArtist = (MakeupArtist)BindingContext;
        makeupArtist.ServiceTitle = selectedServiceTitle;
        makeupArtist.ServiceID = selectedServiceId;
    }

    private async Task<int> GetServiceIdByTitleAsync(string serviceTitle)
    {
        var service = await App.Database.GetServiceByTitleAsync(serviceTitle);

        return service?.ID ?? 0;
    }


    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var makeupArtist = (MakeupArtist)BindingContext;


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
