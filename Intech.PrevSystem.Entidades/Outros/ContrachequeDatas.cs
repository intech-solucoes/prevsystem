using System.Collections.Generic;

namespace Intech.PrevSystem.Entidades.Outros
{
    public class ContrachequeDatas
    {
        public object Especie { get; set; }
        public List<FichaFinanceiraAssistidoEntidade> Lista { get; set; }
    }

    public class ContrachequeDatasEspecie
    {
        public string DS_ESPECIE { get; set; }
        public decimal NUM_PROCESSO { get; set; }
        public string ANO_PROCESSO { get; set; }
        public string CD_PLANO { get; set; }
        public string DS_PLANO { get; set; }
    }
}
