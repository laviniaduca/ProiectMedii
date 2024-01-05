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

        async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("SelectionChanged triggered");

            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                var selectedMakeupArtist = e.CurrentSelection[0] as MakeupArtist;

                if (selectedMakeupArtist != null)
                {
                    Console.WriteLine($"Selected MakeupArtist: {selectedMakeupArtist.Name}");
                    await Navigation.PushAsync(new MakeupArtistDetailsPage(selectedMakeupArtist));
                }

                // Deselect the item to allow selecting it again
                collectionView.SelectedItem = null;
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
