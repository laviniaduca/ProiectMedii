using ProiectMedii.Models;

namespace ProiectMedii;

public partial class AppointmentDetailsPage : ContentPage
{
	public AppointmentDetailsPage(Appointment selectedAppointment)
	{
		InitializeComponent();
        InitializePageAsync(selectedAppointment);

    }

    private async void InitializePageAsync(Appointment selectedAppointment)
    {
        // Fetch additional data based on selectedAppointment if needed
        var makeupArtist = await App.Database.GetMakeupArtistAsync(selectedAppointment.MakeupArtistID);

        if (makeupArtist != null && makeupArtist.ServiceID.HasValue)
        {
            var service = await App.Database.GetServiceAsync(makeupArtist.ServiceID.Value);

            if (service != null)
            {
                selectedAppointment.ServiceTitle = service.Title;
                selectedAppointment.MakeupArtistName = makeupArtist.Name;
            }
        }

        // Set the BindingContext for data binding
        BindingContext = selectedAppointment;
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