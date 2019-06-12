using Intech.Lib.Util.Date;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Intech.PrevSystem.Metrus.API.Controllers.BeneficioController;

namespace Intech.PrevSystem.Metrus.Negocio
{
    public class SimuladorBeneficio
    {
        private List<Saldo> listaSaldosMinimo = new List<Saldo>();

        private List<Saldo> listaSaldosMedio = new List<Saldo>();

        private List<Saldo> listaSaldosMaximo = new List<Saldo>();

        /// <summary>
        /// Perfil selecionado para a simulação
        /// </summary>
        private PerfilInvestEntidade perfilSelecionado;

        /// <summary>
        /// Perfil conservador
        /// </summary>
        private PerfilInvestEntidade perfilConservador;

        /// <summary>
        /// Perfil Moderado
        /// </summary>
        private PerfilInvestEntidade perfilModerado;

        /// <summary>
        /// 
        /// </summary>
        public Saldo SaldoMinimo
        {
            get { return listaSaldosMinimo.Last(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Saldo SaldoMedio
        {
            get { return listaSaldosMedio.Last(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Saldo SaldoMaximo
        {
            get { return listaSaldosMaximo.Last(); }
        }

        private FuncionarioEntidade Funcionario;
        private DadosPessoaisEntidade Dados;
        private PlanoVinculadoEntidade PlanoVinculado;
        private string RecebimentoRendaMensal;
        private int IdadeAposentadoria;
        private decimal BeneficioMinimo;
        private int AnosPagamento;
        private decimal PercentualRecebimento;
        private decimal ContribuicoesBasicasParticipante;
        private decimal ContribuicoesSuplementaresParticipante;
        private decimal ContribuicoesPortabilidadeParticipante;
        private decimal ContribuicoesBasicasPatrocinadora;
        private decimal ContribuicoesSuplementaresPatrocinadora;

        public SimuladorBeneficio(FuncionarioEntidade funcionario, DadosPessoaisEntidade dados, PlanoVinculadoEntidade planoVinculado, string codigoPerfilSelecionado, ParametrosSimulacaoBeneficio parametros, decimal beneficioMinimo)
        {
            Funcionario = funcionario;
            Dados = dados;
            PlanoVinculado = planoVinculado;
            RecebimentoRendaMensal = parametros.RecebimentoRendaMensal;
            IdadeAposentadoria = parametros.IdadeAposentadoria;
            BeneficioMinimo = beneficioMinimo;
            AnosPagamento = parametros.AnosPagamento;
            PercentualRecebimento = parametros.PercentualRecebimento;
            perfilSelecionado = new PerfilInvestProxy().BuscarPorCodigoComEvolucoes(codigoPerfilSelecionado);
            perfilConservador = new PerfilInvestProxy().BuscarPorCodigoComEvolucoes("1");
            perfilModerado = new PerfilInvestProxy().BuscarPorCodigoComEvolucoes("2");
        }

        public ResultadoSimulacaoBeneficio RealizaSimulacao(List<EvolucaoContribuicao> evolucoes, decimal percentualParcelaVista, decimal? capitalSeguradoInvalidez, decimal? capitalSeguradoMorte)
        {
            CarregarContribuicoes(Funcionario, PlanoVinculado);
            CalculaSaldosNoTempo(evolucoes, percentualParcelaVista, Dados.DT_NASCIMENTO);

            return new ResultadoSimulacaoBeneficio()
            {
                SaldoMaximo = this.SaldoMaximo,
                SaldoMedio = this.SaldoMedio,
                SaldoMinimo = this.SaldoMinimo,
                NomePerfil = perfilSelecionado.DS_PERFIL_INVEST,
                CodigoPerfil = perfilSelecionado.CD_PERFIL_INVEST,
                HistoricoSaldoMaximo = listaSaldosMaximo,
                HistoricoSaldoMedio = listaSaldosMedio,
                HistoricoSaldoMinimo = listaSaldosMinimo,
                CapitalSeguradoInvalidez = capitalSeguradoInvalidez,
                CapitalSeguradoMorte = capitalSeguradoMorte
            };
        }

        public decimal BuscarEstimaBeneficioProjetado(Saldo saldo)
        {
            var fator = CalculaFatorAtuarial();
            var isBeneficioMinimo = RecebimentoRendaMensal != "PDT" &&
                saldo.EhBeneficioMinimo(fator, BeneficioMinimo);

            return saldo.CalculaBeneficioProjetado(fator, BeneficioMinimo, isBeneficioMinimo, RecebimentoRendaMensal == "PER");
        }

        private decimal CalculaFatorAtuarial()
        {
            decimal fator = 0;
            if (RecebimentoRendaMensal == "VIT")
                fator = ObtemFatorAposentadoriaVitalicia(IdadeAposentadoria);
            else if (RecebimentoRendaMensal == "PER")
                fator = PercentualRecebimento / 100;
            else
                fator = new FatAtuMetrusG1Proxy().BuscarPorTipoIdade("T2", AnosPagamento).FATOR.Value;
            return fator;
        }

        private decimal ObtemFatorAposentadoriaVitalicia(int idadeAposentadoria)
        {
            var fator = new FatSimuladorMetrusProxy().BuscarPorAno(idadeAposentadoria);

            if (Dados.SEXO == "M")
                return fator.FAT_MASC;
            else
                return fator.FAT_FEM;
        }

        private void CarregarContribuicoes(FuncionarioEntidade funcionario, PlanoVinculadoEntidade plano)
        {
            //var proxyContribuicaoIndividual = new ContribuicaoIndividualProxy();
            //ContribuicoesBasicasParticipante = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "20");
            //ContribuicoesSuplementaresParticipante = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "24");
            //ContribuicoesPortabilidadeParticipante = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "13");

            //ContribuicoesBasicasPatrocinadora = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "28");
            //ContribuicoesSuplementaresPatrocinadora = proxyContribuicaoIndividual.BuscarPorFundacaoInscricaoTipo(funcionario.CD_FUNDACAO, funcionario.NUM_INSCRICAO, "24");

            var fichaFinanceiraProxy = new FichaFinanceiraProxy();
            ContribuicoesBasicasParticipante = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "1").ValorParticipante;
            ContribuicoesSuplementaresParticipante = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "11").ValorParticipante;

            ContribuicoesBasicasPatrocinadora = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "2").ValorPatrocinadora;
            ContribuicoesSuplementaresPatrocinadora = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, plano.CD_PLANO, funcionario.NUM_INSCRICAO, "12").ValorPatrocinadora;
        }

        private void CalculaSaldosNoTempo(List<EvolucaoContribuicao> evolucoes, decimal percentualParcelaVista, DateTime dataNascimento)
        {
            Saldo saldoInicial;

            var saldosSimulacao = new SaldosSimulacao
            {
                ParticipanteBasica = ContribuicoesBasicasParticipante,
                ParticipanteSuplementar = ContribuicoesSuplementaresParticipante,
                //ParticipantePortabilidade = ContribuicoesPortabilidadeParticipante.Sum(x => x.VL_PERC_PAR.Value),
                PatrocinadoraNormal = ContribuicoesBasicasPatrocinadora,
                PatrocinadoraAdicional = ContribuicoesSuplementaresPatrocinadora
            };

            //se não houverem evoluções quer dizer que o participante já atingiu a idade para aposentadoria,
            //neste caso não é feita uma projeção e é retornado apenas o saldo já acumulado.
            if (evolucoes.Count == 0)
            {
                saldoInicial = new Saldo
                {
                    Participante = saldosSimulacao.ParticipanteTotal,
                    ParticipanteBasica = saldosSimulacao.ParticipanteBasica,
                    ParticipanteSuplementar = saldosSimulacao.ParticipanteSuplementar,
                    ParticipantePortabilidade = saldosSimulacao.ParticipantePortabilidade,
                    Patrocinadora = saldosSimulacao.PatrocinadoraTotal,
                    PatrocinadoraNormal = saldosSimulacao.PatrocinadoraNormal,
                    PatrocinadoraAdicional = saldosSimulacao.PatrocinadoraAdicional,
                    Taxa = 0,
                    PercentualVista = percentualParcelaVista
                };
            }
            else
            {
                saldoInicial = new Saldo
                {
                    Participante =
                                           saldosSimulacao.ParticipanteTotal + evolucoes[0].ContribuicaoParticipanteBasica +
                                           evolucoes[0].ContribuicaoParticipanteSuplementar,
                    Patrocinadora =
                                           saldosSimulacao.PatrocinadoraTotal + evolucoes[0].ContribuicaoPatrocinadoraNormal +
                                           evolucoes[0].ContribuicaoPatrocinadoraAdicional,
                    ParticipanteBasica =
                                           saldosSimulacao.ParticipanteBasica + evolucoes[0].ContribuicaoParticipanteBasica,
                    ParticipanteSuplementar =
                                           saldosSimulacao.ParticipanteSuplementar +
                                           evolucoes[0].ContribuicaoParticipanteSuplementar,
                    ParticipantePortabilidade = saldosSimulacao.ParticipantePortabilidade,
                    PatrocinadoraNormal =
                                           saldosSimulacao.PatrocinadoraNormal +
                                           evolucoes[0].ContribuicaoPatrocinadoraNormal,
                    PatrocinadoraAdicional =
                                           saldosSimulacao.PatrocinadoraAdicional +
                                           evolucoes[0].ContribuicaoPatrocinadoraAdicional,
                    Taxa = 0,
                    PercentualVista = percentualParcelaVista
                };                
            }

            listaSaldosMinimo.Add(saldoInicial);
            listaSaldosMedio.Add(saldoInicial);
            listaSaldosMaximo.Add(saldoInicial);

            TaxaEvolPerfilEntidade taxaProjetada = null;

            //pulou o primeiro item pois a taxa nao é aplicada
            for (int i = 1; i < evolucoes.Count; i++)
            {
                var evolucao = evolucoes[i];

                var perfilSelecionado = SelecionaPerfil(dataNascimento, evolucao.Data);

                taxaProjetada = ObtemTaxaProjetadaEm(perfilSelecionado, evolucao.Data.Ano);

                //o ultimo saldo da lista representao o saldo do mês anterior
                Saldo saldo = CriaSaldo(listaSaldosMinimo.Last(), taxaProjetada.CalcularTaxaMaximaMensal(), evolucao, percentualParcelaVista);
                listaSaldosMinimo.Add(saldo);

                saldo = CriaSaldo(listaSaldosMedio.Last(), taxaProjetada.CalcularTaxaMediaMensal(), evolucao, percentualParcelaVista);

                listaSaldosMedio.Add(saldo);

                saldo = CriaSaldo(listaSaldosMaximo.Last(), taxaProjetada.CalcularTaxaMaximaMensal(), evolucao, percentualParcelaVista);
                listaSaldosMaximo.Add(saldo);
            }
        }

        private PerfilInvestEntidade SelecionaPerfil(DateTime dataNascimento, MesAno data)
        {
            MesAno data60Anos = new MesAno(dataNascimento.AddYears(60));
            MesAno data55Anos = new MesAno(dataNascimento.AddYears(55));

            if (data >= data60Anos)
                return perfilConservador;

            if (data >= data55Anos && perfilSelecionado.CD_PERFIL_INVEST != perfilConservador.CD_PERFIL_INVEST)
                return perfilModerado;

            return perfilSelecionado;
        }

        private Saldo CriaSaldo(Saldo saldoAnterior, decimal taxa, EvolucaoContribuicao evolucao, decimal percentualParcelaVista)
        {
            Saldo saldo = new Saldo();

            //calcula o novo saldo do participante aplicando a taxa de correção sobre o valor do mês anterior e
            //adicionando a contribuição básica e a suplementar do participante para o mês corrente
            saldo.Participante = saldoAnterior.Participante + (saldoAnterior.Participante * taxa / 100M) +
                                 (evolucao.ContribuicaoParticipanteBasica + evolucao.ContribuicaoParticipanteSuplementar);

            saldo.ParticipanteBasica = saldoAnterior.ParticipanteBasica + (saldoAnterior.ParticipanteBasica * taxa / 100M) +
                                       evolucao.ContribuicaoParticipanteBasica;

            saldo.ParticipanteSuplementar = saldoAnterior.ParticipanteSuplementar +
                                            (saldoAnterior.ParticipanteSuplementar * taxa / 100M) +
                                            evolucao.ContribuicaoParticipanteSuplementar;

            saldo.ParticipantePortabilidade = saldoAnterior.ParticipantePortabilidade +
                                            (saldoAnterior.ParticipantePortabilidade * taxa / 100M);

            //calcula o novo saldo da patrocinadora aplicando a taxa de correção sobre o valor do mês anterior e
            //adicionando a contribuição normal e a adicional da patrocinadora para o mês corrente
            saldo.Patrocinadora = saldoAnterior.Patrocinadora + (saldoAnterior.Patrocinadora * taxa / 100M) +
                                  (evolucao.ContribuicaoPatrocinadoraNormal + evolucao.ContribuicaoPatrocinadoraAdicional);

            saldo.PatrocinadoraNormal = saldoAnterior.PatrocinadoraNormal + (saldoAnterior.PatrocinadoraNormal * taxa / 100M) +
                                        evolucao.ContribuicaoPatrocinadoraNormal;

            saldo.PatrocinadoraAdicional = saldoAnterior.PatrocinadoraAdicional +
                                           (saldoAnterior.PatrocinadoraAdicional * taxa / 100M) +
                                           evolucao.ContribuicaoPatrocinadoraAdicional;

            saldo.Data = evolucao.Data;

            //armazena a taxa utilizada
            saldo.Taxa = taxa;

            saldo.PercentualVista = percentualParcelaVista;

            return saldo;
        }

        public TaxaEvolPerfilEntidade ObtemTaxaProjetadaEm(PerfilInvestEntidade perfil, int ano) => 
            perfil.TaxasProjetadas.Where(x => Convert.ToInt32(x.ANO_RENTABILIDADE) <= ano).OrderByDescending(x => x.ANO_RENTABILIDADE).First();
    }
    
    public class SaldosSimulacao
    {
        public decimal ParticipanteBasica { get; set; }

        public decimal ParticipanteSuplementar { get; set; }

        public decimal ParticipantePortabilidade { get; set; }

        public decimal ParticipanteTotal => ParticipanteBasica + ParticipanteSuplementar;

        public decimal PatrocinadoraNormal { get; set; }

        public decimal PatrocinadoraAdicional { get; set; }

        public decimal PatrocinadoraTotal => PatrocinadoraNormal + PatrocinadoraAdicional;

        public decimal Total => ParticipanteTotal + PatrocinadoraTotal;
    }
}
