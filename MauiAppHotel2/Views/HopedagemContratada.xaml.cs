namespace MauiAppHotel2.Views;

public partial class HopedagemContratada : ContentPage
{
	public HopedagemContratada()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}