using System;

namespace MauiAppHotel2.Models
{
    public class Evento
    {
        public string Nome { get; set; }
        public string Local { get; set; }
        public int NumeroParticipantes { get; set; }
        public decimal CustoPorParticipante { get; set; }

        // Datas simples
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }

        // --- CÁLCULOS (Requisitos 1 e 2) ---

        // Duração em dias (TimeSpan)
        public int DuracaoDias
        {
            get
            {
                // Evita erro se as datas estiverem vazias
                if (DataInicio == DateTime.MinValue || DataTermino == DateTime.MinValue)
                    return 0;

                return (DataTermino - DataInicio).Days;
            }
        }

        // Custo Total
        public decimal CustoTotal => NumeroParticipantes * CustoPorParticipante;
    }
}