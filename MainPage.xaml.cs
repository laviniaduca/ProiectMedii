namespace ProiectMedii;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        ArtistsBtn.Clicked += OnArtistsButtonClicked;
        TutorialsBtn.Clicked += OnTutorialsButtonClicked;
    }

    private void OnArtistsButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MakeupArtists());
    }

    private void OnTutorialsButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Tutorials());
    }

}

