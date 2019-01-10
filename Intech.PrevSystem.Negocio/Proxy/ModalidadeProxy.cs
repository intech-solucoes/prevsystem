using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
//using srbrettle.FinancialFormulas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class ModalidadeProxy : ModalidadeDAO
    {
        public int ObtemTempoContribuicao(int tempoContribuicaoParticipante)
        {
            if (tempoContribuicaoParticipante < 12)
                return tempoContribuicaoParticipante;

            else if (tempoContribuicaoParticipante >= 12 && tempoContribuicaoParticipante < 24)
                return 12;

            else if (tempoContribuicaoParticipante >= 24 && tempoContribuicaoParticipante < 36)
                return 24;

            else if (tempoContribuicaoParticipante >= 36 && tempoContribuicaoParticipante < 48)
                return 36;

            else if (tempoContribuicaoParticipante >= 48 && tempoContribuicaoParticipante < 60)
                return 48;

            else
                return 60;
        }

        public decimal CalcularMargem(PlanoVinculadoEntidade plano, string cdEmpresa, decimal cdModal, decimal cdNatur, DateTime dtCredito, string matricula, decimal origem, MargensEntidade margem, TaxasEncargosEntidade encargo, TaxasConcessaoEntidade taxaConcessao)
        {
            var valorMargemCalculada = 0M;

            var parametros = new ParametrosProxy().Buscar();

            if (parametros.REGRA_MARGEM_PLANO == DMN_SIM_NAO.SIM)
            {
                //TODO: Regra pelo plano
            }
            else
            {

                if (margem.MARGEM_BPA_EXTERNA == "E")
                {
                    decimal numeroGrFamil = 0;

                    var margemCalDados = new MargensCalculadasProxy()
                        .BuscarPorFundacaoEmpresaOrigemMatriculaGrupo(plano.CD_FUNDACAO, cdEmpresa, origem, matricula, numeroGrFamil);

                    valorMargemCalculada = margemCalDados.VL_MARGEM ?? 0;
                }
                else if (margem.MARGEM_BPA_EXTERNA == "C")
                {
                    // Regra não existia no simulador antigo
                }

                decimal przMax = ObterPrazoMaximo(cdNatur);
                decimal percTaxa = taxaConcessao.TX_JUROS.Value / 100;
                decimal jurosPorPrazo = (decimal)Math.Pow((double)(1 + percTaxa), (double)przMax);
                decimal w_tx_assist_prest_bl = margem.TX_ASSIST_MC.Value;
                decimal w_vl_prest = plano.UltimoSalario * (w_tx_assist_prest_bl / 100);
                decimal w_fator_taxas = 1;
                DateTime dtAniversarioNatureza = ObterDataAniversarioNatureza(cdNatur, dtCredito);
                decimal diferencaDias = (dtAniversarioNatureza - dtCredito).Days;
                decimal w_fator_aplicado = Convert.ToDecimal(Math.Pow((double)(1 + percTaxa), (double)(diferencaDias / dtCredito.UltimoDiaDoMes().Day)));

                switch (plano.CD_CATEGORIA)
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
                        //valorMargemCalculada = Convert.ToDecimal(GeneralFinanceFormulas.CalcPresentValue(percTaxa, przMax, w_vl_prest)) / w_fator_aplicado;

                        break;
                }
            }

            return valorMargemCalculada;
        }

        public decimal ObterPrazoMaximo(decimal cdNatur)
        {
            try
            {
                var prazoDispProxy = new PrazosDisponiveisProxy();
                var prazos = prazoDispProxy.BuscarPorNatureza(cdNatur).ToList();

                return prazos.Select(x => x.PRAZO).Max(); //prazo não é null

            }
            catch (InvalidOperationException)
            {
                throw new Exception("Natureza não possui parametrização de prazos disponíveis");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DateTime ObterDataAniversarioNatureza(decimal cdNatur, DateTime dtCredito)
        {
            var natureza = new NaturezaProxy().BuscarPorCdNatur(cdNatur);
            DateTime w_dt_aux;
            int w_mes = 0;
            int w_ano = 0;

            if (natureza.MES_CRED_CIVIL == DMN_SIM_NAO.NAO)
            {
                w_mes = dtCredito.Month;
                w_ano = dtCredito.Year;

                if ((natureza.DIA_VENC_PREST == 99) || (natureza.DIA_VENC_PREST == 0))
                    w_dt_aux = new DateTime(w_ano, w_mes, dtCredito.UltimoDiaDoMes().Day);
                else
                    w_dt_aux = new DateTime(w_ano, w_mes, (int)natureza.DIA_VENC_PREST);

                if (w_dt_aux < dtCredito)
                    w_dt_aux = w_dt_aux.AddMonths(1);
            }
            else
            {
                w_dt_aux = new DateTime(dtCredito.Year, dtCredito.Month, dtCredito.UltimoDiaDoMes().Day);
            }

            return w_dt_aux;
        }
    }
}
