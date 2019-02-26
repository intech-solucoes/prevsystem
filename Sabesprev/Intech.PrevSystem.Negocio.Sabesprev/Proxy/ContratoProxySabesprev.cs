#region Usings
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Negocio.Sabesprev.Proxy
{
    public class ContratoProxySabesprev : ContratoProxy
    {
        public List<ContratoEntidade> BuscarPorFundacaoEmpresaPlanoInscricaoSituacao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string CD_SITUACAO)
        {
            var listaContratos = base.BuscarPorFundacaoPlanoInscricaoSituacao(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, CD_SITUACAO).ToList();

            listaContratos.ForEach(contrato =>
            {
                contrato = BuscarDetalhesContratos(CD_FUNDACAO, contrato);
                contrato.BuscarSaldoDevedor(CD_FUNDACAO, CD_EMPRESA, DateTime.Now);
            });

            return listaContratos;
        }
        public List<ContratoEntidade> BuscarPorFundacaoEmpresaInscricaoSituacao(string CD_FUNDACAO, string CD_EMPRESA, string NUM_INSCRICAO, string CD_SITUACAO, string DATA_QUITACAO = null)
        {
            var listaContratos = base.BuscarPorFundacaoInscricaoSituacao(CD_FUNDACAO, NUM_INSCRICAO, CD_SITUACAO).ToList();
            var dataQuitacao = DateTime.Now;

            if (DATA_QUITACAO != null)
                dataQuitacao = Convert.ToDateTime(DATA_QUITACAO);

            listaContratos.ForEach(contrato =>
            {
                contrato = BuscarDetalhesContratos(CD_FUNDACAO, contrato);
                contrato.BuscarSaldoDevedor(CD_FUNDACAO, CD_EMPRESA, dataQuitacao);
            });

            return listaContratos;
        }

        public List<ContratoEntidade> BuscarPorFundacaoEmpresaPlanoInscricaoGrupoFamiliaSituacao(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string grupoFamilia, string CD_SITUACAO)
        {
            var listaContratos = base.BuscarPorFundacaoPlanoInscricaoGrupoFamiliaSituacao(CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO, grupoFamilia, CD_SITUACAO).ToList();

            listaContratos.ForEach(contrato =>
            {
                contrato = BuscarDetalhesContratos(CD_FUNDACAO, contrato);
                contrato.BuscarSaldoDevedor(CD_FUNDACAO, CD_EMPRESA, DateTime.Now);
            });

            return listaContratos;
        }

        public ContratoEntidade BuscarPorAnoNumContrato(string CD_FUNDACAO, string CD_EMPRESA, string ANO_CONTRATO, string NUM_CONTRATO, DateTime dataQuitacao)
        {
            var contrato = base.BuscarPorFundacaoAnoNumContrato(CD_FUNDACAO, ANO_CONTRATO, NUM_CONTRATO);
            
            contrato.BuscarSaldoDevedor(CD_FUNDACAO, CD_EMPRESA, dataQuitacao);

            return contrato;
        }

        private static ContratoEntidade BuscarDetalhesContratos(string CD_FUNDACAO, ContratoEntidade contrato)
        {
            contrato.Modalidade = new ModalidadeProxy().BuscarPorCodigo(contrato.CD_MODAL);
            contrato.Prestacoes = new PrestacaoProxy().BuscarPorFundacaoContrato(CD_FUNDACAO, contrato.ANO_CONTRATO, contrato.NUM_CONTRATO).ToList();

            contrato.Prestacoes.ForEach(prestacao =>
            {
                prestacao.DES_VL_RECEBIDO = prestacao.VL_RECEBIDO != 0 ? prestacao.VL_RECEBIDO.Value.ToString("C") : string.Empty;
            });

            contrato.DES_NUM_CONTRATO = $"{contrato.NUM_CONTRATO}/{contrato.ANO_CONTRATO}";
            contrato.DES_PARCELAS = $"{contrato.Prestacoes.Count(x => x.DT_PAGTO != null)}/{contrato.PRAZO}";

            return contrato;
        }

        public string Contratar(FuncionarioEntidade funcionario, ContratoDisponivel contrato, Concessao concessao, SaldoDevedorEntidade saldoDevedor)
        {
            try
            {
                var contratosAnterioresWebProxy = new ContratosAnterioresWebProxy();
                var contratosWeb = new ContratoWebProxy();

                var num_gr_fam = 0;

                //10-buscar novo numero de contrato
                //20-inserir novo contrato na base
                //30- 22/12/2009 inserir em planos contratos
                //40-loop para cada contrato marcado para reformar:
                //41-atualizar prestacoes inadimplentes
                //42-atualizar prestacoes em aberto
                //43-atualizar o contrato a reformar
                //44-inserir contrato reformado em contratos anteriores
                //50-19/01/2011 AT 1785/2010 - Ota 

                var prxParamentros = new ParametrosProxy();
                var parametros = prxParamentros.Buscar();

                int num_contrato = 0;

                var contratosEmDeferimento = contratosWeb.BuscarQuantidadeEmDeferimento(funcionario.CD_FUNDACAO, contrato.DataCredito.Year, funcionario.NUM_INSCRICAO);

                if (contratosEmDeferimento > 0)
                    throw new Exception("Já existe um contrato em deferimento");

                num_contrato = contratosWeb.BuscarUltimoNumeroContrato(funcionario.CD_FUNDACAO, contrato.DataCredito.Year) + 1;

                string cd_forma_pagto = contrato.FormaCredito;
                var planos = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatricula(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA);
                var eeEntidade = new EntidadeProxy().BuscarPorCodEntid(funcionario.COD_ENTID.ToString());

                decimal? valorInss = 0M;
                var proxyRecebedorBeneficio = new RecebedorBeneficioProxy();
                var recebedorBeneficio = proxyRecebedorBeneficio.BuscarPorFundacaoEmpresaInscricao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_INSCRICAO);
                if (recebedorBeneficio != null)
                    valorInss = recebedorBeneficio.VAL_INSS_LIQ;

                contratosWeb.InserirContratoWeb(
                    CD_FUNDACAO: funcionario.CD_FUNDACAO,                       //CD_FUNDACAO
                    ANO_CONTRATO: contrato.DataCredito.Year,					//ANO_CONTRATO
                    NUM_CONTRATO: num_contrato,												//NUM_CONTRATO
                    CD_MODAL: contrato.Modalidade.CD_MODAL,			//CD_MODAL
                    CD_NATUR: contrato.Natureza.CD_NATUR,			//CD_NATUR
                    CD_SITUACAO: 0,															//CD_SITUACAO
                    CD_MOTIVO_QUIT: null,														//CD_MOTIVO_QUIT
                    NUM_INSCRICAO: funcionario.NUM_INSCRICAO,										//NUM_INSCRICAO
                    NUM_SEQ_GR_FAMIL: num_gr_fam,													//NUM_SEQ_GR_FAMIL
                    SEQ_RUBRICA: 1,															//SEQ_RUBRICA
                    PRAZO: contrato.Prazo,						//PRAZO
                    DT_SOLICITACAO: DateTime.Now,						//DT_SOLICITACAO
                    DT_CREDITO: contrato.DataCredito,				//DT_CREDITO
                    DT_CREDITO_AUX: contrato.DataCredito,				//DT_CREDITO_AUX
                    DT_QUITACAO: null,														//DT_QUITACAO
                    DT_REF_QUITACAO: null,														//DT_REF_QUITACAO
                    VL_SOLICITADO: contrato.ValorSolicitado,			//VL_SOLICITADO
                    VL_LIQUIDO: contrato.ValorLiquido,				//VL_LIQUIDO
                    VL_TX_ADM: contrato.ValorTaxaAdministracao,	//VL_TX_ADM
                    VL_TX_SEGURO: 0,			                                                //VL_TX_SEGURO Cravado valor a pedido de w_Paulo
                    VL_TX_INAD: contrato.ValorTaxaInadimplencia,	//VL_TX_INAD
                    VL_TX_RENOVACAO: contrato.ValorTaxaRenovacao,		//VL_TX_RENOVACAO
                    VL_IOF: contrato.ValorIOF,					//VL_IOF
                    VL_CORRIGIDO: contrato.ValorAtualizacao,			//VL_CORRIGIDO
                    VL_ANTECIPADO: 0,															//VL_ANTECIPADO
                    VL_PRESTACAO: contrato.ValorPrestacao,			//VL_PRESTACAO                      
                    VL_LIMITE: concessao.ValorLimite,					        //VL_LIMITE
                    VL_BASE_CALC: concessao.MargemConsignavel, 			        //VL_BASE_CALC
                    VL_PERC_CALC: concessao.TaxaMargemConsignavel,      			//VL_PERC_CALC
                    VL_MARGEM_CONSIG: concessao.MargemConsignavelCalculada,			//VL_MARGEM_CONSIG
                    VL_REMUNERACAO: planos.First().UltimoSalario,		//VL_REMUNERACAO
                    VL_DESCONTO_AUT: 0,															//VL_DESCONTO_AUT
                    VL_PRINC_QUITACAO: 0,															//VL_PRINC_QUITACAO
                    VL_JUROS_QUITACAO: 0,															//VL_JUROS_QUITACAO
                    VL_PREST_ATRASO: 0,															//VL_PREST_ATRASO
                    VL_JUROS_PREST_ATRASO: 0,															//VL_JUROS_PREST_ATRASO
                    VL_JUROS_MORA_PREST: 0,															//VL_JUROS_MORA_PREST
                    VL_MULTA_PREST: 0,															//VL_MULTA_PREST
                    TX_JUROS: contrato.TaxaJuros,					//TX_JUROS
                    TX_APLICADA: 0,  														//TX_APLICADA
                    CD_REPRESENTANTE: null,														//CD_REPRESENTANTE
                    GEROU_CREDITO: "N", 														//GEROU_CREDITO
                    VL_REFORMADO: contrato.ValorReformado,			//VL_REFORMADO
                    VL_JUROS_PREST_MES: 0,															//VL_JUROS_PREST_MES
                    VL_DESCONTO_QUITACAO: 0,															//VL_DESCONTO_QUITACAO
                    VL_DEBITOS: 0,							//VL_DEBITOS
                    VL_PREST_ATRASO_CONCESSAO: 0,															//VL_PREST_ATRASO_CONCESSAO
                    VL_PREST_MES_CONCESSAO: 0,															//VL_PREST_MES_CONCESSAO
                    VL_PRINC_PREST_ATRASO: 0,															//VL_PRINC_PREST_ATRASO
                    VL_CORR_PREST_ATRASO: 0,															//VL_CORR_PREST_ATRASO
                    OBSERVACAO: "CONCESSÃO WEB",											//OBSERVACAO
                    VL_RESIDUO_AMORTIZACAO: 0,															//VL_RESIDUO_AMORTIZACAO
                    CD_SIT_FUNDACAO: "1",														//CD_SIT_FUNDACAO
                    VL_TX_INVALIDEZ: 0,															//VL_TX_INVALIDEZ
                    COD_CONVENIO: null,														//COD_CONVENIO
                    CD_FORMA_PAGTO: cd_forma_pagto ?? "1",										//CD_FORMA_PAGTO
                    VL_RESERVA_POUPANCA: concessao.ValorReservaPoupanca,				//VL_RESERVA_POUPANCA
                    DT_PREST_ATUALIZADA: null,														//DT_PREST_ATUALIZADA
                    VL_CORRECAO_SALDO_QUITACAO: 0,   														//VL_CORRECAO_SALDO_QUITACAO
                    NUM_BANCO: eeEntidade.NUM_BANCO,                            				//NUM_BANCO
                    NUM_AGENCIA: eeEntidade.NUM_AGENCIA,                          				//NUM_AGENCIA
                    NUM_CONTA: eeEntidade.NUM_CONTA,                    				//NUM_CONTA
                    CD_PLANO: contrato.CodigoPlano,  				//CD_PLANO
                    CARENCIA: contrato.Carencia,     				//CARENCIA
                    IP_ORIGEM: " ",                                      				//IP_ORIGEM
                    VL_INSS: valorInss.Value,									//VL_INSS
                    CONTRATO_MIGRADO: "N",                                                        //CONTRATO_MIGRADO
                    VL_MARGEN_LIVRE: concessao.MargemConsignavelCalculada, 					            //VL_MARGEN_LIVRE
                    BLOQUEIO_COBRANCA: "N",                                                        //BLOQUEIO_COBRANCA
                    ADE_NUMERO: null,				//ADE_NUMERO
                    VALOR_ECONSIG_ANT: null, //VALOR_ECONSIG_ANT
                    ALT_DADOS_BANCARIO: ""                                       //ALT_DADOS_BANCARIO);
                );

                //if (participante.valorOutrosDebitos > 0)
                //{
                //    var prxOtrosDebitos = new CE_OUTROS_DEBITOS_WEBProxy();
                //    prxOtrosDebitos.InsertDebitoWeb(funcionario.CD_FUNDACAO
                //        , contrato.DataCredito.Year
                //        , num_contrato
                //        , contrato.CodigoPlano
                //        , participante.valorOutrosDebitos
                //        , 0 //juros
                //        , participante.valorOutrosDebitos // Valor debito
                //        , "Debito de saúde da metrus"
                //        , 1);

                //}

                int i = 1;

                var contratosAReformar = new ContratoProxySabesprev().BuscarPorFundacaoEmpresaInscricaoSituacao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_INSCRICAO, "3").ToList();

                foreach (var contratoAReformar in contratosAReformar)
                {
                    var prestacoes = new PrestacaoProxy().BuscarPorFundacaoContrato(funcionario.CD_FUNDACAO, contratoAReformar.ANO_CONTRATO, contratoAReformar.NUM_CONTRATO);

                    var prest = prestacoes
                                     .Where(x => x.TIPO != "Z"
                                        && (x.DT_PAGTO <= contrato.DataCredito || x.DT_VENC <= contrato.DataCredito)
                                        && x.SEQ_PREST < 1000)
                                    .OrderBy(x => x.SEQ_PREST)
                                    .LastOrDefault();
                    i++;
                    contratosAnterioresWebProxy.InserirContratosAnteriores(
                        CD_FUNDACAO: funcionario.CD_FUNDACAO, //CD_FUNDACAO
                        ANO_CONTRATO: contratoAReformar.ANO_CONTRATO, //ANO_CONTRATO
                        NUM_CONTRATO: contratoAReformar.NUM_CONTRATO,//NUM_CONTRATO
                        SEQUENCIA: i,//SEQUENCIA 
                        ANO_CONTRATO_ANT: contrato.Ano,//ANO_CONTRATO_ANT
                        NUM_CONTRATO_ANT: (int)contrato.Numero,//NUM_CONTRATO_ANT, 
                        VL_PRINC_QUITACAO: prest.VL_PRINCIPAL,//VL_PRINC_QUITACAO,
                        VL_JUROS_QUITACAO: saldoDevedor.ValorJurosQuitacao,//VL_JUROS_QUITACAO, 
                        VL_PREST_ATRASO: saldoDevedor.ValorPrestAtraso,//VL_PREST_ATRASO, 
                        VL_JUROS_PREST_ATRASO: saldoDevedor.ValorJurosPrestAtraso,//VL_JUROS_PREST_ATRASO,
                        VL_JUROS_MORA_PREST: saldoDevedor.ValorJurosMoraPrest,//VL_JUROS_MORA_PREST,                                                                                      
                        VL_MULTA_PREST: saldoDevedor.ValorMultaPrest,//VL_MULTA_PREST, 
                        VL_REFORMADO: saldoDevedor.ValorReformado,//VL_REFORMADO,
                        VL_JUROS_PREST_MES: saldoDevedor.ValorJurosPrestMes,//VL_JUROS_PREST_MES, 
                        VL_PREST_MES: saldoDevedor.ValorPrestMes,//VL_PREST_MES, 
                        VL_PRINC_PREST_ATRASO: saldoDevedor.ValorPrincPrestAtraso,//VL_PRINC_PREST_ATRASO, 
                        VL_CORR_PREST_ATRASO: saldoDevedor.ValorCorrPrestAtraso,//VL_CORR_PREST_ATRASO,
                        VL_CORRECAO_SALDO_QUITACAO: saldoDevedor.ValorCorrecaoSaldoQuitacao,//VL_CORRECAO_SALDO_QUITACAO, 
                        VL_DESCONTO_QUITACAO: saldoDevedor.ValorDescQuitacao,//VL_DESCONTO_QUITACAO, 
                        VL_PRINC_PREST_MES: saldoDevedor.ValorPrincPrestMes,    //prest.ValorPrincipal,//VL_PRINC_PREST_MES, 
                        VL_SEGURO_QUIT: saldoDevedor.ValorSeguroQuit,//VL_SEGURO_QUIT, 
                        VL_SEGURO_PRORATA: saldoDevedor.ValorSeguroProrata,//VL_SEGURO_PRORATA, 
                        VL_TX_SEGURO_QUITACAO: 0, //VL_TX_SEGURO_QUITACAO, 	
                        VL_CORR_PRINC_PREST_MES: saldoDevedor.ValorCorrPrincPrestMes,//VL_CORR_PRINC_PREST_MES, 
                        VL_CORR_JUROS_PREST_MES: saldoDevedor.ValorCorrJurosPrestMes,//VL_CORR_JUROS_PREST_MES, 
                        VL_TX_ADM_MES_QUIT: saldoDevedor.ValorTxAdmMesQuit,//VL_TX_ADM_MES_QUIT,
                        VL_ADM_PRORATA: 0,//VL_ADM_PRORATA, 
                        VL_IOF_COMPL_QUIT: saldoDevedor.ValorIOFcompl //VL_IOF_COMPL_QUIT);
                    );

                    //existeReforma = true;
                }

                //if (gravarLog)
                //{
                //    var prxLog = new LOG_EMPRESTIMO_WEBProxy();
                //    prxLog.Insert(funcionario.NUM_MATRICULA, DateTime.Now, token, terminal, (DateTime.Today.Year.ToString() + num_contrato));

                //    var prxLogArquivo = new LOG_EMPRESTIMO_WEB_ARQUIVOProxy();
                //    prxLogArquivo.Insert(DateTime.Today.Year.ToString() + num_contrato);
                //}

                return $"{DateTime.Today.Year}/{num_contrato}";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace + ex.Message);
            }
        }
    }
}
