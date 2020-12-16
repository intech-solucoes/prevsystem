using System.Collections.Generic;

namespace Intech.PrevSystem.Entidades.Outros.Sabesprev
{
    public class ParametrosSimuladorSabesprevMaisEntidade
    {

        public IEnumerable<KeyValuePair<string, decimal>> ListaFaixaBasica1 { get; set; }
        public IEnumerable<KeyValuePair<string, decimal>> ListaFaixaBasica2 { get; set; }
        public IEnumerable<decimal> ListaIdadeAposentadoria { get; set; }
        public IEnumerable<KeyValuePair<string, decimal>> ListaRentabilidadeAnual { get; set; }
        public IEnumerable<KeyValuePair<string, decimal>> ListaCrescimentoSalarialReal { get; set; }
        public IEnumerable<KeyValuePair<string, decimal>> ListaAntecipacaoSaldo { get; set; }
        public IEnumerable<KeyValuePair<string, decimal>> ListaRendaMensalPrazoDeterminado { get; set; }
    }
}
