using Intech.Lib.Util.Date;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using Intech.PrevSystem.Metrus.API.eConsigUtil;
using Intech.PrevSystem.Negocio;
using Intech.PrevSystem.Negocio.Proxy;
using srbrettle.FinancialFormulas;
using System;
using System.Linq;

namespace Intech.PrevSystem.Metrus.Negocio
{
    public class ConcessaoMetrus
    {
        public static Concessao ObtemConcessao(FuncionarioEntidade funcionario, string cdPlano, decimal cdNatur, decimal cdModal, DateTime dtCredito, DateTime dtSolicitacao)
        {
            var dados = new DadosPessoaisProxy().BuscarPorCodEntid(funcionario.COD_ENTID.ToString());
            string empresa = funcionario.CD_EMPRESA;
            string fundacao = funcionario.CD_FUNDACAO;

            var plano = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatriculaPlanoComSalario(fundacao, empresa, funcionario.NUM_MATRICULA, cdPlano, null);

            string categoria = plano.CD_CATEGORIA;

            var naturProxy = new NaturezaProxy();
            var natureza = naturProxy.BuscarPorCdNatur(cdNatur);
            
            var modalProxy = new ModalidadeProxy();
            var modalidade = modalProxy.BuscarPorCodigo(cdModal);

            var idadeParticipante = new Intervalo(DateTime.Now, dados.DT_NASCIMENTO, new CalculoAnosMesesDiasAlgoritmo2());

            if (natureza.IDADE_MINIMA > idadeParticipante.Anos)
                throw new Exception("Idade inferior à mínima exigida");

            //if (natureza.LIMITE_TIPO_CONTRIBUICAO > plano.Contribuicoes.Count + plano.quantidadeContribuicaoExecaoMetrus)
            //    throw new Exception("Tempo de Vinculação por Tipo de Contribuição do Participante: " + plano.Contribuicoes.Count + " , Inferior ao Mínimo Exigido: " + natureza.LimiteContribuicao + " Simulação Cancelada.");

            //if (natureza.ContribuicaoMinima > plano.Contribuicoes.Count + plano.quantidadeContribuicaoExecaoMetrus)
            //    throw new Exception("Tempo de Vinculação por Tipo de Contribuição do Participante: " + plano.Contribuicoes.Count + " , Inferior ao Mínimo Exigido: " + natureza.ContribuicaoMinima + " Simulação Cancelada.");

            var encargo = new TaxasEncargosProxy().BuscarPorFundacaoEmpresaModalidadeNatureza(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, modalidade.CD_MODAL, natureza.CD_NATUR)
                        .Where(x => x.DT_INIC_VIGENCIA <= DateTime.Now && x.DT_TERM_VIGENCIA == null)
                        .OrderBy(x => x.DT_INIC_VIGENCIA)
                        .LastOrDefault();

            if (encargo == null) // nao possui encargos para esta natureza, retorna vazio
                return null;

            var proxyTaxasConcessao = new TaxasConcessaoProxy();
            var taxaConcessao = proxyTaxasConcessao.BuscarPorFundacaoEmpresaSeqModalNatur(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, encargo.SEQUENCIA, modalidade.CD_MODAL, natureza.CD_NATUR).LastOrDefault();

            if (encargo == null)
            {
                throw new Exception("'Taxas e Encargos não cadastrados para esta Modalidade/Natureza.");
            }

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

            var margemProxy = new MargensProxy();
            var margCalcProxy = new MargensCalculadasProxy();

            //Criando o objeto para controlar a concessao
            var concessao = new Concessao();

            try
            {
                var parametros = new ParametrosProxy().Buscar();

                if (parametros.REGRA_MARGEM_PLANO == DMN_SIM_NAO.SIM)
                {
                    
                }
                else
                {
                    var margem = margemProxy.BuscarPorFundacaoEmpresaModalidadeNaturezaEmVigencia(fundacao, empresa, cdModal, cdNatur, DateTime.Now);

                    if (margem == null)
                        throw new Exception("Não há regra de cálculo para a Margem Consignável com os Dados Informados");

                    var valorMargemCalculada = 0M;

                    if (margem.MARGEM_BPA_EXTERNA == "E")
                    {
                        decimal numeroGrFamil = 0;

                        var margemCalDados = new MargensCalculadasProxy().BuscarPorFundacaoEmpresaOrigemMatriculaGrupo(plano.CD_FUNDACAO, empresa, origem, funcionario.NUM_MATRICULA, numeroGrFamil);

                        valorMargemCalculada = margemCalDados.VL_MARGEM ?? 0;
                    }
                    else if (margem.MARGEM_BPA_EXTERNA == "C")
                    {
                        // Regra não existia no simulador antigo
                    }
                    
                    double w_valor_base = Convert.ToDouble(plano.UltimoSalario);

                    decimal przMax = modalProxy.ObterPrazoMaximo(cdNatur);
                    decimal percTaxa = taxaConcessao.TX_JUROS.Value / 100;
                    decimal jurosPorPrazo = (decimal)Math.Pow((double)(1 + percTaxa), (double)przMax);
                    
                    decimal w_tx_assist_prest_bl = margem.TX_ASSIST_MC.Value;
                    decimal w_vl_prest = plano.UltimoSalario * (w_tx_assist_prest_bl / 100);

                    decimal w_fator_taxas = 1M;
                    DateTime dtAniversarioNatureza = modalProxy.ObterDataAniversarioNatureza(cdNatur, dtCredito);
                    decimal diferencaDias = (dtAniversarioNatureza - dtCredito).Days;
                    decimal w_fator_aplicado = Convert.ToDecimal(Math.Pow((double)(1 + percTaxa), (double)(diferencaDias / dtCredito.UltimoDiaDoMes().Day)));
                    
                    switch (categoria)
                    {
                        case DMN_CATEGORIA.ATIVO:
                            valorMargemCalculada = plano.UltimoSalario * (margem.TX_ATIVO_SP.Value / 100); // futuramente utilizar parametrização 
                            break;
                        case DMN_CATEGORIA.AUTOPATROCINIO:
                            valorMargemCalculada = plano.UltimoSalario * (margem.TX_MANTENEDOR_SP.Value / 100); // futuramente utilizar parametrização 
                            break;
                        case DMN_CATEGORIA.DIFERIDO:
                            valorMargemCalculada = plano.UltimoSalario * (margem.TX_MANTENEDOR_SP.Value / 100); // futuramente utilizar parametrização 
                            break;
                        case DMN_CATEGORIA.EM_LICENCA: //Ativos, Autopatrocinados ou Em licença
                            valorMargemCalculada = plano.UltimoSalario * (margem.TX_ASSIST_BL.Value / 100); // futuramente utilizar parametrização 
                            break;
                        case DMN_CATEGORIA.ASSISTIDO:

                            w_vl_prest = w_vl_prest / w_fator_taxas;
                            valorMargemCalculada = Convert.ToDecimal(GeneralFinanceFormulas.CalcPresentValue(percTaxa, przMax, (w_vl_prest * -1))) / w_fator_aplicado;

                            break;
                    }
                    
                    DateTime vdtSolicitacao = dtSolicitacao;
                    concessao = CriaConcessao(origem, margem, valorMargemCalculada);

                    concessao.ValorUltimoSalario = plano.UltimoSalario;
                }
            }
            catch (Exception)
            {
                throw new Exception("Não há regra de cálculo para a Margem Consignável com os Dados Informados");
            }
            
            concessao.PrazoMaximo = modalProxy.ObterPrazoMaximo(cdNatur);
            concessao.TaxaJuros = taxaConcessao.TX_JUROS.Value;
            concessao.DataCredito = dtCredito;
            concessao.DataSolicitacao = dtSolicitacao;

            decimal ValorLimiteReserva = 0;

            //Silvio 23/10/2009: Somente buscar valor de reserva de poupança quando não é assistido
            if (plano.CD_CATEGORIA != DMN_CATEGORIA.ASSISTIDO)
            {
                DateTime dataSaldo;

                //verificar parametros
                if (concessao.FlagDataConversaoRP == "1")
                    dataSaldo = concessao.DataSolicitacao.PrimeiroDiaDoMes();
                else
                    dataSaldo = concessao.DataCredito.PrimeiroDiaDoMes();
                
                if (concessao.TipoDataConversaoRP == "1")
                    dataSaldo = dataSaldo.AddMonths(-1);

                //var saldoCotas = plano.ObtemSaldoEmCotas(Mantenedora.Ambas, TipoCota.ReservaPoupanca, dataSaldo);
                //var saldoReservaPoup = plano.ObtemSaldoEmMoedaCorrente(Mantenedora.Participante, TipoCota.ReservaPoupanca, concessao.DataCredito, saldoCotas);
                var saldoReservaPoup = 0;

                concessao.ValorReservaPoupanca = saldoReservaPoup;
            }

            if (plano.CD_CATEGORIA == DMN_CATEGORIA.AUTOPATROCINIO || plano.CD_CATEGORIA == DMN_CATEGORIA.DIFERIDO)
            {
                //CAD_VALORES_RESGATESProxy proxy = new CAD_VALORES_RESGATESProxy();
                //DataSetPRS.CAD_VALORES_RESGATESDataTable dt = proxy.GetDataByFundacaoInscricaoPlano(participante.Empresa.Fundacao.Codigo, participante.Inscricao, plano.Plano.Codigo);

                //if (dt.Rows.Count > 0)
                //{
                //    DataSetPRS.CAD_VALORES_RESGATESRow row = (DataSetPRS.CAD_VALORES_RESGATESRow)dt.Rows[0];
                //    concessao.ValorReservaPoupanca = row.VL_SALDO_TRIBUTACAO;
                //    ValorLimiteReserva = row.VL_SALDO_RESGATAR;
                //}
            }

            decimal sumContratosMarcados = 0;
            decimal sumTodosContratosExistentes = 0;
            decimal somaMargemLiberada = 0;

            var contratosAReformar = new ContratoProxyMetrus().BuscarPorFundacaoEmpresaInscricaoSituacao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_INSCRICAO, "3").ToList();

