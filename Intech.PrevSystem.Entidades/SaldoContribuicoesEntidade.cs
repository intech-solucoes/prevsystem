using System;

namespace Intech.PrevSystem.Entidades
{
    public class SaldoContribuicoesEntidade
    {
        public DateTime DataReferencia { get; set; }

        public decimal QuantidadeCotasParticipante { get; set; }
        public decimal QuantidadeCotasPatrocinadora { get; set; }
        public decimal QuantidadeCotasTotal { get; set; }

        public decimal TotalAposentadoriaComplementar { get; set; }

        public decimal ValorParticipante { get; set; }
        public decimal ValorPatrocinadora { get; set; }
        public decimal ValorBruto { get; set; }

        public DateTime DataCota { get; set; }
        public decimal ValorCota { get; set; }

        public decimal ValorSaldoAtualizado { get; set; }

        public DateTime DataCotaAtualizacao { get; set; }
        public decimal ValorCotaAtualizacao { get; set; }
        public decimal ValoresPortados { get; set; }
        public decimal ValorAdicional { get; set; }
        public decimal SaldoTotalBruto { get; set; }
        public decimal OutrosValores { get; set; }
        public decimal ValorIsentoTributacao { get; set; }
        public decimal IRRF { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal SaldoTotalEmCotas { get; set; }
        public decimal FatorRedutorPatronal { get; set; }
        public decimal SaldoPatrocinadoraEmCotasComRedutor { get; set; }
        public decimal ValorPatrocinadoraComRedutor { get; set; }
        public decimal ValorTotalComRedutorPatronal { get; set; }
        public decimal QuantidadeCotasTotalComRedutor { get; set; }
        public decimal SaldoPortado { get; set; }
    }
}
