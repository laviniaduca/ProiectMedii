using ProiectMedii.Models;

namespace ProiectMedii;

public partial class CreateReviewPage : ContentPage
{
    public CreateReviewPage(int makeupArtistId)
    {
        InitializeComponent();
        BindingContext = new Review
        {
            MakeupArtistID = makeupArtistId,
            Rating = 1
        };
    }

    private void OnRatingCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            var radioButton = (RadioButton)sender;
            if (int.TryParse(radioButton.Content.ToString(), out int selectedRating))
            {
                var review = (Review)BindingContext;
                review.Rating = selectedRating;

                Console.WriteLine($"Selected Rating: {review.Rating}");
            }
        }
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var review = (Review)BindingContext;

        Console.WriteLine($"Rating before saving: {review.Rating}");

        review.DateCreated = DateTime.UtcNow;

        Console.WriteLine($"Rating after setting DateCreated: {review.Rating}");

        await App.Database.SaveReviewAsync(review);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var review = (Review)BindingContext;
        await App.Database.DeleteReviewAsync(review);
        await Navigation.PopAsync();
    }
}