            foreach (var contr in contratosAReformar)
            {
                sumContratosMarcados += contr.VL_REFORMADO.Value;
                somaMargemLiberada += contr.VL_PRESTACAO.Value;
            }

            if (contratosAReformar.Count > 0)
            {
                var contratoAReformar = new ContratoProxy().BuscarPorFundacaoAnoNumContrato(funcionario.CD_FUNDACAO, contratosAReformar[0].ANO_CONTRATO.ToString(), contratosAReformar[0].NUM_CONTRATO.ToString());

                contratoAReformar.BuscarSaldoDevedor(fundacao, empresa, dtCredito);
                sumTodosContratosExistentes += contratoAReformar.SaldoDevedor.ValorReformado;
            }

            concessao.ValorContratosReformados = sumTodosContratosExistentes;
            // concessao.MargemConsignavelCalculada += somaMargemLiberada; //  - reduzMargem); ??
            concessao.MargemConsignavelCalculada = concessao.ValorUltimoSalario * (concessao.TaxaMargemConsignavel / 100);

            //Se Categoria no plano em questao for diferente de Assistido 
            //   E reserva de poupanca seja inferior ao maximo estipulado
            //valerá como limite maximo a reserva de poupança.

            if (plano.CD_CATEGORIA == DMN_CATEGORIA.AUTOPATROCINIO)
            {
                if (cdNatur == 15)
                    concessao.TetoMaximo = concessao.ValorContratosReformados;
            }

