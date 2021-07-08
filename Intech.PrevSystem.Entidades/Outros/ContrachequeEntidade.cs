using System;
using System.Collections.Generic;

namespace Intech.PrevSystem.Entidades.Outros
{
    public class ContrachequeEntidade
    {
        public List<FichaFinanceiraAssistidoEntidade> Rubricas { get; set; }
        public List<FichaFinanceiraAssistidoEntidade> Proventos { get; set; }
        public List<FichaFinanceiraAssistidoEntidade> Descontos { get; set; }
        public List<FichaFinanceiraAssistidoEntidade> Outros { get; set; }
        public ContrachequeResumo Resumo { get; set; }
    }
    public class ContrachequeResumo
    {
        public DateTime Referencia { get; set; }
        public DateTime Competencia{ get; set; }
        public DateTime DataCredito { get; set; }
        public decimal? Bruto { get; set; }
        public decimal? Descontos { get; set; }
        public decimal? Liquido { get; set; }
        public string TipoFolha { get; set; }
        public string DesTipoFolha { get; set; }
        public IndiceValoresEntidade Indice { get; set; }
    }
}
