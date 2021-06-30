namespace Intech.PrevSystem.Entidades.Outros
{
    public class PercentuaisContribuicaoEntidade
    {
        public decimal PercentualContribuicaoParticipante { get; set; }
        public decimal PercentualContribuicaoPatrocinadora { get; set; }
        public decimal PercentualContribuicaoFacultativa { get; set; }
        public decimal? ContribuicaoParticipante { get; set; }
        public decimal? ContribuicaoPatrocinadora { get; set; }
        public decimal? ContribuicaoFacultativa { get; set; }
        public decimal ContribuicoesAdmParticipante { get; set; }
        public decimal ContribuicoesAdmPatrocinadora { get; set; }
        public decimal ValorContribuicaoAtualParticipanteLiquida { get; set; }
        public decimal ValorContribuicaoAtualPatrocinadoraLiquida { get; set; }
    }
}
