using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.Entidades
{
    public class UltimaContribuicaoEntidade
    {
        public DateTime DataReferencia { get; set; }
        public decimal ValorAposentadoriaParticipante { get; set; }
        public decimal ValorAposentadoriaEmpresa { get; set; }
        public decimal ValorAposentadoriaTotal => ValorAposentadoriaParticipante + ValorAposentadoriaEmpresa;

        public decimal ValorBeneficioRiscoParticipante { get; set; }
        public decimal ValorBeneficioRiscoEmpresa { get; set; }
        public decimal ValorBeneficioRiscoTotal => ValorBeneficioRiscoParticipante + ValorBeneficioRiscoEmpresa;
        //public decimal ValorInvalidezParticipante { get; set; }
        //public decimal ValorInvalidezEmpresa { get; set; }
        //public decimal ValorIvalidezTotal => ValorInvalidezParticipante + ValorInvalidezEmpresa;

        //public decimal ValorMorteParticipante { get; set; }
        //public decimal ValorMorteEmpresa { get; set; }
        //public decimal ValorMorteTotal => ValorMorteParticipante + ValorMorteEmpresa;

        public decimal ValorSobrevivenciaParticipante { get; set; }
        public decimal ValorSobrevivenciaEmpresa { get; set; }
        public decimal ValorSobrevivenciaTotal => ValorSobrevivenciaParticipante + ValorSobrevivenciaEmpresa;

        public decimal ValorCarregamentoParticipante { get; set; }
        public decimal ValorCarregamentoEmpresa { get; set; }
        public decimal ValorCarregamentoTotal => ValorCarregamentoParticipante + ValorCarregamentoEmpresa;

        public decimal ValorTotalParticipante => ValorAposentadoriaParticipante + ValorSobrevivenciaParticipante + ValorCarregamentoParticipante;
        public decimal ValorTotalEmpresa => ValorAposentadoriaEmpresa + ValorSobrevivenciaEmpresa + ValorCarregamentoEmpresa;
        public decimal ValorTotal => ValorTotalParticipante + ValorTotalEmpresa;
    }
}
