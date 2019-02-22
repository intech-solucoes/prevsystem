using Intech.Lib.Util.Date;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using Intech.PrevSystem.Negocio.Proxy;
using Intech.PrevSystem.Negocio.Sabesprev.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Negocio.Sabesprev
{
    public class ConcessaoSabesprev
    {
        public static Concessao ObtemConcessao(FuncionarioEntidade funcionario, string cdPlano, decimal cdNatur, decimal cdModal, DateTime dtCredito, DateTime dtSolicitacao, bool pensionista, decimal seqRecebedor)
        {
            var dados = new DadosPessoaisProxy().BuscarPorCodEntid(funcionario.COD_ENTID.ToString());
            string empresa = funcionario.CD_EMPRESA;
            string fundacao = funcionario.CD_FUNDACAO;

            var plano = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatriculaPlanoComSalario(fundacao, empresa, funcionario.NUM_MATRICULA, cdPlano);

            string categoria = plano.CD_CATEGORIA;

            var naturProxy = new NaturezaProxy();
            var natureza = naturProxy.BuscarPorCdNatur(cdNatur);

            var modalProxy = new ModalidadeProxy();
            var modalidade = modalProxy.BuscarPorCodigo(cdModal);

            var indicaTempoVinculacao = natureza.ID_TEMP_VINC == null ? false : natureza.ID_TEMP_VINC == "I" ? true : false;

            double tempo = 0;
            if (indicaTempoVinculacao)
            {
                tempo = DateTime.Today.Subtract(plano.DT_INSC_PLANO).TotalDays / 30;
            }
            else
            {
                if (plano.DT_VENC_CARENCIA.HasValue)
                    tempo = DateTime.Today.Subtract(plano.DT_VENC_CARENCIA.Value).TotalDays / 30;
                else
                    tempo = DateTime.Today.Subtract(plano.DT_INSC_PLANO).TotalDays / 30;
            }

            if (natureza.TEMPO_MINIMO > Convert.ToDecimal(tempo))
                throw new Exception("Tempo de vinculação do participante menor que o tempo mínimo exigido");

            var encargo = new TaxaEncargoPlanoProxy().BuscarPorFundacaoEmpresaModalidadeNaturezaPlanoDtInicioVigencia(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, modalidade.CD_MODAL, natureza.CD_NATUR, plano.CD_PLANO, DateTime.Today)
                        .Where(x => x.DT_INIC_VIGENCIA <= DateTime.Now && x.DT_TERM_VIGENCIA == null)
                        .OrderBy(x => x.DT_INIC_VIGENCIA)
                        .LastOrDefault();

            if (encargo == null) // nao possui encargos para esta natureza, retorna vazio
                return null;
            
            var taxaConcessao = new TaxaConcessaoPlanoProxy().BuscarPorFundacaoEmpresaModalidadeNaturezaPlano(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, modalidade.CD_MODAL, natureza.CD_NATUR, plano.CD_PLANO).LastOrDefault();

            if (encargo == null)
                throw new Exception("Taxas e Encargos não cadastrados para esta Modalidade/Natureza.");

            decimal origem;
            switch (categoria)
            {
                case DMN_CATEGORIA.ATIVO:
                case DMN_CATEGORIA.AUTOPATROCINIO:
                case DMN_CATEGORIA.EM_LICENCA: //Ativos, Autopatrocinados ou Em licença
                case DMN_CATEGORIA.DIFERIDO: //Assistidos ou Diferidos
                    origem = 1;
                    break;
                case DMN_CATEGORIA.ASSISTIDO:
                    origem = 4;
                    break;
                case DMN_CATEGORIA.DESLIGADO: //Desligados
                default:
                    throw new Exception("Concessão de empréstimo não permitida para usuários na situação Desligado");
            }

            //Criando o objeto para controlar a concessao
            var concessao = new Concessao();

            try
            {
                var parametros = new ParametrosProxy().Buscar();
                var margemPlanoProxy = new MargensPlanoProxy();

                var margem = margemPlanoProxy.BuscarPorFundacaoEmpresaPlanoModalNaturEmVigencia(fundacao, empresa, plano.CD_PLANO, cdModal, cdNatur, DateTime.Now);

                if (margem == null)
                    throw new Exception("Não há regra de cálculo para a Margem Consignável com os Dados Informados");

                //extraido do fabrica
                decimal txRedutoraReservaPoup = margem.TX_ATIVO_RP.HasValue ? 100 : margem.TX_ATIVO_RP.Value; ;
                decimal taxaRedutoraPrest = 0;

                if (margem.TX_ATIVO_PREST_MEDIA_SP != 0)
                    taxaRedutoraPrest = margem.TX_ATIVO_PREST_MEDIA_SP == null ? 100 : margem.TX_ATIVO_PREST_MEDIA_SP.Value;
                else
                    taxaRedutoraPrest = margem.TX_ATIVO_PREST_SP == null ? 100 : margem.TX_ATIVO_PREST_SP.Value;

                concessao.TetoMinimo = margem.TETO_MINIMO_ATIVO == null ? 0 : margem.TETO_MINIMO_ATIVO.Value; //nao tem 
                concessao.SSCA = margem.SSCA_ATIVO;
                concessao.TaxaMargemConsignavel = taxaRedutoraPrest;

                concessao.FlagDataConversaoRP = margem.DT_CONVERSAO_RP == null ? "" : margem.DT_CONVERSAO_RP;
                concessao.TipoDataConversaoRP = margem.TP_DT_CONV_RP == null ? "" : margem.TP_DT_CONV_RP;
                concessao.TipoDataConversaoRpAp = margem.TP_DT_CONV_RP_AP == null ? "" : margem.TP_DT_CONV_RP_AP;
                concessao.TipoDataConversaoRpDf = margem.TP_DT_CONV_RP_DF == null ? "" : margem.TP_DT_CONV_RP_DF;
                concessao.DataSolicitacao = dtSolicitacao;

                concessao.TaxaRedutoraReservaPoupanca = txRedutoraReservaPoup;
                decimal valorMargem = ObtemMargemConsignavel(funcionario, plano, fundacao, empresa, funcionario.NUM_INSCRICAO, funcionario.NUM_MATRICULA, seqRecebedor, dtSolicitacao, categoria, concessao);
                concessao.MargemConsignavel = valorMargem;
                concessao.MargemConsignavelCalculada = (valorMargem * (taxaRedutoraPrest / 100)).Arredonda(2);
            }
            catch (Exception ex)
            {
                throw new Exception("Não há regra de cálculo para a Margem Consignável com os Dados Informados");
            }

            var prazosDisponiveis = new PrazosDisponiveisProxy().BuscarPorNatureza(cdNatur);
            concessao.PrazoMaximo = prazosDisponiveis.Select(x => x.PRAZO).Max();
            concessao.TaxaJuros = taxaConcessao.TX_JUROS.Value;
            concessao.DataCredito = dtCredito;
            
            decimal sumContratosMarcados = 0;

            var contratosAReformar = new ContratoProxySabesprev().BuscarPorFundacaoEmpresaInscricaoSituacao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_INSCRICAO, "3").ToList();

            //contratos marcados para reforma
            foreach (var contrato in contratosAReformar)
            {
                // Verifica prestações minimas
                if(natureza.RENOVACAO_MIN_PERC > 0)
                {
                    decimal prazovezeslimitemin = (contrato.PRAZO * (natureza.RENOVACAO_MIN_PERC.Value / 100)).Arredonda(0);
                    var prestacoesPagas = contrato.Prestacoes.Count(x => x.DT_PAGTO.HasValue);
                    decimal diferenca = prazovezeslimitemin - prestacoesPagas;

                    if (diferenca >= 1)
                        throw new Exception("O participante possui um contrato que não tem a quantidade de parcelas pagas necessárias para a reforma.");
                }

                // Verifica inadimplencia
                if (contrato.Prestacoes.Any(x
                     => x.DT_VENC <= DateTime.Now
                     && !x.DT_PAGTO.HasValue
                     && (x.TIPO.ToUpper() == "P" || x.TIPO.ToUpper() == "I")
                     && (x.CD_ORIGEM_REC == 0 || x.CD_ORIGEM_REC == 50)))
                    throw new Exception("O participante possui prestação(ões) em atraso. Favor procurar a Fundação Sabesprev pelo 08000 55 1827.");

                sumContratosMarcados += contrato.SaldoDevedor.ValorReformado;
            }

            concessao.ValorContratosReformados = sumContratosMarcados;

            decimal fator = 1;
            decimal taxa = 0;

            if (encargo.TP_COBRANCA_TX == "P" && encargo.TP_COBRANCA_INAD == "P" && encargo.TP_COBRANCA_SEGURO == "P" && encargo.TIPO_CALC_ADM == "P")
                taxa = fator + ((encargo.TX_ADM.Value / 100) + (encargo.TX_SEGURO.Value / 100) + (encargo.TX_INAD.Value / 100));

            decimal margenConsignavelSemTaxas = concessao.MargemConsignavelCalculada / taxa;

            decimal limiteConcessaoMargem = ObterLimiteDeCreditoPelaMargem(concessao.MargemConsignavelCalculada, concessao.TaxaJuros, concessao.PrazoMaximo);

            //ajuste 09-04: Na sabesprev não pode passar o valor do reformado
            concessao.ValorMaximoEmprestimo = ObterValorMaximoEmprestimo(concessao.MargemConsignavelCalculada
                                                                        , concessao.TaxaJuros
                                                                        , concessao.PrazoMaximo
                                                                        , 0
                                                                        , concessao.TetoMaximo);

            List<Decimal> listaLimite = new List<Decimal>();

            if (DMN_CATEGORIA.ASSISTIDO != categoria)
            {
                concessao.ValorReservaPoupanca = ObtemSaldoReservaPoupanca(concessao, plano, empresa, funcionario.NUM_INSCRICAO);
                listaLimite.Add(concessao.ValorReservaPoupanca);
                concessao.ValorUltimoSalario = ObtemSalarioDosAtivos(plano, fundacao, empresa, funcionario.NUM_INSCRICAO);
            }
            else
            {
                concessao.ValorUltimoSalario = ObtemSalarioDosAssistidos(plano, fundacao, empresa, funcionario.NUM_INSCRICAO, cdPlano, seqRecebedor);
            }

            //3.5 vem do regulamento logo depois de alteração ser homologada havera uma alteração no prevsystem para que esse parametro grava 3.5
            switch (categoria)
            {
                case DMN_CATEGORIA.ATIVO:
                    concessao.TetoMaximo = (concessao.ValorUltimoSalario * Convert.ToDecimal(4.5));
                    listaLimite.Add(concessao.TetoMaximo);
                    //listaLimite.Add(concessao.MargemConsignavel);
                    concessao.ValorLimite = listaLimite.Min();
                    break;
                case DMN_CATEGORIA.ASSISTIDO:
                    //TODO[HIULLI] -- Alterar para verificar o parametro.
                    concessao.TetoMaximo = (concessao.ValorUltimoSalario * Convert.ToDecimal(4.5));
                    //listaLimite.Add(concessao.MargemConsignavel);
                    concessao.ValorLimite = concessao.TetoMaximo;
                    break;
                case DMN_CATEGORIA.AUTOPATROCINIO:
                    concessao.TetoMaximo = concessao.ValorUltimoSalario;
                    listaLimite.Add(concessao.TetoMaximo);
                    //listaLimite.Add(concessao.MargemConsignavel);                    
                    concessao.ValorLimite = listaLimite.Min();
                    break;
                default:
                    break;
            }

            if (concessao.ValorReservaPoupanca < concessao.TetoMaximo && categoria != DMN_CATEGORIA.ASSISTIDO && cdPlano != "0001")
            {
                if (concessao.ValorReservaPoupanca < concessao.ValorUltimoSalario)
                {
                    concessao.TetoMaximo = concessao.ValorUltimoSalario;
                    concessao.ValorLimite = concessao.ValorUltimoSalario;
                }
            }
            else
            {
                concessao.TetoMaximo = concessao.ValorLimite;
            }

            if (concessao.ValorLimite < concessao.ValorUltimoSalario && (categoria == DMN_CATEGORIA.ATIVO || categoria == DMN_CATEGORIA.EM_LICENCA))
            {
                concessao.TetoMaximo = concessao.ValorUltimoSalario;
                concessao.ValorLimite = concessao.ValorUltimoSalario;
            }

            return concessao;
        }

        private static decimal ObtemMargemConsignavel(FuncionarioEntidade funcionario, PlanoVinculadoEntidade plano, string fundacao, string empresa, string inscricao, string matricula, decimal seqRecebedorTemp, DateTime dtSolicitacao, string categoria, Concessao concessao)
        {
            switch (categoria)
            {
                case DMN_CATEGORIA.ATIVO:
                case DMN_CATEGORIA.AUTOPATROCINIO:
                case DMN_CATEGORIA.EM_LICENCA:       //Ativos, Autopatrocinados ou Em licença
                    return ObtemMediaSalario(plano, categoria, fundacao, empresa, inscricao, dtSolicitacao, concessao);
                case DMN_CATEGORIA.ASSISTIDO:
                case DMN_CATEGORIA.DIFERIDO:       //Assistidos ou Diferidos
                    return ObtemMediaSalarioAssistidos(plano, fundacao, empresa, inscricao, matricula, seqRecebedorTemp, dtSolicitacao);
                case DMN_CATEGORIA.DESLIGADO:       //Desligados
                default:
                    return 0;
            }

        }

        private static decimal ObtemMediaSalario(PlanoVinculadoEntidade planoVinculado, string categoria, string fundacao, string empresa, string inscricao, DateTime dtSolicitacao, Concessao concessao)
        {
            var cadastroRubrica = new CadastroRubricasProxy().BuscarPorFundacaoInscricaoEmpresa(fundacao, inscricao, empresa);
            decimal w_media_salario = 0;

            var rubricaMC = new RubricaProxy().BuscarPorFundacaoEmpresaMargemConsig(fundacao, empresa, DMN_SN.SIM);

            var lista = (from item in cadastroRubrica
                         where rubricaMC.Select(x => x.CD_RUBRICA).Contains(item.CD_RUBRICA)
                         select item).OrderByDescending(x => x.ANO_COMPETENCIA).ThenByDescending(x => x.MES_COMPETENCIA).Take(3);

            ObterDataSaldoEmCotas(concessao, categoria);

            DateTime inicioRecebimento = ObterDataSaldoEmCotas(concessao, categoria).UltimoDiaDoMes();
            DateTime ultimoRecebimento = inicioRecebimento;

            var sitPlano = new SitPlanoProxy().BuscarPorCdSituacao(planoVinculado.CD_SIT_PLANO);

            if (sitPlano.altera_salario_em != DMN_SN.SIM)
            {
                inicioRecebimento = ultimoRecebimento.AddMonths(-2);
                w_media_salario = lista.Where(x => new DateTime(Convert.ToInt32(x.ANO_COMPETENCIA), Convert.ToInt32(x.MES_COMPETENCIA), 01).UltimoDiaDoMes() >= inicioRecebimento)
                    .ToList()
                    .Select(x => x.VALOR_RUBRICA.Value)
                    .Sum();
            }

            var prestacoesPagas = new PrestacaoProxy().BuscarPagasPorFundacaoInscricaoPeriodo(fundacao, inscricao, inicioRecebimento.PrimeiroDiaDoMes(), ultimoRecebimento);

            //havia um else com o salario vindo da tela aqui. nao se aplica a web

            IEnumerable<PrestacaoEntidade> prest = new List<PrestacaoEntidade>();

            prest = (from prestacaoselecionada in prestacoesPagas
                     where prestacaoselecionada.CD_ORIGEM_REC == 1 ||
                           prestacaoselecionada.CD_ORIGEM_REC == 2 ||
                           prestacaoselecionada.CD_ORIGEM_REC == 4
                     select prestacaoselecionada);


            if (prest.Count() != 0)
            {
                foreach (var pr in prest)
                {
                    w_media_salario += pr.VL_RECEBIDO.Value;
                }
            }

            if (sitPlano.altera_salario_em != DMN_SN.SIM)
                w_media_salario /= 3;

            return w_media_salario;
        }

        private static decimal ObtemMediaSalarioAssistidos(PlanoVinculadoEntidade plano, string fundacao, string empresa, string inscricao, string matricula, decimal seqRecebedor, DateTime dtSolicitacao)
        {
            decimal w_media_salario = 0;

            var fichas = ObtemFichaFinancAssistido(fundacao, empresa, matricula, plano.CD_PLANO, seqRecebedor);

            //Obtem a ultima data da folha de assistido.
            DateTime dt = fichas.OrderByDescending(x => x.DT_COMPETENCIA).FirstOrDefault().DT_COMPETENCIA;

            DateTime dtUltimoRecebimento = dt.UltimoDiaDoMes();
            DateTime dtInicioRecimento = dtUltimoRecebimento.AddMonths(-2).PrimeiroDiaDoMes();

            //var cadastroRubrica = getCadastroRubrica(fundacao, inscricao, empresa);
            //var rubricaMC = getRubricas(fundacao, empresa, DMN_SN.SIM);

            var listaFichas = from item in fichas
                              where item.DT_COMPETENCIA >= dtInicioRecimento
                              select item;

            foreach (var ficha in listaFichas)
            {
                if (ficha.RUBRICA_PROV_DESC == "P")
                    w_media_salario += ficha.VALOR_MC.Value;
                else
                    w_media_salario -= ficha.VALOR_MC.Value;
            }

            var prestacoesPagas = new PrestacaoProxy().BuscarPagasPorFundacaoInscricaoPeriodo(fundacao, inscricao, dtInicioRecimento, dtUltimoRecebimento);

            //havia um else com o salario vindo da tela aqui. nao se aplica a web

            IEnumerable<PrestacaoEntidade> prest = new List<PrestacaoEntidade>();

            prest = (from prestacaoselecionada in prestacoesPagas
                     where prestacaoselecionada.CD_ORIGEM_REC == 1 ||
                           prestacaoselecionada.CD_ORIGEM_REC == 2 ||
                           prestacaoselecionada.CD_ORIGEM_REC == 4
                     select prestacaoselecionada);

            if (prest.Count() != 0)
            {
                foreach (var pr in prest)
                {
                    w_media_salario += pr.VL_PRESTACAO.Value;
                }
            }

            return w_media_salario / 3;
        }
        
        private static DateTime ObterDataSaldoEmCotas(Concessao concessao, string categoria)
        {
            switch (categoria)
            {
                case DMN_CATEGORIA.ATIVO:
                    return ObtemDataParaConversao(concessao.TipoDataConversaoRP, concessao.DataSolicitacao);
                case DMN_CATEGORIA.AUTOPATROCINIO:
                    return ObtemDataParaConversao(concessao.TipoDataConversaoRpAp, concessao.DataSolicitacao);
                case DMN_CATEGORIA.DIFERIDO:
                    return ObtemDataParaConversao(concessao.TipoDataConversaoRpDf, concessao.DataSolicitacao);
                default:
                    return DateTime.Today;
            }
        }

        private static DateTime ObtemDataParaConversao(string tipoDataConversao, DateTime dataSolicitacao)
        {
            switch (tipoDataConversao)
            {
                case "1":
                    return dataSolicitacao.AddMonths(-1);
                case "2":
                    return dataSolicitacao;
                default:
                    return dataSolicitacao.AddMonths(1);
            }
        }

        private static List<FichaFinanceiraAssistidoEntidade> ObtemFichaFinancAssistido(string fundacao, string empresa, string plano, string matricula, decimal? seqRecebedor)
        {
            //Buscar todas RUBRICAS_PREVIDENCIAL com INCID_LIQUIDO  = 'S' e INCID_MARGEM_CONSIG = 'S'
            var enRubrica = new RubricasPrevidencialProxy().BuscarIncideLiquidoMargemConsig(DMN_SN.SIM, DMN_SN.SIM);
            
            var dtFichas = new FichaFinanceiraAssistidoProxy().BuscarPorFundacaoEmpresaMatriculaPlanoRecebedor(fundacao, empresa, matricula, (int)seqRecebedor.Value, plano);

            var qry = from row in dtFichas
                      where enRubrica.Select(x => x.CD_RUBRICA).Contains(row.CD_RUBRICA)
                      select row;

            return qry.ToList();
        }

        private static decimal ObterLimiteDeCreditoPelaMargem(decimal valorParcela, decimal juros, decimal quantidadeMaximaParcelas)
        {
            decimal montante = 0;
            juros = juros / 100;

            montante = valorParcela * (decimal)((1 - Math.Pow((double)(1 / (1 + juros)), (double)quantidadeMaximaParcelas)) / (double)juros);
            montante = Math.Round(montante * 100) / 100;
            return montante.Arredonda(2);
        }
        
        private static decimal ObterValorMaximoEmprestimo(decimal margemConsignavel, decimal taxaJuros, decimal prazo, decimal somaReformados, decimal tetoMaximo)
        {
            decimal fator = ObterFator(taxaJuros, prazo);

            decimal result = (margemConsignavel / fator).Arredonda(2);

            return result < 0 ? 0 : result;
        }

        public static decimal ObterFator(decimal TaxaJuros, decimal Prazo)
        {
            //  Fator = (((1+i)^n)-1) / (((1+i)^n) * i)
            //  aonde i = taxa de juros com duas casas decimais
            //      e n = periodo da prestacao
            if (TaxaJuros == 0) return 0;

            var fator = (decimal)((Math.Pow((1 + (double)TaxaJuros / 100), (double)Prazo) * (double)TaxaJuros / 100)
                                   / (Math.Pow((1 + (double)TaxaJuros / 100), (double)Prazo) - 1));

            return fator;
        }

        private static decimal ObtemSaldoReservaPoupanca(Concessao concessao, PlanoVinculadoEntidade plano, string cdEmpresa, string numInscricao)
        {
            var fichaFinanceiraProxy = new FichaFinanceiraProxy();

            DateTime dataSaldo = ObterDataSaldoEmCotas(concessao, plano.CD_CATEGORIA);
            dataSaldo = dataSaldo.UltimoDiaDoMes();

            decimal saldoReservaPoupanca = 0;

            if (plano.CD_PLANO == "0003")
                saldoReservaPoupanca = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricaoFundo(plano.CD_FUNDACAO, cdEmpresa, plano.CD_PLANO, numInscricao, "6").ValorTotal;
            else
                saldoReservaPoupanca = fichaFinanceiraProxy.BuscarSaldoPorFundacaoEmpresaPlanoInscricao(plano.CD_FUNDACAO, cdEmpresa, plano.CD_PLANO, numInscricao).ValorTotal;

            return saldoReservaPoupanca;
        }

        private static decimal ObtemSalarioDosAtivos(PlanoVinculadoEntidade plano, string fundacao, string empresa, string inscricao)
        {
            var fichaFinanceira = new FichaFinanceiraProxy().BuscarUltimaPorFundacaoPlanoInscricao(fundacao, plano.CD_PLANO, inscricao);

            var salarioContribuicao = fichaFinanceira.First().SRC;

            //subtrair pensao alimenticia se existir
            var pensao = ObtemPensaoAlimenticia(fundacao, empresa, inscricao);

            return salarioContribuicao.Value - pensao;
        }

        //no momento de criação deste codigo o cliente nao possuia dados na tabela para testes
        private static decimal ObtemPensaoAlimenticia(string fundacao, string empresa, string matricula)
        {
            var rubAdicionalProxy = new RubricasAdicionaisProxy();
            var rubricas = rubAdicionalProxy.BuscarPorFundacaoEmpresaMatricula(fundacao, empresa, matricula).ToList();

            decimal pensao = 0;
            if (rubricas.Count > 0)
            {
                foreach (var row in rubricas)
                {
                    if (row.CD_RUBRICA == "761")
                        pensao += row.VL_RUBRICA.HasValue ? row.VL_RUBRICA.Value : 0M;
                }
            }

            return pensao;
        }

        private static decimal ObtemSalarioDosAssistidos(PlanoVinculadoEntidade plano,
                                                    string codigoFundacao,
                                                    string empresa,
                                                    string inscricao,
                                                    string matricula,
                                                    decimal? seqRecebedor)
        {
            //Se SeqRecebedor for null, é o próprio  Assistido, e temos que descobrir o SeqRecebedor dele
            if (seqRecebedor == null)
                throw new Exception("Assistido não possui SeqRecebedor ao buscar Salario Real de Contribuicao");

            var fichas = ObtemFichaFinancAssistido(codigoFundacao, empresa, plano.CD_PLANO, matricula, seqRecebedor);
            
            if (fichas.Count <= 0)
                return 0;
            else
            {
                //Obtem a ultima data da folha de assistido
                DateTime dt = fichas.OrderByDescending(x => x.DT_COMPETENCIA).FirstOrDefault().DT_COMPETENCIA;
                return fichas.Where(x => x.DT_COMPETENCIA.IgualMesAno(dt) && x.RUBRICA_PROV_DESC == "P").Sum(x => x.VALOR_MC.Value);
            }
        }
    }
}