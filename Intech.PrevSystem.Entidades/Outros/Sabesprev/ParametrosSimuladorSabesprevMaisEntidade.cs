using System.Collections.Generic;

namespace Intech.PrevSystem.Entidades.Outros.Sabesprev
{
    public class ParametrosSimuladorSabesprevMaisEntidade
    {

        public IEnumerable<decimal> ListaFaixaBasica1 { get; set; }
        public IEnumerable<decimal> ListaFaixaBasica2 { get; set; }
        public IEnumerable<decimal> ListaIdadeAposentadoria { get; set; }
        public IEnumerable<decimal> ListaRentabilidadeAnual { get; set; }
        public IEnumerable<decimal> ListaCrescimentoSalarialReal { get; set; }
        public IEnumerable<decimal> ListaAntecipacaoSaldo { get; set; }
    }
}
