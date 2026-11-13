using MauiAppHotel2.Models;
using System;
using Microsoft.Maui.Controls;

namespace MauiAppHotel2.Views
{
    public partial class CadastroEvento : ContentPage
    {
        public CadastroEvento()
        {
            InitializeComponent();

            // Inicia o objeto com as datas de hoje
            BindingContext = new Evento
            {
                DataInicio = DateTime.Today,
                DataTermino = DateTime.Today.AddDays(1)
            };
        }

        // Esse método roda logo depois que a tela é desenhada
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // TRUQUE DE MESTRE PARA O WINDOWS: 
            // Se as datas estiverem vazias (MinValue), o Windows não desenha o DatePicker.
            // Forçamos o BindingContext a atualizar.
            if (BindingContext is Evento evento)
            {
                if (evento.DataInicio == DateTime.MinValue) evento.DataInicio = DateTime.Today;
                if (evento.DataTermino == DateTime.MinValue) evento.DataTermino = DateTime.Today.AddDays(1);

                // Recarrega o contexto para forçar o XAML a atualizar na tela
                var temp = BindingContext;
                BindingContext = null;
                BindingContext = temp;
            }
        }

        private async void Cadastrar_Clicked(object sender, EventArgs e)
        {
            Evento evento = (Evento)BindingContext;

            // Validação básica
            if (string.IsNullOrWhiteSpace(evento.Nome) || string.IsNullOrWhiteSpace(evento.Local) || evento.NumeroParticipantes <= 0 || evento.CustoPorParticipante <= 0)
            {
                await DisplayAlert("Atenção", "Preencha todos os campos corretamente.", "OK");
                return;
            }

            if (evento.DataTermino < evento.DataInicio)
            {
                await DisplayAlert("Atenção", "A data de término não pode ser anterior à data de início.", "OK");
                return;
            }

            // Vai para a tela de resumo
            await Navigation.PushAsync(new ResumoEvento
            {
                BindingContext = evento
            });
        }

        private async void Voltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}