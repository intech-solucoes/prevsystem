namespace Intech.PrevSystem.Entidades.Outros.Sabesprev
{
    public class DadosSimulacaoSabesprevReforcoEntidade
    {
        public decimal ContribuicaoNormal { get; set; }
        public decimal ContribuicaoEsporadica { get; set; }
        public string PeriodicidadeEsporadica { get; set; }
        public decimal AporteInicial { get; set; }
        public int IdadeAposentadoria { get; set; }
        public int RendaMensalPrazoDeterminado { get; set; }
        public decimal AntecipacaoSaldo { get; set; }
        public decimal Rentabilidade { get; set; }
        public decimal CrescimentoSalarialReal { get; set; }
        public decimal RendaMensalEmReais { get; set; }
    }
}
