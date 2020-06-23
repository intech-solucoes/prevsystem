using Intech.Lib.Util.Date;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using Intech.PrevSystem.Metrus.Negocio;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficioController : Controller
    {
        private IEnumerable<ContribuicaoIndividualEntidade> ContribuicoesBasicasParticipante;
        private IEnumerable<ContribuicaoIndividualEntidade> ContribuicoesSuplementaresParticipante;
        private IEnumerable<ContribuicaoIndividualEntidade> ContribuicoesBasicasPatrocinadora;
        private IEnumerable<ContribuicaoIndividualEntidade> ContribuicoesSuplementaresPatrocinadora;
        private IEnumerable<FaixaValorContribEntidade> ContribuicoesEspeciaisParticipante;
        private IEnumerable<FaixaValorContribEntidade> ContribuicoesEspeciaisPatrocinadora;

        [HttpGet("parametros/{codEntid}")]
        public IActionResult BuscarParametros(string codEntid)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var plano = new PlanoVinculadoProxyMetrus().BuscarPorFundacaoEmpresaMatriculaComModalidades(funcionario, false).First();
                var suc = new IndiceValoresProxy().BuscarUltimoPorCodigo("SUC").First();

                var parametrosSimulacao = new ParametrosSimuladorBeneficio(plano.UltimoSalario, suc.VALOR_IND);

                return Json(new
                {
                    PercentualMaximoBasica = parametrosSimulacao.PercentualTotalContribuicoesBasicas,
                    ValorMaximoBasica = parametrosSimulacao.ValorTotalContribuicoesBasicas,
                    IdadeMinimaAposentadoria = 55,
                    IdadeMaximaAposentadoria = 85
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("simular")]
        public IActionResult Simular(ParametrosSimulacaoBeneficio parametros)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(parametros.CodEntid);
                var plano = new PlanoVinculadoProxyMetrus().BuscarPorFundacaoEmpresaMatriculaComModalidades(funcionario, false).First();
                var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(parametros.CodEntid);

                CarregarContribuicoes(funcionario, plano);

                var dataAposentadoria = dadosPessoais.DT_NASCIMENTO.AddYears(parametros.IdadeAposentadoria);
                    dataAposentadoria = DateTime.Compare(dataAposentadoria, DateTime.Now) > 0 ? dataAposentadoria : DateTime.Now;

                var limiteSalarioBeneficio = new IndiceValoresProxy().BuscarUltimoPorCodigo("TETOFUND").First().VALOR_IND;

                List<EvolucaoContribuicao> evolucaoContribuicoes = CriaEvolucoes(funcionario, plano, parametros.TaxaAnualCrescimento, parametros.IdadeAposentadoria, dataAposentadoria, parametros.ContribuicoesAtuais, parametros);

                decimal salarioRealBeneficio = CalculaSalarioRealBeneficio(evolucaoContribuicoes, limiteSalarioBeneficio);

                var beneficioMinimo = CalculaBeneficioMinimo(parametros.CodEntid, plano, salarioRealBeneficio, parametros.IdadeAposentadoria, dataAposentadoria, limiteSalarioBeneficio);

                var resultadoSimulacoes = new List<ResultadoSimulacaoBeneficio>();

                var perfis = new PerfilSitPlanoProxy().BuscarPorFundacaoSitPlano("01", plano.CD_SIT_PLANO);

                foreach (PerfilSitPlanoEntidade perfil in perfis)
                {
                    var simulador = new SimuladorBeneficio(funcionario, dadosPessoais, plano, perfil.CD_PERFIL_INVEST.ToString(), parametros, beneficioMinimo);

                    var resultadoSimulacao = simulador.RealizaSimulacao(evolucaoContribuicoes, parametros.PercentualSaldoAVista, null, null);
                    resultadoSimulacao.SaldoMinimo.EstimativaBeneficioProjetado = simulador.BuscarEstimaBeneficioProjetado(resultadoSimulacao.SaldoMinimo);
                    resultadoSimulacao.SaldoMedio.EstimativaBeneficioProjetado = simulador.BuscarEstimaBeneficioProjetado(resultadoSimulacao.SaldoMedio);
                    resultadoSimulacao.SaldoMaximo.EstimativaBeneficioProjetado = simulador.BuscarEstimaBeneficioProjetado(resultadoSimulacao.SaldoMaximo);

                    resultadoSimulacoes.Add(resultadoSimulacao);
                }

                var resultado = resultadoSimulacoes.First(x => x.CodigoPerfil == plano.CD_PERFIL_INVEST);

                return Json(new
                {
                    DataSimulacao = DateTime.Now.ToString("dd/MM/yyyy"),
                    dataAposentadoria,
                    resultado
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected List<EvolucaoContribuicao> CriaEvolucoes(FuncionarioEntidade funcionario, PlanoVinculadoEntidade planoVinculado, decimal taxaCrescimentoSalarial, int idadeAposentadoria, DateTime dataAposentadoria, bool contribuicoesAtuais , ParametrosSimulacaoBeneficio parametros)
        {
            var data = DateTime.Now.PrimeiroDiaDoMes();
            List<EvolucaoContribuicao> evolucoes = new List<EvolucaoContribuicao>();
            var faixaValorContrib = new FaixaValorContribProxy().BuscarPorFundacaoPlanoTipoContribMantenedora("01", "0002", "34", "1");

            var registro = (from dr in faixaValorContrib
                            orderby dr.ANO_REF, dr.MES_REF, dr.LIMITE_SUP_FAIXA
                            select dr).LastOrDefault();

            var limiteSRC = registro.LIMITE_SUP_FAIXA;

            decimal salarioComLimite = Math.Min(planoVinculado.UltimoSalario, limiteSRC);
            decimal salarioSemLimitante = planoVinculado.UltimoSalario;

            decimal varContribuicaoParticipanteBasica;
            decimal varContribuicaoParticipanteSuplementar;
            decimal varContribuicaoPatrocinadoraAdicional;
            decimal varContribuicaoPatrocinadoraNormal;

            while (data.MenorOuIgualQueMesAno(dataAposentadoria))
            {
                //if (participante.Empresa.DataBase.Month == data.Month)
                //{
                //    salarioComLimite = salarioComLimite * (1 + taxaCrescimentoSalarial / 100M);
                //    salarioSemLimitante = salarioSemLimitante * (1 + taxaCrescimentoSalarial / 100M);
                //}
                if (contribuicoesAtuais) //atuais
                {
                    var tipoContribPatrocinadoraNormal = "28";
                    var tipoContribPatrocinadoraAdicional = "24";
                    var tipoContribPartSuplementar = "24";

                    if(planoVinculado.CD_CATEGORIA == "3")
                    {
                        tipoContribPatrocinadoraNormal = "78";
                        tipoContribPatrocinadoraAdicional = "41";
                        tipoContribPartSuplementar = "74";
                    }

                    var contribuicoesBasicasPatrocinadora = new ContribuicaoIndividualProxy().BuscarPorFundacaoPlanoInscricaoTipo("01", planoVinculado.CD_PLANO, funcionario.NUM_INSCRICAO, tipoContribPatrocinadoraNormal);
                    var contribuicoesAdicionaisPatrocinadora = new ContribuicaoIndividualProxy().BuscarPorFundacaoPlanoInscricaoTipo("01", planoVinculado.CD_PLANO, funcionario.NUM_INSCRICAO, tipoContribPatrocinadoraAdicional);
                    var contribuicoesSuplementaresParticipante = new ContribuicaoIndividualProxy().BuscarPorFundacaoPlanoInscricaoTipo("01", planoVinculado.CD_PLANO, funcionario.NUM_INSCRICAO, tipoContribPartSuplementar);

                    varContribuicaoParticipanteBasica = salarioComLimite * (parametros.ContribuicaoBasica / 100);
                    varContribuicaoParticipanteSuplementar = salarioComLimite * (contribuicoesSuplementaresParticipante.VL_PERC_PAR.Value / 100);
                    varContribuicaoPatrocinadoraNormal= salarioComLimite * (contribuicoesBasicasPatrocinadora.VL_PERC_EMP.Value / 100);
                    varContribuicaoPatrocinadoraAdicional = salarioComLimite * (contribuicoesAdicionaisPatrocinadora.VL_PERC_EMP.Value / 100);
                }
                else //alterados
                {
                    varContribuicaoParticipanteBasica = salarioComLimite * (parametros.ContribuicaoBasica / 100);
                    varContribuicaoParticipanteSuplementar = salarioComLimite * (parametros.ContribuicaoSuplementar / 100);
                    varContribuicaoPatrocinadoraNormal = salarioComLimite * (parametros.ContribuicaoBasica / 100);
                    varContribuicaoPatrocinadoraAdicional = salarioComLimite * (parametros.ContribuicaoSuplementar / 100);
                }

                EvolucaoContribuicao contribuicao =
                    new EvolucaoContribuicao()
                    {
                        Data = new MesAno(data),
                        ContribuicaoParticipanteBasica = varContribuicaoParticipanteBasica,
                        ContribuicaoParticipanteSuplementar = varContribuicaoParticipanteSuplementar,
                        ContribuicaoPatrocinadoraAdicional = varContribuicaoPatrocinadoraAdicional,
                        ContribuicaoPatrocinadoraNormal = varContribuicaoPatrocinadoraNormal,

                        SalarioLimitado = salarioComLimite,
                        SalarioSemLimitante = salarioSemLimitante,
                        //TaxaSalario = participante.Empresa.DataBase.Month == data.Month
                        //        ? taxaCrescimentoSalarial
                        //        : 0
                        TaxaSalario = 0
                    };

                if (contribuicoesAtuais) //somente quando simulação de valores alterados
                {
                    contribuicao.ContribuicaoParticipanteSuplementar += parametros.ContribuicaoSuplementarVoluntaria;
                }

                evolucoes.Add(contribuicao);
                data = data.AddMonths(1);
            }

            return evolucoes;
        }

        private void CarregarContribuicoes(FuncionarioEntidade funcionario, PlanoVinculadoEntidade planoVinculado)
        {
            var proxyContribuicaoIndividual = new ContribuicaoIndividualProxy();
            ContribuicoesBasicasParticipante = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "20");
            ContribuicoesSuplementaresParticipante = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "24");

            ContribuicoesBasicasPatrocinadora = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "28");
            ContribuicoesSuplementaresPatrocinadora = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "24");

            ContribuicoesEspeciaisParticipante = new FaixaValorContribProxy().BuscarPorFundacaoPlanoTipoContribMantenedora(funcionario.CD_FUNDACAO, planoVinculado.CD_PLANO, "46", "2");
            ContribuicoesEspeciaisPatrocinadora = new FaixaValorContribProxy().BuscarPorFundacaoPlanoTipoContribMantenedora(funcionario.CD_FUNDACAO, planoVinculado.CD_PLANO, "34", "1");
        }

        private decimal CalculaSalarioRealBeneficio(List<EvolucaoContribuicao> contribuicoes, decimal limiteSalarioBeneficio)
        {
            if (contribuicoes.Count == 0)
                throw new Exception("Contribuições para Cálculo do SRB não encontradas.");

            if (contribuicoes.Count > 12)
            {
                var contribuicoesOrdenadas = contribuicoes.OrderByDescending(x => x.Data).ToList();
                var top12 = contribuicoesOrdenadas.Take(12).ToList();
                return Math.Min(top12.Sum(x => x.SalarioSemLimitante) / 12M, limiteSalarioBeneficio);
            }

            return Math.Min(contribuicoes.Sum(x => x.SalarioSemLimitante) / contribuicoes.Count, limiteSalarioBeneficio);
        }

        private decimal CalculaBeneficioMinimo(string codEntid, PlanoVinculadoEntidade planoVinculado, decimal salarioRealBeneficio, int idadeAposentadoria, DateTime dataAposentadoria, decimal limiteSalarioBeneficio)
        {
            var tempoTotalContribuicao = TempoTotalDeContribuicao(codEntid);
            Intervalo tempoServicoProjetadoCreditado = tempoTotalContribuicao +
                                                       new Intervalo(dataAposentadoria, DateTime.Now, new CalculoAnosMesesDiasAlgoritmo2());
            if (tempoServicoProjetadoCreditado.Dias >= 15)
                tempoServicoProjetadoCreditado = new Intervalo(tempoServicoProjetadoCreditado.Anos, tempoServicoProjetadoCreditado.Meses + 1, 0);

            //Benefício Mínimo:
            //10% MIN(SRB, TETOFUND)
            decimal beneficioMinimo = (salarioRealBeneficio > limiteSalarioBeneficio
                                           ? limiteSalarioBeneficio
                                           : salarioRealBeneficio)
                                           * 0.1M;

            if (planoVinculado.FUNDADOR != DMN_SN.SIM)
                beneficioMinimo = beneficioMinimo * ((Math.Min(Convert.ToDecimal((Convert.ToDouble(tempoServicoProjetadoCreditado.Meses) / 12D) + Convert.ToDouble(tempoServicoProjetadoCreditado.Anos)), 20) + 5) / 25M);

            if (idadeAposentadoria < 60)
            {
                int mesesDeReducao = (60 - idadeAposentadoria) * 12;
                beneficioMinimo = beneficioMinimo - (beneficioMinimo * (mesesDeReducao * 0.416667M / 100M));
            }
            return beneficioMinimo;
        }

        public Intervalo TempoTotalDeContribuicao(string codEntid)
        {
            var cp = new CalculoPeriodo();

            var periodos = new TempoServicoProxy().BuscarPorCodEntidSemConcomitancia(codEntid);

            Intervalo intervalo = cp.CalculaDuracao(periodos, null, null, new CalculoAnosMesesDiasAlgoritmo2());
            //adiciona 1 dia para incluir a data inicial
            intervalo.Adiciona(1);
            return intervalo;
        }

        //public Intervalo TempoTotalAutoPatrocinio()
        //{
        //    CalculoPeriodo cp = new CalculoPeriodo();
        //    List<IPeriodo> periodos = new List<IPeriodo>();
        //    PeriodosAutoPatrocinados.ForEach(x => periodos.Add(x));
        //    return cp.CalculaDuracao(periodos, null, null, new CalculoAnosMesesDiasAlgoritmo2());
        //}

        public class ParametrosSimulacaoBeneficio
        {
            public string CodEntid { get; set; }
            public int IdadeAposentadoria { get; set; }
            public int AnosPagamento { get; set; }
            public decimal ContribuicaoBasica { get; set; }
            public decimal ContribuicaoSuplementar { get; set; }
            public decimal ContribuicaoSuplementarVoluntaria { get; set; }
            public decimal PercentualSaldoAVista { get; set; }
            public string RecebimentoRendaMensal { get; set; }
            public decimal PercentualRecebimento { get; set; }
            public decimal TaxaAnualCrescimento { get; set; }
            public bool ContribuicoesAtuais { get; set; }
        }

        public class EvolucaoContribuicao
        {
            public MesAno Data { get; set; }
            public decimal TaxaSalario { get; set; }
            public decimal SalarioLimitado { get; set; }
            public decimal SalarioSemLimitante { get; set; }
            public decimal ContribuicaoParticipanteBasica { get; set; }
            public decimal ContribuicaoParticipanteSuplementar { get; set; }
            public decimal ContribuicaoPatrocinadoraNormal { get; set; }
            public decimal ContribuicaoPatrocinadoraAdicional { get; set; }
            public decimal ContribuicaoInvalidez { get; set; }
            public decimal ContribuicaoMorte { get; set; }

            public EvolucaoContribuicao() { }
        }

        public class ResultadoSimulacaoBeneficio
        {
            public string NomePerfil { get; set; }

            public decimal CodigoPerfil { get; set; }

            public Saldo SaldoMinimo { get; set; }

            public Saldo SaldoMedio { get; set; }

            public Saldo SaldoMaximo { get; set; }

            public List<Saldo> HistoricoSaldoMinimo { get; set; }

            public List<Saldo> HistoricoSaldoMedio { get; set; }

            public List<Saldo> HistoricoSaldoMaximo { get; set; }

            public Decimal? CapitalSeguradoInvalidez { get; set; }

            public Decimal? CapitalSeguradoMorte { get; set; }
        }
        public class Saldo
        {
            private decimal _taxa;

            /// <summary>
            /// Taxa de reajuste aplicada
            /// </summary>
            public decimal Taxa
            {
                get { return _taxa; }
                set { _taxa = value.Arredonda(2); }
            }

            private decimal _participante;

            /// <summary>
            /// Saldo do participante
            /// </summary>
            public decimal Participante
            {
                get { return _participante; }
                set { _participante = value.Arredonda(2); }
            }

            private decimal participanteSuplementar;
            public decimal ParticipanteSuplementar
            {
                get { return participanteSuplementar; }
                set { participanteSuplementar = value.Arredonda(2); }
            }

            private decimal participantePortabilidade;
            public decimal ParticipantePortabilidade
            {
                get { return participantePortabilidade; }
                set { participantePortabilidade = value.Arredonda(2); }
            }


            private decimal participanteBasica;
            public decimal ParticipanteBasica
            {
                get { return participanteBasica; }
                set { participanteBasica = value.Arredonda(2); }
            }

            private decimal patrocinadoraNormal;
            public decimal PatrocinadoraNormal
            {
                get { return patrocinadoraNormal; }
                set { patrocinadoraNormal = value.Arredonda(2); }
            }

            private decimal patrocinadoraAdicional;
            public decimal PatrocinadoraAdicional
            {
                get { return patrocinadoraAdicional; }
                set { patrocinadoraAdicional = value.Arredonda(2); }
            }

            private decimal _patrocinadora;

            /// <summary>
            /// Saldo da patrocinadora
            /// </summary>
            public decimal Patrocinadora
            {
                get { return _patrocinadora; }
                set { _patrocinadora = value.Arredonda(2); }
            }

            /// <summary>
            /// Saldo total (Participante + Patrocinadora)
            /// </summary>
            public decimal Total
            {
                get { return Patrocinadora + Participante; }
            }

            /// <summary>
            /// 99,99% do saldo total à vista
            /// </summary>
            public decimal TotalVista
            {
                get { return Total * (PercentualVista / 100); }
            }

            /// <summary>
            /// Soma dos saldos Basica e Normal do Participante + Adicional da Patrocinadora
            /// </summary>
            public decimal SaldoSemSuplementar
            {
                get { return this.ParticipanteBasica + this.PatrocinadoraNormal + this.PatrocinadoraAdicional; }
            }

            /// <summary>
            /// Data do saldo
            /// </summary>
            public MesAno Data { get; set; }

            private decimal _percentualVista;

            /// <summary>
            /// Percentual da Parcela do Saldo de contribuição à vista
            /// </summary>
            public decimal PercentualVista
            {
                get { return _percentualVista; }
                set { _percentualVista = value; }
            }

            //public decimal EstimativaBeneficioProjetado
            //{
            //    get { return (Total - TotalVista) / 240; }
            //}

            public decimal EstimativaBeneficioProjetado { get; set; }

            public Saldo()
            {

            }

            public bool EhBeneficioMinimo(decimal fatorAtuarial, decimal beneficioMinimo)
            {
                decimal saldoSemSuplementar = SaldoSemSuplementar;
                decimal beneficioSemSuplementar = saldoSemSuplementar / fatorAtuarial;
                if (beneficioSemSuplementar < beneficioMinimo)
                {
                    return true;
                }
                return false;
            }

            public decimal CalculaBeneficioProjetado(decimal fatorAtuarial, decimal beneficioMinimo, bool ehBeneficioMinimo, bool percentual = false)
            {
                if (ehBeneficioMinimo)
                {
                    return beneficioMinimo + CalculaBeneficioSuplementar(fatorAtuarial);
                }

                if (percentual)
                    return (Total - TotalVista) * (fatorAtuarial);
                else
                    return (Total - TotalVista) / (fatorAtuarial);
            }

            public decimal CalculaBeneficioSuplementar(decimal fatorAtuarial, bool percentual = false)
            {
                if (percentual)
                    return participanteSuplementar * fatorAtuarial;
                else
                    return participanteSuplementar / fatorAtuarial;
            }

            public override string ToString()
            {
                return string.Format("{0};{1:C};{2:C};{3};{4}", _taxa, _participante, _patrocinadora, _percentualVista, Data);
            }
        }

    }
}