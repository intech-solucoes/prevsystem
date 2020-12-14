using System.Collections.Generic;

namespace Intech.PrevSystem.Entidades.Outros.Sabesprev
{
    public class ParametrosSimuladorSabesprevReforcoEntidade
    {

        public IEnumerable<KeyValuePair<string, string>> ListaPeriodicidade { get; set; }
        public IEnumerable<decimal> ListaIdadeAposentadoria { get; set; }
        public IEnumerable<KeyValuePair<string, decimal>> ListaRentabilidadeAnual { get; set; }
        public IEnumerable<KeyValuePair<string, decimal>> ListaCrescimentoSalarialReal { get; set; }
    }
}
