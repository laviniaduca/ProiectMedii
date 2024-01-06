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
            await Navigation.PushAsync(new AppointmentDetailsPage(e.SelectedItem as Appointment));
        }
    }
}