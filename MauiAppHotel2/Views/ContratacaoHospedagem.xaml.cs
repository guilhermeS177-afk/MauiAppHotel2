
using MauiAppHotel2.Models;

namespace MauiAppHotel2.Views;

public partial class NewPage1 : ContentPage
{
    List<Quarto> Lista_Quartos = new()
{
    new Quarto { Nome = "Suíte Master", ValorAdultos = 225.5, ValorCriancas = 200.3 },
    new Quarto { Nome = "Suíte Premium", ValorAdultos = 180.30, ValorCriancas = 110.30 },
    new Quarto { Nome = "Suíte Viajante", ValorAdultos = 140, ValorCriancas = 75 },
    new Quarto { Nome = "Suíte Crise", ValorAdultos = 100.3, ValorCriancas = 50.0 }
};
    public NewPage1()
    {
        InitializeComponent();

        pck_quarto.ItemsSource = Lista_Quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MinimumDate = DateTime.Now.AddMonths(3);


        dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
        dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(4);
    }

    private async void AbrirSobre_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Sobre));
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        dtpck_checkout.MinimumDate = e.NewDate?.AddDays(1);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new()
            {
                QtdAdultos = Convert.ToInt32(stp_adultos.Value),
                Qtdcrianca = Convert.ToInt32(stp_criancas.Value),
                QuartoEscolhido = (Quarto)pck_quarto.SelectedItem,
                DataCheckin = dtpck_checkin.Date.Value,
                DataCheckout = dtpck_checkout.Date.Value,
            };

            Navigation.PushAsync(new HopedagemContratada
            {
                BindingContext = h
            });

        }
        catch (Exception ex)
        {
            DisplayAlertAsync("Ops!", ex.Message, "Ok");
        }

    }
}
