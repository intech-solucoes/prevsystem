using System;
using System.Collections.Generic;

namespace Intech.PrevSystem.Entidades.Outros.Sabesprev
{
    public class ResultadoSimuladorSabesprevBasicoEntidade
    {
        public FuncionarioDados Dados { get; set; }
        public DateTime DataDoCalculo { get; set; }
        public string IdadeNaData { get; set; }
        public string IdadeAtual { get; set; }
        public decimal SalarioParticipacao { get; set; }

        public List<SimulacaoSabesprevBasico> Simulacoes { get; set; }
        public decimal SalarioRealBeneficio { get; set; }
        public decimal BeneficioPrevidenciario { get; set; }
        public int ServicoCreditado { get; set; }
        public decimal BeneficioMensalExibir { get; set; }
        public decimal BeneficioMinimoExibir { get; set; }
        public decimal BeneficioMensal { get; set; }
        public decimal BeneficioMensalCorrigido { get; set; }
    }

    public class SimulacaoSabesprevBasico
    {
        public decimal ValorBeneficio { get; set; }

        public decimal FatorReducao { get; set; }

        public int Idade { get; set; }

        public DateTime Data { get; set; }

        public decimal ValorDeficit { get; set; }

        public decimal ValorDoIrrf { get; set; }

        public decimal ValorBeneficioLiquido { get; set; }
        public string IdadeApresentacao { get; set; }
    }
}
