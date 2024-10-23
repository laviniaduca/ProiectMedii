using ProiectMedii.Models;

namespace ProiectMedii;

public partial class ReviewDetailsPage : ContentPage
{
    private Review selectedReview;

    public ReviewDetailsPage(Review selectedReview)
	{
		InitializeComponent();

        Console.WriteLine($"Rating in ReviewDetailsPage constructor: {selectedReview.Rating}");
        BindingContext = this.selectedReview = selectedReview;
        UpdateRadioButtons();

    }

    private void UpdateRadioButtons()
    {
        if (selectedReview != null)
        {
            switch (selectedReview.Rating)
            {
                case 1:
                    RatingOne.IsChecked = true;
                    break;
                case 2:
                    RatingTwo.IsChecked = true;
                    break;
                case 3:
                    RatingThree.IsChecked = true;
                    break;
                case 4:
                    RatingFour.IsChecked = true;
                    break;
                case 5:
                    RatingFive.IsChecked = true;
                    break;
            }
        }
    }

    /*protected override void OnAppearing()
    {
        base.OnAppearing();

        var selectedReview = BindingContext as Review;

        if (selectedReview != null)
        {
            BindingContext = selectedReview;
        }
    }*/

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (selectedReview != null)
        {
            if (RatingOne.IsChecked)
            {
                selectedReview.Rating = 1;
            }
            else if (RatingTwo.IsChecked)
            {
                selectedReview.Rating = 2;
            }
            else if (RatingThree.IsChecked)
            {
                selectedReview.Rating = 3;
            }
            else if (RatingFour.IsChecked)
            {
                selectedReview.Rating = 4;
            }
            else if (RatingFive.IsChecked)
            {
                selectedReview.Rating = 5;
            }

            await App.Database.SaveReviewAsync(selectedReview);
            await Navigation.PopAsync();
        }
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var review = (Review)BindingContext;
        await App.Database.DeleteReviewAsync(review);
        await Navigation.PopAsync();
    }
}
