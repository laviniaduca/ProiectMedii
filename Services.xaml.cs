using ProiectMedii.Models;

namespace ProiectMedii;

public partial class Services : ContentPage
{
	public Services()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        listView.ItemsSource = await App.Database.GetServicesAsync();
    }
    async void OnServiceAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateServicePage
        {
            BindingContext = new Service()
        });
    }

   /*async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ServiceDetailsPage
            {
                BindingContext = e.SelectedItem as Service
            });
        }
    }*/
}