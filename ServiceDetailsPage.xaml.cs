using ProiectMedii.Models;

namespace ProiectMedii;

public partial class ServiceDetailsPage : ContentPage
{
	public ServiceDetailsPage()
	{
		InitializeComponent();
	}

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var service = (Service)BindingContext;
        await App.Database.SaveServiceAsync(service);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var service = (Service)BindingContext;

        if (await App.Database.AreMakeupArtistsAssociatedWithService(service.ID))
        {
            // un warning pentru a preveni stergerea in caz ca mai avem MakeupArtists asociati cu Service
            await DisplayAlert("Warning", "There are still makeup artists associated with this service. Remove them before deleting the service.", "OK");
        }
        else
        {
            await App.Database.DeleteServiceAsync(service);
            await Navigation.PopAsync();
        }
    }
}