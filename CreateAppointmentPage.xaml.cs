using ProiectMedii.Models;

namespace ProiectMedii;

public partial class CreateAppointmentPage : ContentPage
{
    public CreateAppointmentPage(int makeupArtistId)
	{
		InitializeComponent();
        BindingContext = new Appointment
        {
            MakeupArtistID = makeupArtistId
        };
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var appointment = (Appointment)BindingContext;
        await App.Database.SaveAppointmentAsync(appointment);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var appointment = (Appointment)BindingContext;
        await App.Database.DeleteAppointmentAsync(appointment);
        await Navigation.PopAsync();
    }
}