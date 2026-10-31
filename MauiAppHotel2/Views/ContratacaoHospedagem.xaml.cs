
namespace MauiAppHotel2.Views;

public partial class NewPage1 : ContentPage
{
    public NewPage1()
    {
        InitializeComponent();
    }

    private async void AbrirSobre_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Sobre));
    }
}
