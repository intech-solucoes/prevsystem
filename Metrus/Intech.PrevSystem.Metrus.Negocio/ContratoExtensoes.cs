#region Usings
using Intech.Lib.Util.Date;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using Intech.PrevSystem.Entidades.Extensoes;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Metrus.Negocio
{
    public static class ContratoExtensoes
    {
        public static void BuscarSaldoDevedor(this ContratoEntidade contrato, string fundacao, string empresa, DateTime p_dt_quitacao)
        {
            decimal w_saldo_dev = 0, w_juros_mes = 0, w_seguro_mes_pro_rata = 0,
                    w_prest_mes = 0, w_princ_prest_mes = 0, w_juros_prest_mes = 0, w_seguro_prest_mes = 0,
                    w_prest_atraso = 0, w_princ_atraso = 0, w_juros_atraso = 0, w_seguro_atraso = 0,
                    w_corr_saldo_quit = 0, w_corr_prest_atraso = 0, w_multa = 0, w_mora = 0,
                    w_corr_saldo = 0, w_desc_quitacao = 0, w_desc_seguro = 0, w_desc_seguro_esp = 0,
                    w_corr_prest = 0, w_tx_adm_quit = 0, w_corr_princ_prest_mes = 0, w_corr_juros_prest_mes = 0,
                    w_princ_parcial = 0, w_juros_parcial = 0, w_tx_adm_mes_quit = 0, valorIofComplementar = 0;

            if (p_dt_quitacao.Date == DateTime.Today.Date)
                p_dt_quitacao = ObterSextas(p_dt_quitacao).FirstOrDefault();

            DateTime dataPrestacao;
            decimal prazo;

            //os dados do saldo devedor estarao contidos 
            //na ultima parcela com DtPagto ou DtVenc menor que a dt_quitacao
            //Com Tipo != Z
            PrestacaoEntidade ultimaPrestacao = contrato.Prestacoes
                .Where(x => x.TIPO != "Z" && (x.DT_PAGTO <= p_dt_quitacao || x.DT_VENC <= p_dt_quitacao))
                .OrderBy(x => x.SEQ_PREST)
                .LastOrDefault();

            if (ultimaPrestacao == null)
            {
                prazo = 0;
                if (contrato.Modalidade.CORRIGIR != DMN_SIM_NAO.SIM)
                    dataPrestacao = DateTime.Today; //contrato.DataCreditoAuxiliar;
                else
                    dataPrestacao = new DateTime(p_dt_quitacao.AddMonths(-1).Year, p_dt_quitacao.AddMonths(-1).Month, p_dt_quitacao.UltimoDiaDoMes().AddMonths(-1).Day);
                
                if (contrato.Prestacoes.Count > 0)
                {
                    var prestacao = contrato.Prestacoes.First();

                    if (dataPrestacao.Day < prestacao.DT_VENC?.Day)
                        dataPrestacao.AddMonths(-1);
                }
                
                if (dataPrestacao.Month == p_dt_quitacao.Month)
                    w_saldo_dev = contrato.VL_SOLICITADO.Value;
                else
                {
                    if (contrato.Modalidade.RESULTADO_CORRE != DMN_SIM_NAO.SIM)
                        w_saldo_dev = contrato.VL_SOLICITADO.Value + contrato.VL_CORRIGIDO.Value;
                    else
                        w_saldo_dev = contrato.VL_SOLICITADO.Value;
                }

                if (contrato.Modalidade.SALDO_REFORMA == "A")
                    w_saldo_dev = w_saldo_dev + contrato.VL_REFORMADO.Value;
            }
            else
            {
                w_saldo_dev = ultimaPrestacao.VL_SALDO_ATUAL.Value;

                if (ultimaPrestacao.TIPO == "P" || ultimaPrestacao.TIPO == "I" || ultimaPrestacao.TIPO == "S")
                    dataPrestacao = ultimaPrestacao.DT_VENC == null ? DateTime.Today : ultimaPrestacao.DT_VENC.Value;
                else
                    dataPrestacao = ultimaPrestacao.DT_PAGTO == null ? DateTime.Today : ultimaPrestacao.DT_PAGTO.Value;

                prazo = ultimaPrestacao.PARCELA.Value;
            }

            MesAno maAux = new MesAno(contrato.DT_CREDITO_AUX);
            MesAno maPrest = new MesAno(p_dt_quitacao);

            if (maAux == maPrest)
            {
                if (contrato.VL_CORRIGIDO > 0)
                {
                    dataPrestacao = contrato.DT_CREDITO_AUX.UltimoDiaDoMes();
                }
                else
                {
                    dataPrestacao = contrato.DT_CREDITO_AUX;
                }
            }

            var taxaEncargo = new TaxaEncargoPlanoProxy().BuscarPorFundacaoEmpresaModalidadeNaturezaPlanoDtInicioVigencia(fundacao, empresa, contrato.CD_MODAL, contrato.CD_NATUR, contrato.CD_PLANO, DateTime.Now)
                .Where(x => x.DT_INIC_VIGENCIA <= contrato.DT_CREDITO && x.DT_TERM_VIGENCIA == null)
                .OrderBy(x => x.DT_INIC_VIGENCIA)
                .Last();

            var taxaConcessao = new TaxaConcessaoPlanoProxy().BuscarPorFundacaoEmpresaModalidadeNatureza(fundacao, empresa, contrato.CD_MODAL, contrato.CD_NATUR)
                .Where(x => x.SEQUENCIA == taxaEncargo.SEQUENCIA)
                .FirstOrDefault();

            //corrige o saldo devedor até a data de quitacao
            if (p_dt_quitacao > dataPrestacao)
            {
                w_corr_saldo = CorrigirSaldo(
                    contrato,
                    taxaEncargo,
                    taxaConcessao,
                    dataPrestacao,
                    p_dt_quitacao,
                    contrato.DT_CREDITO,
                    contrato.Modalidade.TIPO_CALC_PREST,
                    w_saldo_dev,
                    contrato.TX_JUROS.Value);
            }

            if (contrato.Modalidade.COBRAR_PA_CONCESSAO == DMN_SIM_NAO.NAO
                || contrato.Modalidade.COBRAR_PM_CONCESSAO == DMN_SIM_NAO.SIM)
            {

                //Verifica se as prestações em atraso do contrato reformado serão cobradas na reforma ou
                // na tabela de prestações em atraso.
                var prestacoes = contrato.Prestacoes
                            .Where(x => x.DT_VENC <= p_dt_quitacao
                                    && (x.DT_PAGTO == null || (x.DT_PAGTO != null && x.CD_ORIGEM_REC == 50))
                                    && (x.TIPO == "P" || x.TIPO == "I"))
                            .OrderBy(x => x.SEQ_PREST);

                valorIofComplementar = 0;
                foreach (PrestacaoEntidade prestacao in prestacoes)
                {
                    //TODO: verificar melhor forma de buscar esta informacao (parametro por fundacao?)
                    bool CobrarPrestacaoPrevisaoRecebimento = false;
                    bool CobrarPrestacaoMes = true;

                    //if ((p_sist_origem == "CE") || (p_sist_origem == "CE-PCE101"))
                    //{
                    if (prestacao.CD_ORIGEM_REC == 5)
                        if (!CobrarPrestacaoPrevisaoRecebimento) //Msg_Confirma('Deseja Cobrar a Prestação com Previsão de Recebimento?') = MrNo then
                            continue;

                    if (prestacao.CD_ORIGEM_REC == 0)
                        if (!CobrarPrestacaoMes)                 //Msg_Confirma('Deseja Cobrar a Prestação do Mês?') = MrNo then
                            continue;                           //Obs: Codigo original possuia outra mensagem, que nao possuia utilidade e nao foi traduzida p/ c#
                    //}


                    if (prestacao.DT_PAGTO == null)
                    {
                        MesAno maVenc = new MesAno((DateTime)prestacao.DT_VENC);
                        MesAno maQuit = new MesAno(p_dt_quitacao);

                        //prestação inadimplente com recebimento parcial
                        if (prestacao.CD_ORIGEM_REC == 24)
                        {
                            var prestParcial = new PrestacaoParcialProxy().BuscarPorFundacaoAnoNumeroParcela(fundacao, contrato.ANO_CONTRATO, contrato.NUM_CONTRATO, prestacao.PARCELA.Value).ToList();

                            decimal sumJuros = prestParcial.Sum(x => x.VL_JUROS.Value);
                            decimal sumPrincipal = prestParcial.Sum(x => x.VL_PRINCIPAL.Value);

                        }

                        if (maVenc == maQuit)
                        {
                            if (contrato.Modalidade.COBRAR_PM_CONCESSAO == DMN_SIM_NAO.SIM
                                || contrato.Modalidade.TIPO_CALC_PREST == "013")
                            {
                                //prestação do mês
                                w_prest_mes = w_prest_mes + prestacao.VL_PRESTACAO.Value - w_princ_parcial - w_juros_parcial;
                                w_princ_prest_mes = w_princ_prest_mes + prestacao.VL_PRINCIPAL.Value - w_princ_parcial;
                                w_juros_prest_mes = w_juros_prest_mes + prestacao.VL_JUROS.Value - w_juros_parcial;
                                w_tx_adm_mes_quit = w_tx_adm_mes_quit + prestacao.VL_TX_ADM.Value;

                                if (contrato.Modalidade.TIPO_CALC_PREST == "015")
                                {
                                    w_corr_juros_prest_mes = 0;
                                }
                                else
                                {
                                    w_corr_princ_prest_mes = w_corr_princ_prest_mes + prestacao.VL_CORR_PRINC.Value;
                                    w_corr_juros_prest_mes = w_corr_juros_prest_mes + prestacao.VL_CORR_JUROS.Value;
                                }


                            }

                        }
                        else
                        {
                            //prestação do inadimplente
                            w_prest_atraso = w_prest_atraso + prestacao.VL_PRESTACAO.Value - w_princ_parcial - w_juros_parcial;
                            w_princ_atraso = w_princ_atraso + prestacao.VL_PRINCIPAL.Value - w_princ_parcial;
                            w_juros_atraso = w_juros_atraso + prestacao.VL_JUROS.Value - w_juros_parcial;

                            if (contrato.Modalidade.TIPO_CALC_PREST == "015")
                                w_tx_adm_quit = w_tx_adm_quit + prestacao.VL_TX_ADM.Value;
                        }

                        if (prestacao.DT_VENC < p_dt_quitacao)
                        {
                            decimal w_corr_prest_Temp = 0, w_multa_Temp = 0, w_mora_Temp = 0;

                            //calcula correcao, multa e mora
                            CorrigirMultaMora(
                                contrato,
                                taxaEncargo,
                                taxaConcessao,
                                (DateTime)prestacao.DT_VENC,
                                p_dt_quitacao,
                                contrato.DT_CREDITO,
                                contrato.Modalidade.TIPO_JUROS_MORA,
                                prestacao.VL_PRESTACAO.Value,
                                contrato.TX_JUROS.Value,
                                ref w_corr_prest_Temp,
                                ref w_multa_Temp,
                                ref w_mora_Temp);

                            w_corr_prest = w_corr_prest + w_corr_prest_Temp;
                            w_multa = w_multa + w_multa_Temp; //definicao original possui - w_multa_parcial porem valor de variavel naao é atribuido
                            w_mora = w_mora + w_mora_Temp;


                            //Só calcula o IOF Complementar se o número de dias entre o vencimento da prestação e a data de Crédito for Menor que 365
                            if (taxaEncargo.CONSIDERAR_IOF_COMPL_INAD == "S")
                                valorIofComplementar += CalculaIofComplementar(p_dt_quitacao, contrato.DT_CREDITO, Convert.ToDateTime(prestacao.DT_VENC), taxaEncargo.TX_IOF.Value, prestacao.VL_PRINCIPAL.Value).Arredonda(2);
                        }
                    }
                }
            }

            var valorReformar = (w_saldo_dev + w_corr_saldo + w_corr_prest + w_prest_atraso +
                                w_mora + w_multa + w_princ_prest_mes + w_juros_prest_mes +
                                w_juros_mes + w_seguro_prest_mes + w_seguro_mes_pro_rata) -
                                w_desc_quitacao - w_desc_seguro - w_desc_seguro_esp + valorIofComplementar;

            contrato.SaldoDevedor = new SaldoDevedorEntidade
            {
                DataQuitacao = p_dt_quitacao,
                Prazo = prazo,
                ValorPrincQuitacao = w_saldo_dev,
                ValorJurosQuitacao = w_corr_saldo,
                ValorSeguroQuit = w_seguro_prest_mes,
                ValorPrestMes = w_prest_mes,
                ValorPrincPrestMes = w_princ_prest_mes,
                ValorJurosPrestMes = w_juros_prest_mes + w_juros_mes,
                ValorSeguroProrata = w_seguro_mes_pro_rata,
                ValorPrestAtraso = w_prest_atraso,
                ValorPrincPrestAtraso = w_princ_atraso,
                ValorJurosPrestAtraso = w_juros_atraso,
                ValorTxSeguroQuitacao = w_seguro_atraso,
                ValorCorrPrestAtraso = w_corr_prest_atraso + w_corr_prest,
                ValorJurosMoraPrest = w_mora,
                ValorMultaPrest = w_multa,
                ValorCorrecaoSaldoQuitacao = w_corr_saldo_quit,
                ValorDescQuitacao = w_desc_quitacao,
                ValorDescSeguro = w_desc_seguro,
                ValorDescSeguroEsp = w_desc_seguro_esp,
                ValorTxAdmMesQuit = w_tx_adm_mes_quit,
                ValorTxAdmQuit = w_tx_adm_quit,
                ValorReformado = valorReformar,
                ValorCorrPrincPrestMes = w_corr_princ_prest_mes,
                ValorIOFcompl = valorIofComplementar
            };
        }

        private static decimal CorrigirSaldo(ContratoEntidade contrato, TaxaEncargoPlanoEntidade taxaEncargo, TaxaConcessaoPlanoEntidade taxaConcessao,
                                             DateTime dtIni, DateTime dtFim, DateTime dtVigencia, string p_tipo_calc_prest, decimal vlSaldo, decimal txJuros)
        {
            DateTime dtIndice;
            decimal dCorrecaoSaldo = 0;
            decimal vlIndice = 0;
            decimal taxaJuros = 0;
            decimal taxaCorrecao = 0;
            int diasMes = 0;

            if (taxaEncargo == null)
                return dCorrecaoSaldo;

            if (taxaEncargo.CORRIGIR_SALDO_DEV == "N")
                return dCorrecaoSaldo;

            if (taxaConcessao.COD_IND != "")
            {
                if (taxaConcessao.IND_DEFAZAGEM == DMN_SIM_NAO.SIM && taxaConcessao.IND_MESES_DEFAZAGEM > 0)
                    dtIndice = dtFim.AddMonths(-1 * (int)taxaConcessao.IND_MESES_DEFAZAGEM);
                else
                    dtIndice = dtFim;

                dtIndice = dtIndice.UltimoDiaDoMes();

                var indice = new IndiceProxy().BuscarPorCodigo(taxaConcessao.COD_IND);

                if (indice == null)
                {
                    return dCorrecaoSaldo;
                }
                else
                {
                    if (taxaConcessao.TIPO_IND == "V")
                        vlIndice = (indice.ObtemVariacaoEm(dtIndice) / 100) + 1;
                    else
                        vlIndice = (indice.ObtemValorEm(dtIndice) / 100) + 1;
                }
            }
            else
            {
                vlIndice = 1;
            }

            if (taxaEncargo.CONSIDERAR_JUROS_CONC == DMN_SIM_NAO.SIM)
                taxaJuros = (txJuros / 100) + 1;

            if ((vlIndice != 0) && (taxaJuros != 0))
                taxaCorrecao = ((((vlIndice * taxaJuros) - 1) * 100) / 100) + 1;

            if ((vlIndice == 0) && (taxaJuros != 0))
                taxaCorrecao = vlIndice;

            if ((vlIndice == 0) && (taxaJuros != 0))
                taxaCorrecao = taxaJuros;

            if (taxaEncargo.DIA_PRO_RATA_SALDO == DMN_SIM_NAO.SIM)
                diasMes = 30;
            else
                diasMes = DateTime.DaysInMonth(dtFim.Year, dtFim.Month);

            double difDias = (dtFim - dtIni).Days;
            decimal calc = (decimal)Math.Pow((double)taxaCorrecao, 1 / diasMes);
            decimal fator = (decimal)Math.Pow((double)calc, difDias);

            vlSaldo *= (fator - 1);
            dCorrecaoSaldo = vlSaldo.Arredonda(2);

            if (dCorrecaoSaldo < 0)
                dCorrecaoSaldo = 0;

            return dCorrecaoSaldo;
        }

        private static void CorrigirMultaMora(ContratoEntidade contrato, TaxaEncargoPlanoEntidade taxaEncargo, TaxaConcessaoPlanoEntidade taxaConcessao, 
            DateTime p_dt_ini, DateTime p_dt_fin, DateTime p_dt_vigencia, string p_tipo_calc_prest, decimal p_vl_prestacao, decimal p_tx_juros, ref decimal correcaoPrestacao, ref decimal multa, ref decimal mora)
        {
            decimal w_vl_ind = 0,
                    w_vl_ind_acum = 1,
                    w_tx_corr = 0,
                    w_vl_mora = 0,
                    w_vl_multa = 0,
                    w_vl_correcao = 0,
                    w_calc = 0,
                    w_fator = 0,
                    w_taxa_juros = 0,
                    w_vl_prest = 0;

            int w_dif_dias = 0, w_dias_mes = 0;
            DateTime w_dt_aux, w_dt_aux1, w_dt_ind, w_dt_inad, DtVenc, DtAtu, DataIni, DtAux;

            //rotina deve possuir um contrato e seus encargos financeiros
            if (contrato == null)
                throw new ArgumentNullException("Favor informar um contrato ativo  para o cálculo de Multa e Mora");

            if (taxaEncargo == null)
                throw new ArgumentNullException(
                    "Favor informar as taxas de encargos do contrato ativo para o calculo de Multa e Mora");

            if (taxaConcessao == null)
                throw new ArgumentNullException(
                    "Favor informar as taxas de concessao do contrato ativo para o calculo de Multa e Mora");

            w_dt_aux = p_dt_ini;
            w_dt_aux1 = w_dt_aux;

            w_vl_prest = p_vl_prestacao;

            w_dt_inad = p_dt_ini.AddDays((double)taxaEncargo.PERIODO_CARENCIA);

            if (taxaEncargo.PERIODO_CARENCIA > 0)
            {
                if (taxaEncargo.CARENCIA_DIA_UTIL == DMN_SIM_NAO.SIM)
                {
                    if (taxaEncargo.CARENCIA_VENCIMENTO == "D")
                    {
                        w_dt_inad = p_dt_ini.AddMonths(1);
                        w_dt_inad = new DateTime(w_dt_inad.Year, w_dt_inad.Month, (int)taxaEncargo.PERIODO_CARENCIA);

                        var feriados = new FeriadoProxy().Listar();

                        if (taxaEncargo.CARENCIA_DIA_UTIL == DMN_SIM_NAO.SIM)
                        {
                            for (int i = 0; i <= taxaEncargo.PERIODO_CARENCIA; i++)
                                w_dt_aux = Feriado.BuscarDiaUtil(feriados, w_dt_aux.AddDays(1), Feriado.Direcao.Posterior, null);

                            w_dt_inad = w_dt_aux;
                        }
                        else
                        {
                            w_dt_inad = p_dt_ini.AddDays(1);
                        }
                    }
                    else
                    {
                        w_dt_inad = p_dt_ini.AddDays((double)taxaEncargo.PERIODO_CARENCIA);
                    }

                }
                else
                {
                    w_dt_inad = p_dt_ini.AddDays(1);
                }

                if (w_dt_inad >= p_dt_fin)
                {
                    multa = 0;
                    mora = 0;
                    correcaoPrestacao = 0;
                    return;
                }

            }

            //Calculo exponencial
            if (p_tipo_calc_prest == "C")
            {
                //corrige prestacao para depois calcular multa e juros
                if ((taxaEncargo.CORRIGIR_PREST_ATRASO == "M") || taxaEncargo.CONSIDERAR_CORR_PREST == "A")
                    w_vl_multa = w_vl_prest * (taxaEncargo.TX_MULTA.Value / 100M);
                else
                    w_vl_multa = p_vl_prestacao * (taxaEncargo.TX_MULTA.Value / 100M);

                if (w_vl_multa < 0)
                    w_vl_multa = 0;

                if (taxaEncargo.TX_JUROS_MORA > 0)
                {
                    w_taxa_juros = (taxaEncargo.TX_JUROS_MORA.Value / 100M) + 1;

                    if (taxaEncargo.DIA_PRO_RATA_SALDO == DMN_SIM_NAO.SIM)
                        w_dias_mes = 30;
                    else
                        w_dias_mes = p_dt_fin.UltimoDiaDoMes().Day;

                    w_dif_dias = (p_dt_fin - p_dt_ini).Days;
                    w_calc = w_taxa_juros.ElevadoA(1 / w_dias_mes);
                    w_fator = w_calc.ElevadoA(w_dif_dias);

                    if (taxaEncargo.CONSIDERAR_MULTA == DMN_SIM_NAO.SIM)
                    {
                        if ((taxaEncargo.CONSIDERAR_CORR_PREST == "J") || (taxaEncargo.CONSIDERAR_CORR_PREST == "A"))
                            w_vl_mora = ((w_vl_prest + w_vl_multa) * (w_fator - 1)).Arredonda(2);
                        else
                            w_vl_mora = ((p_vl_prestacao + w_vl_multa) * (w_fator - 1)).Arredonda(2);
                    }
                    else
                    {
                        if ((taxaEncargo.CONSIDERAR_CORR_PREST == "J") || (taxaEncargo.CONSIDERAR_CORR_PREST == "A"))
                            w_vl_mora = ((w_vl_prest) * (w_fator - 1)).Arredonda(2);
                        else
                            w_vl_mora = ((p_vl_prestacao) * (w_fator - 1)).Arredonda(2);
                    }

                    if (w_vl_mora < 0)
                        w_vl_mora = 0;

                }
            }

            //Calculo linear
            if (p_tipo_calc_prest == "L")
            {
                //   {corrige a prestação para depois calcular multa e juros}
                if ((taxaEncargo.CONSIDERAR_CORR_PREST == "M") || (taxaEncargo.CONSIDERAR_CORR_PREST == "A"))
                    w_vl_multa = (w_vl_prest * (taxaEncargo.TX_MULTA.Value / 100M));
                else
                    w_vl_multa = (p_vl_prestacao * (taxaEncargo.TX_MULTA.Value / 100M));

                if (w_vl_multa < 0)
                    w_vl_multa = 0;

                if (taxaEncargo.TX_JUROS_MORA > 0)
                {
                    w_vl_ind_acum = 0;
                    w_taxa_juros = taxaEncargo.TX_JUROS_MORA.Value;
                    w_dt_aux = p_dt_ini;
                    w_dt_aux1 = w_dt_aux;

                    //Acumulando os indices
                    while (!(w_dt_aux >= p_dt_fin))
                    {
                        w_dt_aux = w_dt_aux.AddMonths(1);

                        if (w_dt_aux > p_dt_fin)
                            w_dt_aux = p_dt_fin;

                        w_dias_mes = 30;
                        w_dif_dias = (w_dt_aux - w_dt_aux1).Days;

                        if (w_dif_dias != 30)
                        {
                            w_dif_dias = 30;
                        }

                        w_fator = w_dif_dias / w_dias_mes;
                        w_vl_ind_acum += w_fator;
                        w_dt_aux1 = w_dt_aux;
                    }

                    w_fator = w_vl_ind_acum * w_taxa_juros;

                    if (taxaEncargo.CONSIDERAR_MULTA == DMN_SIM_NAO.SIM)
                    {
                        if ((taxaEncargo.CONSIDERAR_CORR_PREST == "J") || (taxaEncargo.CONSIDERAR_CORR_PREST == "A"))
                            w_vl_mora = (((w_vl_prest + w_vl_multa) * w_fator) / 100M).Arredonda(2);
                        else
                            w_vl_mora = (((p_vl_prestacao + w_vl_multa) * w_fator) / 100M).Arredonda(2);
                    }
                    else
                    {
                        if ((taxaEncargo.CONSIDERAR_CORR_PREST == "J") || (taxaEncargo.CONSIDERAR_CORR_PREST == "A"))
                        {
                            w_vl_mora = ((w_vl_prest * w_fator) / 100M).Arredonda(2);
                        }
                        else
                        {
                            w_vl_mora = ((p_vl_prestacao * w_fator) / 100M).Arredonda(2);
                        }
                    }

                    if (w_vl_mora < 0)
                        w_vl_mora = 0;
                }
            }

            if (p_tipo_calc_prest == "A")
            {
                DtAux = new DateTime(p_dt_fin.Year, p_dt_fin.Month, p_dt_fin.UltimoDiaDoMes().Day);
                DataIni = new DateTime(DtAux.Year, DtAux.Month, 1);
                DtVenc = new DateTime(p_dt_ini.Year, p_dt_ini.Month, p_dt_ini.UltimoDiaDoMes().Day);

                if ((DtVenc < DataIni) && (((p_dt_fin - DtVenc).Days) > 15))
                {
                    w_vl_multa = w_vl_multa + (w_vl_prest * (taxaEncargo.TX_MULTA.Value / 100M));

                    DtAtu = DtVenc.AddMonths(1).PrimeiroDiaDoMes();

                    while ((DtAtu.Month != DtAux.Month) || (DtAtu.Year != DtAux.Year))
                    {
                        DtAtu = new DateTime(DtAtu.Year, DtAtu.Month, DtAtu.UltimoDiaDoMes().Day);

                        w_vl_mora = w_vl_mora +
                                    ((w_vl_prest + w_vl_mora) *
                                     (1 + (taxaEncargo.TX_JUROS_MORA.Value / 100M)).ElevadoA(DtAtu.UltimoDiaDoMes().Day / 30))
                                    - (w_vl_prest + w_vl_mora);
                        DtAtu = DtAtu.AddMonths(1).PrimeiroDiaDoMes();
                    }

                    w_vl_mora = w_vl_mora +
                                ((w_vl_prest + w_vl_mora) *
                                 (1 + (taxaEncargo.TX_JUROS_MORA.Value / 100M)).ElevadoA(((p_dt_fin - DtAtu).Days + 1) / 30))
                                - (w_vl_prest + w_vl_mora);
                }
            }

            //Na Sabesprev a correção da prestação é sobre a multa e juros
            if (taxaEncargo.CORRIGIR_PREST_ATRASO == DMN_SIM_NAO.SIM)
            {
                w_vl_ind_acum = 1;
                w_dt_aux = p_dt_ini;
                w_dt_aux1 = w_dt_aux;

                //{Acumulando os indices}
                while (!(w_dt_aux >= p_dt_fin))
                {
                    w_dt_aux = w_dt_aux.AddMonths(1).UltimoDiaDoMes();
                    if (w_dt_aux > p_dt_fin)
                        w_dt_aux = p_dt_fin;

                    if ((taxaConcessao.IND_DEFAZAGEM == DMN_SIM_NAO.SIM) && (taxaConcessao.IND_MESES_DEFAZAGEM > 0))
                        w_dt_ind = w_dt_aux.AddMonths((int)-taxaConcessao.IND_MESES_DEFAZAGEM);
                    else
                        w_dt_ind = w_dt_aux;

                    w_dt_ind = w_dt_ind.UltimoDiaDoMes();

                    if (taxaEncargo.COD_IND_JU_MORA != "")
                    {
                        var indice = new IndiceProxy().BuscarPorCodigo(taxaEncargo.COD_IND_JU_MORA);

                        if (taxaConcessao.TIPO_IND == "V")
                            w_vl_ind = (indice.ObtemVariacaoEm(w_dt_ind) / 100) + 1;
                        else
                            w_vl_ind = (indice.ObtemValorEm(w_dt_ind) / 100) + 1;
                    }
                    else
                    {
                        w_vl_ind = 1;
                    }

                    w_dias_mes = 30;
                    w_dif_dias = (w_dt_aux - w_dt_aux1).Days;

                    if (w_dif_dias > 30 || (w_dt_aux.Month == 2 && w_dif_dias >= 28))
                        w_dif_dias = 30;

                    w_calc = (decimal)Math.Pow((double)w_vl_ind, ((double)1 / (double)w_dias_mes));
                    w_fator = (decimal)Math.Pow((double)w_calc, (double)w_dif_dias);

                    w_vl_ind_acum = (w_vl_ind_acum * w_fator);
                    w_dt_aux1 = w_dt_aux;
                }

                w_vl_ind = w_vl_ind_acum;

                if (w_vl_ind != 0)
                    w_tx_corr = w_vl_ind;

                //w_vl_correcao = ((w_vl_prest + w_vl_multa + w_vl_mora) * (w_tx_corr - 1)).Arredonda(2);
                w_vl_correcao = (w_vl_prest) * (w_tx_corr - 1);

                if (w_vl_correcao < 0)
                    w_vl_correcao = 0;

                w_vl_prest = w_vl_prest + w_vl_correcao;
            }

            multa = w_vl_multa.Arredonda(2);
            mora = w_vl_mora.Arredonda(2);
            correcaoPrestacao = w_vl_correcao.Arredonda(2);
        }

        private static decimal CalculaIofComplementar(DateTime dataQuitacao, DateTime dataCredido, DateTime dataVencimento, decimal taxaIof, decimal valorPrincipal)
        {
            var quantidadeDias = 0;

            if (dataQuitacao > dataVencimento)
                quantidadeDias = (Int32)dataVencimento.Subtract(dataCredido).TotalDays;

            if (quantidadeDias <= 365)
            {
                if (((Int32)dataQuitacao.Subtract(dataVencimento).TotalDays) > 365)
                    quantidadeDias = 365 - (Int32)dataVencimento.Subtract(dataCredido).TotalDays;
                else
                    quantidadeDias = (Int32)dataQuitacao.Subtract(dataCredido).TotalDays - (Int32)dataVencimento.Subtract(dataCredido).TotalDays;

                return (((taxaIof / 100) * quantidadeDias) * valorPrincipal);
            }

            return 0;
        }

        //retorna tres sextas-feiras (uteis) a partir da (data informada + 48 horas)
        public static IEnumerable<DateTime> ObterSextas(DateTime dtSolicitacao)
        {
            List<DateTime> dtCreditos = new List<DateTime>();
            List<DateTime> feriados = new FeriadoProxy().BuscarDatas().ToList();

            DateTime d = dtSolicitacao.AddHours(48);
            DateTime a = d.Date;

            // acha sexta-feira
            for (double dia = 0; dia < 15; dia++)
            {
                a = a.AddDays(1);
                if (a.DayOfWeek == DayOfWeek.Friday)
                {
                    break;
                }
            }

            int sextas = 1;
            while (sextas <= 3)
            {
                if (a.EhDiaUtil(feriados))
                {
                    sextas++;
                    dtCreditos.Add(a);
                }
                a = a.AddDays(7); // avanca uma semana
            }
            return dtCreditos;
        }
    }
}
