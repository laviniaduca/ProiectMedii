using ProiectMedii.Models;

namespace ProiectMedii;

public partial class AppointmentDetailsPage : ContentPage
{
	public AppointmentDetailsPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var selectedAppointment = BindingContext as Appointment;

        if (selectedAppointment != null)
        {
            BindingContext = selectedAppointment;
        }
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (Appointment)BindingContext;
        await App.Database.SaveAppointmentAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (Appointment)BindingContext;
        await App.Database.DeleteAppointmentAsync(slist);
        await Navigation.PopAsync();
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}