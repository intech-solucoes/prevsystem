using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.Entidades.Outros.Faelce
{
    public  class SaldoContribuicoesFaelceEntidade
    {
        public decimal ContribParticipante { get; set; }
        public decimal ContribPatrocinadora { get; set; }
        public decimal ContribPortabilidade { get; set; }
        public decimal QtCotaParticipante { get; set; }
        public decimal QtCotaPatrocinadora { get; set; }
        public decimal QtCotaPortabilidade { get; set; }
        public decimal ContribTotal { get; set; }
        public decimal QtCotaTotal { get; set; }
        public decimal Cota { get; set; }
        public DateTime Referencia { get; set; }

        public SaldoContribuicoesFaelceEntidade(FichaFinanceiraEntidade saldos, IndiceValoresEntidade cota)
        {
            Cota = cota.VALOR_IND;

            QtCotaParticipante = saldos.QTD_COTA_RP_PARTICIPANTE ?? 0;
            QtCotaPatrocinadora = saldos.QTD_COTA_RP_EMPRESA ?? 0;
            QtCotaPortabilidade = saldos.QTD_COTA_RP_PORTABILIDADE ?? 0;

            ContribParticipante = QtCotaParticipante * Cota;
            ContribPatrocinadora = QtCotaPatrocinadora * Cota;
            ContribPortabilidade = QtCotaPortabilidade * Cota;

            ContribTotal = ContribParticipante + ContribPatrocinadora + ContribPortabilidade;
            QtCotaTotal = QtCotaParticipante + QtCotaPatrocinadora + QtCotaPortabilidade;

            Referencia = cota.DT_IND;
        }

        /*public decimal GetContribTotal()
        {
            return ContribTotal;
        }
        public decimal GetQtCotaTotal()
        {
            return QtCotaTotal;
        }*/
    }
}
