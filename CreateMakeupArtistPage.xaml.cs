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

        // Optionally, you can find the corresponding ServiceID based on the selected title
        int selectedServiceId = await GetServiceIdByTitleAsync(selectedServiceTitle);

        // Set the selected service title and ID in your MakeupArtist instance
        var makeupArtist = (MakeupArtist)BindingContext;
        makeupArtist.ServiceTitle = selectedServiceTitle;
        makeupArtist.ServiceID = selectedServiceId;
    }

    private async Task<int> GetServiceIdByTitleAsync(string serviceTitle)
    {
        // Fetch the Service based on the title asynchronously
        var service = await App.Database.GetServiceByTitleAsync(serviceTitle);

        // Return the ServiceID if found, otherwise, return a default value (0 or -1)
        return service?.ID ?? 0;
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