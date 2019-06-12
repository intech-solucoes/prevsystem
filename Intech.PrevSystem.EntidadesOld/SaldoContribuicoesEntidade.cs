using System;

namespace Intech.PrevSystem.Entidades
{
    public class SaldoContribuicoesEntidade
    {
        public DateTime DataReferencia { get; set; }

        public decimal QuantidadeCotasParticipante { get; set; }
        public decimal QuantidadeCotasPatrocinadora { get; set; }
        public decimal QuantidadeCotasTotal => QuantidadeCotasParticipante + QuantidadeCotasPatrocinadora;

        public decimal ValorParticipante { get; set; }
        public decimal ValorPatrocinadora { get; set; }
        public decimal ValorTotal => ValorParticipante + ValorPatrocinadora;

        public DateTime DataCota { get; set; }
        public decimal ValorCota { get; set; }
    }
}
