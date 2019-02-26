using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using Intech.PrevSystem.Negocio.Proxy;
using Intech.PrevSystem.Negocio.Sabesprev.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Negocio.Sabesprev
{
    public class ContratoDisponivel
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal Oid { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Fundacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Ano { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Numero { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal SequenciaRubrica { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal OidSituacaoContrato { get; set; }

        public String SituacaoContrato { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal OidModalidade { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ModalidadeEntidade Modalidade { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal OidNatureza { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public NaturezaEntidade Natureza { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DataCredito { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DataCreditoAuxiliar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DataSolicitacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorSolicitado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Prazo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorJurosQuitacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorIOF { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorReformado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorLiquido { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorSaldoQuitacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorCorrigido { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal TaxaJuros { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorPrestacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorAReformar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorAdministracao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorSeguro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorInadimplencia { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorRenov { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ValorAntecipacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal NumeroGrupoFamiliar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<PrestacaoEntidade> Prestacoes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<PrestacaoParcialEntidade> PrestacoesParciais { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TaxaEncargoPlanoEntidade> taxaEncargo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SaldoDevedorEntidade SaldoDevedor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<TaxaConcessaoPlanoEntidade> taxaConcessao { get; set; }

        /// <summary>
        /// Hiulli - Criado para fazer um filtro dos contratos sem utilizar o builder de emprestimo.
        /// </summary>
        public string CodigoPlano { get; set; }

        public bool PrestacoesMinimasPagas { get; set; }

        //public decimal SequenciaRubrica { get; set; }
        public decimal ValorAtualizacao { get; set; }
        public decimal ValorLimitePrestacao { get; set; }
        public decimal ValorLimiteParticipante { get; set; }
        public decimal Fator { get; set; }
        public DateTime DataVencimentoInicial { get; set; }
        public DateTime DataVencimentoFinal { get; set; }

        public DateTime DataVencimentoPrestacao { get; set; }
        public bool Disponivel { get; set; }
        public decimal TaxaJurosOriginal { get; set; }

        public string DescricaoDisponivel
        {
            get
            {
                return Disponivel ? "Permitido" : "Não Permitido";
            }
        }

        public string Motivo { get; set; }
        public decimal ValorTaxaAdministracao { get; set; }
        public decimal ValorTaxaSeguro { get; set; }
        public decimal ValorTaxaSeguroEspecial { get; set; }
        public decimal ValorTaxaRenovacao { get; set; }
        public decimal ValorTaxaInadimplencia { get; set; }
        //public decimal TaxaJuros { get; set; }
        //public string CodigoPlano { get; set; }
        public DateTime DataInscricao { get; set; }
        public string FormaCredito { get; set; }
        public decimal Carencia { get; set; }

        public ContratoDisponivel() { }

        public ContratoDisponivel(
              decimal Oid
            , decimal SequenciaRubrica
            , decimal PrazoDisponivel
            , decimal ValorSolicitado
            , decimal ValorAtualizacao
            , decimal ValorPrestacao
            , decimal ValorLimitePrestacao
            , decimal Fator
            , DateTime VencimentoInicial
            , DateTime VencimentoFinal
            , bool Disponivel
            , string Motivo
            , decimal ValorTaxaIOF
            , decimal ValorTaxaAdministracao
            , decimal ValorTaxaSeguro
            , decimal ValorTaxaSeguroEspecial
            , decimal ValorTaxaRenovacao
            , decimal ValorTaxaInadimplencia
            , decimal ValorLiquido
            , decimal TaxaJuros
            , decimal TaxaJurosOriginal
            , decimal Carencia
            )
        {
            this.Oid = Oid;
            this.SequenciaRubrica = SequenciaRubrica;
            this.Prazo = PrazoDisponivel;
            this.ValorSolicitado = ValorSolicitado;
            this.ValorAtualizacao = ValorAtualizacao;
            this.ValorPrestacao = ValorPrestacao;
            this.ValorLimitePrestacao = ValorLimitePrestacao;
            this.Fator = Fator;
            this.DataVencimentoInicial = VencimentoInicial;
            this.DataVencimentoFinal = VencimentoFinal;
            this.Disponivel = Disponivel;
            this.Motivo = Motivo;
            this.ValorIOF = ValorTaxaIOF;
            this.ValorTaxaAdministracao = ValorTaxaAdministracao;
            this.ValorTaxaSeguro = ValorTaxaSeguro;
            this.ValorTaxaSeguroEspecial = ValorTaxaSeguroEspecial;
            this.ValorTaxaRenovacao = ValorTaxaRenovacao;
            this.ValorTaxaInadimplencia = ValorTaxaInadimplencia;
            this.ValorLiquido = ValorLiquido;
            this.TaxaJuros = TaxaJuros;
            this.TaxaJurosOriginal = TaxaJurosOriginal;
            this.Carencia = Carencia;
        }

        public List<ContratoDisponivel> BuscarContratosDisponiveis(FuncionarioEntidade funcionario, Concessao concessao, string cdPlano, decimal codModalidade, decimal codNatureza, DateTime dataCredito, decimal valorSolicitado, decimal mesesDeCarencia = 0, decimal quantidadeParcelas = 0)
        {
            //buscar dados dos parametros p/ verificar se a pessoa possui contratos maximo
            var param = new ParametrosProxy();
            var parametros = param.Buscar();

            //Concessao c = p.Concessao;

            var NaturProxy = new NaturezaProxy();
            var natureza = NaturProxy.BuscarPorCdNatur(codNatureza);

            //Buscando classes Modalidade e Natureza
            //buscar modalidade e natureza novamente
            var ModalProxy = new ModalidadeProxy();
            var modalidade = ModalProxy.BuscarPorCodigo(codModalidade);
            
            var encargo = new TaxaEncargoPlanoProxy().BuscarPorFundacaoEmpresaModalidadeNaturezaPlanoDtInicioVigencia(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, modalidade.CD_MODAL, natureza.CD_NATUR, cdPlano, DateTime.Today)
                        .Where(x => x.DT_INIC_VIGENCIA <= DateTime.Now && x.DT_TERM_VIGENCIA == null)
                        .OrderBy(x => x.DT_INIC_VIGENCIA)
                        .LastOrDefault();

            if (encargo == null) // nao possui encargos para esta natureza, retorna vazio
                return null;

            var taxaConcessao = new TaxaConcessaoPlanoProxy().BuscarPorFundacaoEmpresaModalidadeNaturezaPlano(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, modalidade.CD_MODAL, natureza.CD_NATUR, cdPlano).LastOrDefault();

            //buscar todos os periodos disponiveis dentro da natureza escolhida
            var contratos = new List<ContratoDisponivel>();

            var PrazoDispProxy = new PrazosDisponiveisProxy();

            var Prazos = new List<PrazosDisponiveisEntidade>();

            if (quantidadeParcelas == 0)
                Prazos = PrazoDispProxy.BuscarPorNatureza(natureza.CD_NATUR).ToList();
            else
                Prazos = PrazoDispProxy.BuscarPorNaturezaPrazo(natureza.CD_NATUR, quantidadeParcelas).ToList();

            string controle = parametros.CONTROLE_CONTR_ATIVOS == null ? "P" : parametros.CONTROLE_CONTR_ATIVOS;
            var qtde = parametros.MAX_CONTR_ATIVOS == null ? 0 : parametros.MAX_CONTR_ATIVOS;

            var contratosAReformar = new ContratoProxySabesprev().BuscarPorFundacaoEmpresaInscricaoSituacao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_INSCRICAO, "3", dataCredito.ToString()).ToList();
            var contratoAReformar = contratosAReformar.FirstOrDefault();

            string MotivoGlobal = "";

            //if ((controle == "P") && (contratosAReformar.Count != 0 && contratosAReformar.Count >= qtde))
            //MotivoGlobal += "O participante já possui o limite máximo de contratos estipulados pelo sistema.\n";

            bool PrestacoesMinimasPagas = true;
            bool PercentualMinimoPago = true;

            if (contratosAReformar.Count > 0)
            {
                decimal? percentualPago = (contratoAReformar.Prestacoes.Count * 100) / contratoAReformar.PRAZO;

                var naturezaContrato = new NaturezaProxy().BuscarPorCdNatur(contratoAReformar.CD_NATUR);

                if (percentualPago < naturezaContrato.RENOVACAO_MIN_PERC)
                    PercentualMinimoPago = false;
            }

            decimal i = 0; //será o OID dos contratos disponíveis

            foreach (var PrazoDisponivel in Prazos)
            {
                i++;

                decimal ValorPrestacao = 0;
                decimal Fator = 0;

                DateTime dtAniversario;
                DateTime VencimentoInicial = DateTime.Now; // só para inicialização
                DateTime VencimentoFinal = DateTime.Now;

                decimal ValorTaxaIOF = 0;
                decimal ValorIOFAuxiliar = 0;
                decimal valorACobrarIOF = 0;
                decimal ValorAdministracao = 0;
                decimal ValorSeguro = 0;
                decimal valorSeguroEspecial = 0;
                decimal ValorRenovacao = 0;
                decimal ValorInadimplencia = 0;
                decimal ValorAtualizacao = 0;
                decimal CorrecaoCarenciaSaldoDevedor = 0;

                dtAniversario = ObterDataAniversarioNatureza(natureza, dataCredito);

                VencimentoInicial = ObterDataVencimento(natureza, dtAniversario, true, PrazoDisponivel.PRAZO);
                VencimentoFinal = ObterDataVencimento(natureza, dtAniversario, false, PrazoDisponivel.PRAZO);
                Fator = ObterFator(taxaConcessao.TX_JUROS.Value, PrazoDisponivel.PRAZO);

                //Parei aqui

                ValorAtualizacao = ObterValorAtualizacao(funcionario, modalidade, natureza, encargo, taxaConcessao, valorSolicitado, dataCredito);

                if (mesesDeCarencia > 0)
                {
                    CorrecaoCarenciaSaldoDevedor = valorSolicitado + ValorAtualizacao;

                    decimal saldoAnterior = 0;
                    decimal jurosPrest = 0;

                    for (int f = 0; f < mesesDeCarencia; f++)
                    {
                        saldoAnterior = CorrecaoCarenciaSaldoDevedor;
                        jurosPrest = (CorrecaoCarenciaSaldoDevedor * (taxaConcessao.TX_JUROS.Value / 100)).Arredonda(2);
                        CorrecaoCarenciaSaldoDevedor = (CorrecaoCarenciaSaldoDevedor + jurosPrest).Arredonda(2);
                    }

                    CorrecaoCarenciaSaldoDevedor = CorrecaoCarenciaSaldoDevedor - (valorSolicitado + ValorAtualizacao);
                }

                decimal ValorLiquido = 0;

                bool recalcula = true;
                var valReformado = contratoAReformar != null ? contratoAReformar.SaldoDevedor.ValorReformado : 0;

                while (recalcula)
                {
                    if (natureza.CD_NATUR == 15)
                    {
                        ValorAtualizacao = ObterValorAtualizacao(funcionario, modalidade, natureza, encargo, taxaConcessao, valorSolicitado, dataCredito);
                    }
                    else
                    {
                        recalcula = false;
                    }

                    if (ValorLiquido == 0)
                    {
                        recalcula = false;
                    }
                    var ValorPrincipalMaisJurosContratosAReformar = 0M;

                    if (encargo.IOF_IN1609 == DMN_SN.SIM)
                    {
                        if (contratosAReformar.Any())
                        {
                            foreach (var item in contratosAReformar)
                            {
                                if (item.PRAZO > 12)
                                {
                                    ValorPrincipalMaisJurosContratosAReformar += item.SaldoDevedor.ValorPrincQuitacao
                                                                                + item.SaldoDevedor.ValorPrincPrestAtraso + item.SaldoDevedor.ValorPrincPrestMes;
                                }
                            }
                        }
                    }

                    ValorIOFAuxiliar = CalculaValorIof(natureza, encargo, dataCredito, valorSolicitado, ValorAtualizacao + CorrecaoCarenciaSaldoDevedor, taxaConcessao.TX_JUROS.Value, (int)PrazoDisponivel.PRAZO, mesesDeCarencia);

                    valorACobrarIOF = valorSolicitado - ValorPrincipalMaisJurosContratosAReformar;

                    ValorTaxaIOF = valorACobrarIOF * (ValorIOFAuxiliar / valorSolicitado);

                    ValorAdministracao = CalculaValorAdministracao(encargo, valorSolicitado, valReformado, PrazoDisponivel.PRAZO);

                    if (ValorPrincipalMaisJurosContratosAReformar > 0)
                        ValorSeguro = CalculaValorSeguro(funcionario, encargo, valorSolicitado, ValorPrincipalMaisJurosContratosAReformar);
                    else
                        ValorSeguro = CalculaValorSeguro(funcionario, encargo, valorSolicitado, valReformado);

                    ValorInadimplencia = CalculaValorInadimplencia(encargo, valorSolicitado, valReformado, PrazoDisponivel.PRAZO);

                    ValorLiquido = CalculaValorLiquido(valorSolicitado, ValorAtualizacao, ValorTaxaIOF, ValorAdministracao, ValorSeguro, valorSeguroEspecial, ValorInadimplencia, ValorRenovacao, valReformado);

                    //if (natureza.CD_NATUR == 15 && ValorLiquido != 0)
                    //    valorSolicitado -= ValorLiquido;
                }

                if (modalidade.RESULTADO_CORRE == "A")
                {
                    decimal saldo = 0;
                    decimal saldoAnterior = valorSolicitado + ValorAtualizacao;
                    decimal jurosAxuliar = 0;

                    for (int z = 0; z < mesesDeCarencia; z++)
                    {
                        jurosAxuliar = (saldoAnterior * (taxaConcessao.TX_JUROS.Value / 100));
                        saldo = (saldoAnterior + jurosAxuliar);
                        saldoAnterior = saldo;
                    }

                    if (saldo > 0)
                    {
                        saldo = saldo - (valorSolicitado + ValorAtualizacao);
                    }

                    ValorPrestacao = ObtemUmaPrestacao((valorSolicitado + ValorAtualizacao + saldo), PrazoDisponivel.PRAZO, taxaConcessao, encargo);
                }
                else
                {
                    ValorPrestacao = ObtemUmaPrestacao(valorSolicitado, PrazoDisponivel.PRAZO, taxaConcessao, encargo);
                }

                string Motivo = "";
                bool Disponibilidade = VerificarDisponibilidadeGlobal(concessao, MotivoGlobal, ValorPrestacao, ValorLiquido, valorSolicitado, ref Motivo);

                if (Disponibilidade && ((!PrestacoesMinimasPagas || !PercentualMinimoPago) && natureza.DS_NATUR.Substring(0, 3) != "EXC"))
                {
                    Disponibilidade = false;
                    Motivo += "Contrato não pode ser reformado, quantidade ou percentual de parcelas pagas menor que o limite mínimo";
                }

                if (encargo.TP_COBRANCA_TX == "P" && encargo.TP_COBRANCA_INAD == "P" && encargo.TP_COBRANCA_SEGURO == "P" && encargo.TIPO_CALC_ADM == "P")
                {
                    decimal valorPrestacaoAux = ValorPrestacao;
                    ValorPrestacao += (valorPrestacaoAux * (encargo.TX_ADM / 100)).Value.Trunca(2);

                    ValorSeguro = (valorPrestacaoAux * (encargo.TX_SEGURO / 100)).Value.Trunca(2);
                    ValorPrestacao += ValorSeguro;


                    ValorPrestacao += (valorPrestacaoAux * (encargo.TX_INAD.Value / 100)).Arredonda(2);
                }

                //Buscar data da inscricao do plano selecionado

                if (Disponibilidade)
                {
                    var contratoDisponivel =
                        new ContratoDisponivel
                        {
                            Oid = i,
                            DataCredito = dataCredito,
                            DataCreditoAuxiliar = dataCredito,
                            Modalidade = modalidade,
                            Natureza = natureza,
                            Prazo = PrazoDisponivel.PRAZO,
                            ValorSolicitado = valorSolicitado,
                            ValorAtualizacao = ValorAtualizacao,
                            ValorPrestacao = ValorPrestacao,
                            //ValorLimitePrestacao = c.MargemConsignavelCalculada,
                            Fator = Fator,
                            DataVencimentoInicial = VencimentoInicial,
                            DataVencimentoFinal = VencimentoFinal,
                            DataVencimentoPrestacao = VencimentoInicial.AddMonths(Convert.ToInt32(PrazoDisponivel.PRAZO) - 1),
                            Disponivel = Disponibilidade,
                            Motivo = Motivo,
                            ValorIOF = ValorTaxaIOF,
                            ValorTaxaAdministracao = ValorAdministracao,
                            ValorTaxaSeguro = ValorSeguro,
                            ValorTaxaSeguroEspecial = valorSeguroEspecial,
                            ValorTaxaRenovacao = ValorRenovacao,
                            ValorTaxaInadimplencia = ValorInadimplencia,
                            ValorLiquido = ValorLiquido,
                            CodigoPlano = cdPlano,
                            //DataInscricao = dtInscr,
                            TaxaJuros = taxaConcessao.TX_JUROS.Value,
                            TaxaJurosOriginal = taxaConcessao.TX_JUROS.Value,
                            Carencia = mesesDeCarencia,
                            ValorReformado = valReformado
                        };

                    //VerificaDisponibilidadePorCliente(c, contratoDisponivel, p, plano, codModalidade, codNatureza);
                    contratos.Add(contratoDisponivel);
                }
            }

            return contratos.OrderBy(x => x.Prazo).ToList();
        }

        private bool VerificarDisponibilidadeGlobal(Concessao concessao, string motivoGlobal, decimal valorPrestacao, decimal valorLiquido, decimal valorSolicitado, ref string motivo)
        {
            if ((concessao.ValorLimite >= 0) & (valorSolicitado.Arredonda(2) > concessao.TetoMaximo.Arredonda(2)))
                motivo += "Valor Solicitado excede o teto máximo estipulado\n";

            if ((concessao.TetoMinimo >= 0) & (valorSolicitado.Arredonda(2) < concessao.TetoMinimo.Arredonda(2)))
                motivo += "Valor Solicitado inferior ao teto mínimo estipulado \n";

            if (valorPrestacao.Arredonda(2) > concessao.MargemConsignavelCalculada.Arredonda(2))
                motivo += "Valor da Prestação excede o Valor da margem consignável calculado \n";

            if (valorSolicitado.Arredonda(2) < concessao.ValorContratosReformados.Arredonda(2))
                motivo += "Valor solicitado inferior ao valor dos contratos a reformar \n";

            if (valorLiquido < 0)
                motivo += "Saldo insuficiente \n";

            motivo += motivoGlobal;

            return (motivo == "") ? true : false;
        }

        private decimal ObterFator(decimal TaxaJuros, decimal Prazo)
        {
            if (TaxaJuros == 0) return 0;

            var fator = (decimal)((Math.Pow((1 + (double)TaxaJuros / 100), (double)Prazo) * (double)TaxaJuros / 100)
                                   / (Math.Pow((1 + (double)TaxaJuros / 100), (double)Prazo) - 1));

            return fator;
        }

        private DateTime ObterDataAniversarioNatureza(NaturezaEntidade natureza, DateTime dataCredito)
        {
            DateTime w_dt_aux;
            int w_mes = 0;
            int w_ano = 0;

            if (natureza.MES_CRED_CIVIL == DMN_SN.NAO)
            {
                w_mes = dataCredito.Month;
                w_ano = dataCredito.Year;

                if ((natureza.DIA_VENC_PREST == 99) || (natureza.DIA_VENC_PREST == 0))
                    w_dt_aux = new DateTime(w_ano, w_mes, dataCredito.UltimoDiaDoMes().Day);
                else
                    w_dt_aux = new DateTime(w_ano, w_mes, (int)natureza.DIA_VENC_PREST);

                if (w_dt_aux < dataCredito)
                    w_dt_aux = w_dt_aux.AddMonths(1);
            }
            else
            {
                w_dt_aux = new DateTime(dataCredito.Year, dataCredito.Month, dataCredito.UltimoDiaDoMes().Day);
            }

            return w_dt_aux;
        }

        private DateTime ObterDataVencimento(NaturezaEntidade natureza, DateTime dtCredito, bool Inicial, decimal Prazo)
        {
            DateTime w_dt_venc;
            int w_dia, w_mes, w_ano;
            w_dia = 0;
            w_mes = 0;
            w_ano = 0;

            if (Inicial)
                dtCredito = dtCredito.AddMonths((int)natureza.MES_CALC_PREST);
            else
                dtCredito = dtCredito.AddMonths((int)(Prazo + natureza.MES_CALC_PREST));

            w_mes = dtCredito.Month;
            w_ano = dtCredito.Year;

            if ((natureza.DIA_VENC_PREST == 99) | (natureza.DIA_VENC_PREST == 0))
                w_dia = dtCredito.UltimoDiaDoMes().Day;
            else
            {
                w_dia = (int)natureza.DIA_VENC_PREST;
                if ((w_dia > 28) & (w_mes == 2))
                    w_dia = dtCredito.UltimoDiaDoMes().Day;
            }

            w_dt_venc = new DateTime(w_ano, w_mes, w_dia);
            if (w_dt_venc.DayOfWeek == DayOfWeek.Sunday)
            {
                //antecipar
                if (natureza.DT_VENC_FSF == "A")
                    w_dt_venc = w_dt_venc.AddDays(-2);

                //prorrogar
                if (natureza.DT_VENC_FSF == "P")
                    w_dt_venc = w_dt_venc.AddDays(1);
            }
            else if (w_dt_venc.DayOfWeek == DayOfWeek.Saturday)
            {
                //antecipar
                if (natureza.DT_VENC_FSF == "A")
                    w_dt_venc = w_dt_venc.AddDays(-1);

                //prorrogar
                if (natureza.DT_VENC_FSF == "P")
                    w_dt_venc = w_dt_venc.AddDays(2);
            }

            return w_dt_venc;
        }

        public decimal ObterValorAtualizacao(FuncionarioEntidade funcionario,
                                             ModalidadeEntidade modalidade, NaturezaEntidade natureza, TaxaEncargoPlanoEntidade txEncargo,
                                             TaxaConcessaoPlanoEntidade txConcessao, decimal ValorSolicitado,
                                             DateTime dtCredito)
        {

            TimeSpan w_dif_dias;
            decimal w_vl_corrigido, w_calc, w_fator;
            DateTime w_dt_ind, w_dt_aux;
            int w_num_dias;//, w_mes, w_ano;

            w_vl_corrigido = 0;
            w_calc = 0;
            w_fator = 0;

            if ((modalidade.PRORATA_TX_JUROS == DMN_SN.NAO) & (modalidade.CORRIGIR) == DMN_SN.SIM)
            {
                if (modalidade.DIA_CORRECAO == "U")
                    w_num_dias = dtCredito.UltimoDiaDoMes().Day;
                else
                    w_num_dias = 30;

                w_dt_aux = ObterDataAniversarioNatureza(natureza, dtCredito);

                w_dif_dias = w_dt_aux - dtCredito;
                //w_dif_dias = w_dt_aux - dtCredito;

                if (string.IsNullOrEmpty(modalidade.IND_CORR_VL_SOLIC))
                {
                    w_calc = (decimal)Math.Pow((double)((txConcessao.TX_JUROS.Value / 100) + 1), (1 / (double)w_num_dias));
                    w_fator = (decimal)Math.Pow((double)w_calc, w_dif_dias.Days);
                    w_fator -= 1;
                    w_vl_corrigido = (ValorSolicitado * w_fator).Arredonda(2);
                }
                else
                {
                    if ((txConcessao.IND_DEFAZAGEM == DMN_SN.SIM) & (txConcessao.IND_MESES_DEFAZAGEM > 0))
                        w_dt_ind = dtCredito.AddMonths(-1 * (int)txConcessao.IND_MESES_DEFAZAGEM);
                    else
                        w_dt_ind = dtCredito;

                    w_dt_ind = new DateTime(w_dt_ind.Year, w_dt_ind.Month, w_dt_ind.UltimoDiaDoMes().Day);

                    var indice = new IndiceProxy().BuscarPorCodigo(modalidade.IND_CORR_VL_SOLIC);

                    if (indice == null)
                    {
                        throw new Exception("Não localizou o índice para a modalidade");
                    }
                    else
                    {
                        if (txConcessao.TIPO_IND == "V")
                            w_calc =
                                (decimal)
                                Math.Pow(
                                    (double)(((txConcessao.TX_JUROS.Value / 100) + 1) * (1 + ((indice.ObtemVariacaoEm(w_dt_ind)) / 100))),
                                    (double)1 / w_num_dias);
                        else
                            w_calc =
                                (decimal)
                                Math.Pow((double)(((txConcessao.TX_JUROS.Value / 100) + 1) * (1 + ((indice.ObtemVariacaoEm(w_dt_ind)) / 100))),
                                         (double)1 / w_num_dias);
                    }

                    w_fator = (decimal)Math.Pow((double)w_calc, w_dif_dias.Days);

                    w_vl_corrigido = (ValorSolicitado * (w_fator - 1)).Arredonda(2);
                }
            }



            return w_vl_corrigido;
        }

        public decimal CalculaValorIof(NaturezaEntidade natureza,
            TaxaEncargoPlanoEntidade taxaEncargo,
            DateTime dataCredito,
            decimal valorSolicitado,
            decimal valorCorrigido,
            decimal taxaJuros,
            int prazo,
            decimal mesesDeCarencia)
        {
            int wj, w_mes, w_ano, w_dia, w_num_dias, w_prazo;
            decimal w_saldo_atual, w_vl_principal, w_vl_iof, w_carencia, w_valor_iof;
            DateTime w_data_prest;

            w_saldo_atual = 0;
            w_vl_principal = 0;
            w_vl_iof = 0;
            w_num_dias = 0;
            w_carencia = 0;

            if (taxaEncargo.TP_COBRANCA_IOF != "C") //nao calcular na concessao, retorna zero
            {
                return 0;
            }

            if (taxaJuros == 0) //nao tem tx juros, retorna zero
            {
                return 0;
            }

            var carenciaProxy = new CarenciasDisponiveisProxy();
            var carencia = carenciaProxy.BuscarPorNatureza(natureza.CD_NATUR).FirstOrDefault(x => x.MES == mesesDeCarencia);

            if (natureza.CONSIDERAR_CARENCIA_CONCESSAO == DMN_SN.SIM)
            {
                if (carencia.MES > 0)
                    w_carencia = carencia.MES;
            }
            else
            {
                if (natureza.MES_CALC_PREST > 1)
                    w_carencia = natureza.MES_CALC_PREST;
            }

            w_saldo_atual = valorSolicitado + valorCorrigido;
            w_vl_principal = (valorSolicitado / prazo).Arredonda(2);
            w_prazo = prazo;
            w_mes = dataCredito.Month;
            w_ano = dataCredito.Year;


            //Ajuste  Miguel 04/02/2010
            //Quando a solicitacao acontecer apos o dia do vencimento do mes que estamos(data de solicitacao)
            //, o IOF deverá ser calculado a partir do mes seguinte ao próximo
            if ((dataCredito.Day > natureza.DIA_VENC_PREST) && (dataCredito.Month == DateTime.Now.Month))
            {
                w_carencia += 1;
            }

            //w_carencia += mesesDeCarencia;

            for (wj = 1; wj <= prazo; wj++)
            {
                if (wj == 1)
                    w_mes = w_mes + (int)natureza.MES_CALC_PREST + (int)w_carencia;
                else
                    w_mes++;

                if (w_mes > 12)
                {
                    w_mes = w_mes - 12;
                    w_ano++;
                }

                if ((natureza.DIA_VENC_PREST == 99) ||
                    (natureza.DIA_VENC_PREST == 0))
                {
                    w_dia = (new DateTime(w_ano, w_mes, 1)).UltimoDiaDoMes().Day;
                }
                else
                {
                    w_dia = (int)natureza.DIA_VENC_PREST;
                    if ((w_dia > 28) && (w_mes == 2))
                        w_dia = (new DateTime(w_ano, w_mes, 1).UltimoDiaDoMes().Day);
                    // Dias_Mes(EncodeDate(w_ano, w_mes, 1));
                }
                w_vl_principal = (decimal)((double)w_saldo_atual *
                                            (Math.Pow((double)(1 + taxaJuros / 100), (prazo - w_prazo)) *
                                             (double)(taxaJuros / 100)) /
                                            (Math.Pow((double)(1 + taxaJuros / 100), prazo) -
                                             Math.Pow((double)(1 + taxaJuros / 100), (prazo - w_prazo))));

                w_prazo = w_prazo - 1;


                w_data_prest = new DateTime(w_ano, w_mes, w_dia);
                if (w_data_prest.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (natureza.DT_VENC_FSF == "A")
                        w_data_prest = w_data_prest.AddDays(-2);

                    if (natureza.DT_VENC_FSF == "P")
                        w_data_prest = w_data_prest.AddDays(1);
                }
                else
                {
                    if (w_data_prest.DayOfWeek == DayOfWeek.Saturday)
                    {
                        if (natureza.DT_VENC_FSF == "A")
                            w_data_prest = w_data_prest.AddDays(-1);

                        if (natureza.DT_VENC_FSF == "P")
                            w_data_prest = w_data_prest.AddDays(2);
                    }
                }

                w_num_dias = (w_data_prest - dataCredito).Days;

                if (w_num_dias > 365)
                    w_num_dias = 365;

                w_saldo_atual = w_saldo_atual - w_vl_principal;
                w_vl_iof += (((taxaEncargo.TX_IOF.Value / 100) * w_num_dias) * w_vl_principal).Arredonda(6);

            }

            if (taxaEncargo.TX_IOF_FIXA > 0)
                w_valor_iof = w_vl_iof + (valorSolicitado * (taxaEncargo.TX_IOF_FIXA.Value / 100));
            else
                w_valor_iof = w_vl_iof;

            return w_valor_iof.Arredonda(2);
        }

        public decimal CalculaValorAdministracao(TaxaEncargoPlanoEntidade encargo, decimal ValorSolicitado, decimal ValorReformado, decimal Prazo)
        {
            decimal calculado = 0;

            if (encargo.TP_COBRANCA_TX == "C")
            {
                if (encargo.CONSIDERAR_RENOVACOES_ADM == DMN_SN.SIM)
                    calculado = ((ValorSolicitado - ValorReformado) * (encargo.TX_ADM.Value / 100));
                else
                    calculado = (ValorSolicitado * (encargo.TX_ADM.Value / 100));
            }

            return calculado.Arredonda(2);
        }

        public decimal CalculaValorSeguro(FuncionarioEntidade funcionario, TaxaEncargoPlanoEntidade encargo, decimal valorSolicitado, decimal somaReformados)
        {
            decimal calculado = 0;

            if (encargo.TP_COBRANCA_SEGURO == "C")
            {
                if (encargo.CONSIDERAR_RENOVACOES_SEGUROS == DMN_SN.SIM)
                {
                    //if (encargo.SEGURO_TABELADO == DMN_SN.SIM)
                    //    calculado = CalculaValorSeguroTabelado(funcionario, plano, valorSolicitado - somaReformados, prazo, dataCredito);
                    //else
                    calculado = (valorSolicitado - somaReformados) * (encargo.TX_SEGURO.Value / 100);
                }
                else
                {
                    //if (encargo.SEGURO_TABELADO == DMN_SN.SIM)
                    //    calculado = CalculaValorSeguroTabelado(funcionario, plano, valorSolicitado, prazo, dataCredito);
                    //else
                    calculado = (valorSolicitado * (encargo.TX_SEGURO.Value / 100));
                }
            }

            return calculado.Arredonda(2);
        }

        public decimal CalculaValorInadimplencia(TaxaEncargoPlanoEntidade encargo, decimal ValorSolicitado, decimal SomaReformados, decimal Prazo)
        {
            decimal calculado = 0;

            if (encargo.TP_COBRANCA_INAD == "C")
            {
                if (encargo.CONSIDERAR_RENOVACOES_INAD == DMN_SN.SIM)
                    calculado = (ValorSolicitado - SomaReformados) * (encargo.TX_INAD.Value / 100);
                else
                    calculado = (ValorSolicitado * (encargo.TX_INAD.Value / 100));
            }

            return calculado.Arredonda(2);
        }

        public decimal CalculaValorLiquido(decimal valorSolicitado, decimal valorAtualizacao, decimal valorIof,
                                           decimal valorAdministracao, decimal valorSeguro, decimal valorSeguroEspecial,
                                           decimal valorInadimplencia, decimal valorRenovacao, decimal SumReformar)
        {
            //+ valorAtualizacao
            return ((valorSolicitado - SumReformar)
                    - (Math.Round(valorIof, 2) + valorAdministracao + valorSeguro +
                       valorSeguroEspecial + valorInadimplencia + valorRenovacao)).Arredonda(2);
        }

        public decimal ObtemUmaPrestacao(decimal valorSolicitado, decimal prazo, TaxaConcessaoPlanoEntidade taxaConcessao, TaxaEncargoPlanoEntidade taxaEncargo)
        {
            if (taxaConcessao.TX_JUROS.Value == 0) return valorSolicitado;

            decimal fator = ObterFator(taxaConcessao.TX_JUROS.Value, prazo);
            return (valorSolicitado * fator).Arredonda(2);
        }

        public bool ValidarPercentualMinimo(NaturezaEntidade natureza, ContratoEntidade contrato, decimal prestacoesPagas)
        {
            bool result = true;

            if (natureza.RENOVACAO_MIN_PERC > 0)
            {
                decimal prazovezeslimitemin = ((contrato.PRAZO * (25M / 100M))).Arredonda(2);
                decimal diferenca = prazovezeslimitemin - prestacoesPagas;

                if (diferenca >= 1)
                {
                    result = false; //inválido para reforma
                }
            }
            else
            {
                return natureza.CAR_RENOVACAO < prestacoesPagas;
            }

            return result;
        }
    }
}
