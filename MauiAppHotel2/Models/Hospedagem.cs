using System.Data;

namespace MauiAppHotel2.Models
{
    public class Hospedagem
    {

        Quarto? quarto_escolhido;

        DateTime? data_checkin;

        public Quarto? QuartoEscolhido
        {
            get => quarto_escolhido;
            set
            {
                if (value == null)
                    throw new Exception("Por favor, selecione um quarto");
                quarto_escolhido = value;
            }
        }
        public int QtdAdultos { get; set; }
        public int Qtdcrianca { get; set; }

        public DateTime? DataCheckin
        {
            get => data_checkin;
            set
            {
                if (value == null) 
                    throw new Exception("Por favor, selecione a data de checkin");
                data_checkin = value;
            }
        
        }

public DateTime DataCheckout { get; set; }


public int Estadia
        {
            get => DataCheckout.Subtract(DataCheckin.Value).Days;
        }

        public double TotalHospedagem
        {
            get
            {
                double total_adultos = QtdAdultos * QuartoEscolhido.ValorAdultos;
                double total_criancas = Qtdcrianca * QuartoEscolhido.ValorCriancas;

                return (total_adultos +  total_criancas) * Estadia;
            }
        }
    }
}
