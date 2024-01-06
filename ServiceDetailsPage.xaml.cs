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
        await App.Database.DeleteServiceAsync(service);
        await Navigation.PopAsync();
    }
}