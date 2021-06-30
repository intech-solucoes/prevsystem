using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.Entidades.Outros
{
    public class ContribuicaoEntidade
    {
        public decimal SalarioRealContribuicao { get; set; }
        public DateTime DataCompetencia { get; set; }
        public DateTime DataReferencia { get; set; }
        public decimal PercentualParticipante { get; set; }
        public decimal PercentualPatrocinadora { get; set; }
    }
}
