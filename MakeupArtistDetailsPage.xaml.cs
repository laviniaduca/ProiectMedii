using ProiectMedii.Models;

namespace ProiectMedii
{
    public partial class MakeupArtistDetailsPage : ContentPage
    {
        public MakeupArtistDetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Assuming you passed the selected MakeupArtist through navigation
            var selectedArtist = BindingContext as MakeupArtist;

            if (selectedArtist != null)
            {
                // Set the BindingContext for data binding
                BindingContext = selectedArtist;
            }
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (MakeupArtist)BindingContext;
            await App.Database.SaveMakeupArtistAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (MakeupArtist)BindingContext;
            await App.Database.DeleteMakeupArtistAsync(slist);
            await Navigation.PopAsync();
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
