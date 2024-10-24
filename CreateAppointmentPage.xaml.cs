using ProiectMedii.Models;
using ProiectMedii.Data;

namespace ProiectMedii;

public partial class CreateAppointmentPage : ContentPage
{
    public CreateAppointmentPage(int makeupArtistId)
	{
		InitializeComponent();
        InitializePageAsync(makeupArtistId);
    }

    private async void InitializePageAsync(int makeupArtistId)
    {
        var makeupArtist = await App.Database.GetMakeupArtistAsync(makeupArtistId);

        if (makeupArtist != null)
        {
            makeupArtistLabel.Text = makeupArtist.Name;

            if (makeupArtist.ServiceID.HasValue)
            {
                var service = await App.Database.GetServiceAsync(makeupArtist.ServiceID.Value);

                if (service != null)
                {
                    serviceLabel.Text = service.Title;
                }
            }

            var appointment = new Appointment
            {
                MakeupArtistID = makeupArtistId,
            };

            BindingContext = appointment;

            appointmentDatePicker.Date = appointment.AppointmentDateTime.Date;
            appointmentTimePicker.Time = appointment.AppointmentDateTime.TimeOfDay;

        }
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var appointment = (Appointment)BindingContext;

        appointment.AppointmentDateTime = new DateTime(
            appointmentDatePicker.Date.Year,
            appointmentDatePicker.Date.Month,
            appointmentDatePicker.Date.Day,
            appointmentTimePicker.Time.Hours,
            appointmentTimePicker.Time.Minutes,
            0);

        var makeupArtist = await App.Database.GetMakeupArtistAsync(appointment.MakeupArtistID);

        if (makeupArtist != null)
        {
            appointment.MakeupArtistName = makeupArtist.Name;

            System.Diagnostics.Debug.WriteLine($"ServiceID: {makeupArtist.ServiceID}");

            if (makeupArtist.ServiceID.HasValue)
            {
                var service = await App.Database.GetServiceAsync(makeupArtist.ServiceID.Value);

                System.Diagnostics.Debug.WriteLine($"Service retrieved: {service?.Title}");

                if (service != null)
                {
                    appointment.ServiceTitle = service.Title;

                    System.Diagnostics.Debug.WriteLine($"Appointment ServiceTitle: {appointment.ServiceTitle}");

                }
            }
        }

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
