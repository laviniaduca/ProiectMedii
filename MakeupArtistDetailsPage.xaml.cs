using ProiectMedii.Models;

namespace ProiectMedii
{
    public partial class MakeupArtistDetailsPage : ContentPage
    {
        public MakeupArtistDetailsPage(MakeupArtist selectedArtist)
        {
            InitializeComponent();
            InitializePageAsync(selectedArtist.ID);
        }

        private async void InitializePageAsync(int makeupArtistId)
        {
            var makeupArtist = await App.Database.GetMakeupArtistAsync(makeupArtistId);

            if (makeupArtist != null && makeupArtist.ServiceID.HasValue)
            {
                var service = await App.Database.GetServiceAsync(makeupArtist.ServiceID.Value);

                if (service != null)
                {
                    serviceLabel.Text = service.Title;
                }
            }

            BindingContext = makeupArtist;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var selectedArtist = BindingContext as MakeupArtist;

            if (selectedArtist != null)
            {
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