            if (plano.CD_CATEGORIA == DMN_CATEGORIA.ASSISTIDO)
            {
                concessao.ValorLimite = concessao.TetoMaximo; //plano.UltimoSalario;
            }
            else if (plano.CD_CATEGORIA == DMN_CATEGORIA.AUTOPATROCINIO || plano.CD_CATEGORIA == DMN_CATEGORIA.DIFERIDO)
            {
                concessao.ValorLimite = concessao.ValorReservaPoupanca; //plano.UltimoSalario;
            }
            else
            {
                if (concessao.TaxaRedutoraReservaPoupanca > 0)
                    concessao.ValorLimite = ValorLimiteReserva;
                else
                    concessao.ValorLimite = concessao.ValorReservaPoupanca;

                //Regra faltante: 08/12/2009
                if (concessao.SSCA == DMN_SIM_NAO.SIM)
                    concessao.ValorLimite -= sumTodosContratosExistentes;

                concessao.ValorLimite += sumContratosMarcados;

                //verificações:
                concessao.ValorLimite = concessao.MargemConsignavel;
                //se  o limite for maior que o teto, assume o teto
                //Ajuste 09/02/2010 : O teto máximo é compartilhado por todos os contratos..
                concessao.ValorLimite = concessao.ValorLimite > (concessao.TetoMaximo - sumTodosContratosExistentes + sumContratosMarcados)
                                            ? concessao.TetoMaximo - sumTodosContratosExistentes + sumContratosMarcados
                                            : concessao.ValorLimite;

            }
            //o valor maximo solicitado é limitado pelo Teto estipulado acima (em tela, se digitado maior, realiza validação)
            concessao.ValorSolicitado = (concessao.ValorMaximoEmprestimo > concessao.ValorLimite)
                                            ? concessao.ValorLimite
                                            : concessao.ValorMaximoEmprestimo;

