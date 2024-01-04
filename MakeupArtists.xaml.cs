using System;
using System.IO;
using Microsoft.Maui.Controls;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii
{
    public partial class MakeupArtists : ContentPage
    {
        public MakeupArtists()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.Database.GetMakeupArtistsAsync();
        }

        async void OnMakeupArtistAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateMakeupArtistPage
            {
                BindingContext = new MakeupArtist()
            });
        }

        async void OnCollectionViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MakeupArtistDetailsPage
                {
                    BindingContext = e.SelectedItem as MakeupArtist
                });
            }
        }

        private async void OnAppointmentAddedClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.CommandParameter != null)
            {
                int makeupArtistId = (int)button.CommandParameter;

                await Navigation.PushAsync(new CreateAppointmentPage(makeupArtistId));
            }
        }

        private async void OnReviewAddedClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.CommandParameter != null)
            {
                int makeupArtistId = (int)button.CommandParameter;

                await Navigation.PushAsync(new CreateReviewPage(makeupArtistId));
            }
        }
    }
}
