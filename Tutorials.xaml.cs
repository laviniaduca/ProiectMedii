namespace ProiectMedii;

public partial class Tutorials : ContentPage
{
    public Tutorials()
    {
        InitializeComponent();
    }
    private async void OnWatchTutorialClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button != null && button.CommandParameter is string youTubeLink)
        {
            // Use Xamarin.Essentials to open the YouTube link
            await Launcher.OpenAsync(new Uri(youTubeLink));
        }
    }
}