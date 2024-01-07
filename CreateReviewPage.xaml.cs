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

        // validare pentru campuri
        if (string.IsNullOrWhiteSpace(review.Name) ||
            string.IsNullOrWhiteSpace(review.Comment) ||
            review.Rating <= 0)
        {
            DisplayValidationMessage("All fields are required, and Rating must be selected.");
            return;
        }

        async void DisplayValidationMessage(string message)
        {
            validationMessageLabel.Text = message;

            await Task.Delay(3000);

            validationMessageLabel.Text = string.Empty;
        }

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