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

    async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Console.WriteLine("SelectionChanged triggered");

        if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
        {
            var selectedReview = e.CurrentSelection[0] as Review;

            if (selectedReview != null)
            {
                await Navigation.PushAsync(new ReviewDetailsPage(selectedReview));
            }

            collectionView.SelectedItem = null;
        }
    }
}