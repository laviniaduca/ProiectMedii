using ProiectMedii.Models;

namespace ProiectMedii;

public partial class Appointments : ContentPage
{
	public Appointments()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        listView.ItemsSource = await App.Database.GetAppointmentsAsync();
    }

    // nu mai am nevoie de asta pentru ca vreau sa fac appointment direct din pagina de MakeupArtists
    /*async void OnAppointmentAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateAppointmentPage
        {
            BindingContext = new Appointment()
        });
    }*/

    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new AppointmentDetailsPage
            {
                BindingContext = e.SelectedItem as Appointment
            });
        }
    }
}