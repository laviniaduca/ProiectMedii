using ProiectMedii.Models;

namespace ProiectMedii;

public partial class Reviews : ContentPage
{
	public Reviews()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        collectionView.ItemsSource = await App.Database.GetReviewsAsync();
    }

    /*async void OnReviewAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateReviewPage
        {
            BindingContext = new Review()
        });
    }*/

    /*async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ReviewDetailsPage
            {
                BindingContext = e.SelectedItem as Review
            });
        }
    }*/
}