            //verifica se solicitado ou limite sao menores que zero. caso afirmativo jogar 0
            concessao.ValorSolicitado = concessao.ValorSolicitado < 0 ? 0 : concessao.ValorSolicitado;
            concessao.TetoMaximo = concessao.TetoMaximo < 0 ? 0 : concessao.TetoMaximo;
            concessao.ValorLimite = concessao.ValorLimite < 0 ? 0 : concessao.ValorLimite;

            if ((plano.CD_CATEGORIA != DMN_CATEGORIA.ASSISTIDO || plano.CD_CATEGORIA != DMN_CATEGORIA.DIFERIDO)
                && (concessao.ValorLimite > ValorLimiteReserva) && (ValorLimiteReserva != 0))
            {
                concessao.ValorLimite = ValorLimiteReserva;
            }

            if (concessao.ValorLimite > concessao.TetoMaximo)
            {
                concessao.ValorLimite = concessao.TetoMaximo;
            }


            if (plano.CD_CATEGORIA != DMN_CATEGORIA.ASSISTIDO && ValorLimiteReserva != 0)
            {
                if (concessao.MargemConsignavel > ValorLimiteReserva)
                {
                    concessao.MargemConsignavel = ValorLimiteReserva;
                }
            }
            if (concessao.MargemConsignavel > concessao.TetoMaximo)
            {
                concessao.MargemConsignavel = concessao.TetoMaximo;
            }

            var usarMargemEconsig = true; // Convert.ToBoolean(ConfigurationManager.AppSettings["UtilizarEConsig"]);

            if (usarMargemEconsig && plano.CD_CATEGORIA == DMN_CATEGORIA.ATIVO && empresa == "0001")
            {
                concessao.DadosEConsig = new UtilEConsig().ObtemMargemConsignavelAsync(funcionario.NUM_MATRICULA, dados.CPF_CGC).Result;
                concessao.DadosEConsig.ValorMargemLivre = Math.Min(concessao.DadosEConsig.ValorMargemLivre, concessao.MargemConsignavelCalculada);
            }
            else
            {
                concessao.DadosEConsig = new DadosEConsig();
                concessao.DadosEConsig.ValorMargemLivre = concessao.MargemConsignavelCalculada;
            }

            return concessao;
        }

        public static Concessao CriaConcessao(decimal origem, MargensEntidade margem, decimal valorMargemCalculada)
        {
            Concessao c = new Concessao();
            decimal taxaRedutoraPrest;
            decimal txRedutoraReservaPoup = 100;


            if (origem == 1) //ativo, patrocinado
            {
                c.TetoMaximo = margem.TETO_MAXIMO_ATIVO == null ? 9999999 : margem.TETO_MAXIMO_ATIVO.Value;
                c.TetoMinimo = margem.TETO_MINIMO_ATIVO == null ? 0 : margem.TETO_MINIMO_ATIVO.Value;
                c.SSCA = margem.SSCA_ATIVO == null ? "" : margem.SSCA_ATIVO;
                taxaRedutoraPrest = margem.TX_ATIVO_PREST_SP == null ? 100 : margem.TX_ATIVO_PREST_SP.Value;
                txRedutoraReservaPoup = margem.TX_ATIVO_RP == null ? 100 : margem.TX_ATIVO_RP.Value;
            }
            else //assistido
            {
                c.TetoMaximo = margem.TETO_MAXIMO_ASSIST == null ? 9999999 : margem.TETO_MAXIMO_ASSIST.Value;
                c.TetoMinimo = margem.TETO_MINIMO_ASSISTIDO == null ? 0 : margem.TETO_MINIMO_ASSISTIDO.Value;
                c.SSCA = margem.SSCA_ASSIST == null ? "" : margem.SSCA_ASSIST;
                taxaRedutoraPrest = margem.TX_ASSIST_MC == null ? 100 : margem.TX_ASSIST_MC.Value;
            }

            //silvio 10/12: parametro zerado nao permitindo emprestimo
            taxaRedutoraPrest = taxaRedutoraPrest == 0 ? 100 : taxaRedutoraPrest;

            c.TaxaMargemConsignavel = taxaRedutoraPrest;
            c.MargemConsignavel = valorMargemCalculada;

            c.MargemConsignavelCalculada = valorMargemCalculada * (taxaRedutoraPrest / 100);
            c.FlagDataConversaoRP = margem.DT_CONVERSAO_RP == null ? "" : margem.DT_CONVERSAO_RP;
            c.TipoDataConversaoRP = margem.TP_DT_CONV_RP == null ? "" : margem.TP_DT_CONV_RP;
            c.TaxaRedutoraReservaPoupanca = txRedutoraReservaPoup;

            return c;
        }
    }
}
