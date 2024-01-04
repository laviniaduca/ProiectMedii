using ProiectMedii.Models;

namespace ProiectMedii;

public partial class CreateReviewPage : ContentPage
{
    public CreateReviewPage(int makeupArtistId)
    {
        InitializeComponent();
        BindingContext = new Review
        {
            MakeupArtistID = makeupArtistId
        };
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var review = (Review)BindingContext;
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