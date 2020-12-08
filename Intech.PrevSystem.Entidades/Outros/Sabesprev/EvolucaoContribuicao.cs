using Intech.Lib.Util.Date;

namespace Intech.PrevSystem.Entidades.Outros.Sabesprev
{
    public class EvolucaoContribuicao
    {
        public MesAno Data { get; set; }
        public decimal TaxaSalario { get; set; }
        public decimal SalarioLimitado { get; set; }
        public decimal SalarioSemLimitante { get; set; }
        public decimal ContribuicaoParticipante { get; set; }
        public decimal ContribuicaoPatrocinadora { get; set; }
        public decimal ContribuicaoParticipanteSemRentabilidade { get; set; }
        public decimal ContribuicaoPatrocinadoraSemRentabilidade { get; set; }
    }
}
