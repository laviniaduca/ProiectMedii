using ProiectMedii.Models;

namespace ProiectMedii;

public partial class CreateServicePage : ContentPage
{
	public CreateServicePage()
	{
		InitializeComponent();
    }
    
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var service = (Service)BindingContext;

        // verificam daca pretul este valid
        bool IsValidPrice(decimal price)
        {
            string priceString = price.ToString();

            return !string.IsNullOrWhiteSpace(priceString) && priceString.All(char.IsDigit) && decimal.TryParse(priceString, out decimal result) && result > 0;
        }

        // validare pentru campuri
        if (string.IsNullOrWhiteSpace(service.Title) ||
        string.IsNullOrWhiteSpace(service.Description) ||
        !IsValidPrice(service.Price))
        {
            DisplayValidationMessage("All fields are required, Price must contain only digits and be a positive number.");
            return;
        }

        async void DisplayValidationMessage(string message)
        {
            validationMessageLabel.Text = message;

            await Task.Delay(3000);

            validationMessageLabel.Text = string.Empty;
        }

        await App.Database.SaveServiceAsync(service);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var service = (Service)BindingContext;
        await App.Database.DeleteServiceAsync(service);
        await Navigation.PopAsync();
    }
}