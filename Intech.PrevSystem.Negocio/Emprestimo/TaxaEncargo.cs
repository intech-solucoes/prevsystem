using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;

namespace Intech.PrevSystem.Negocio.Emprestimo
{
    public class TaxaEncargo
    {
        public string CD_PLANO { get; set; }
        public decimal SEQUENCIA { get; set; }
        public string CORRIGIR_SALDO_DEV { get; set; }
        public string CORRIGE_SALDO_RENOVACAO { get; set; }
        public string CORRIGE_SALDO_QUITACAO_MANUAL { get; set; }
        public string COD_IND_JU_MORA { get; set; }
        public string CONSIDERAR_JUROS_CONC { get; set; }
        public string DIA_PRO_RATA_SALDO { get; set; }
        public string CARENCIA_DIA_UTIL { get; set; }
        public string CARENCIA_VENCIMENTO { get; set; }
        public string CORRIGIR_PREST_ATRASO { get; set; }
        public string CONSIDERAR_CORR_PREST { get; set; }
        public string CONSIDERAR_MULTA { get; set; }
        public string CONSIDERAR_IOF_COMPL_INAD { get; set; }
        public decimal? PERIODO_CARENCIA { get; set; }
        public decimal? TX_MULTA { get; set; }
        public decimal? TX_IOF { get; set; }
        public decimal? TX_IOF_FIXA { get; set; }
        public decimal? TX_JUROS_MORA { get; set; }
        public decimal? TX_ADM { get; set; }
        public decimal? TX_INAD { get; set; }
        public decimal? TX_SEGURO { get; set; }
        public DateTime DT_INIC_VIGENCIA { get; set; }
        public string COBRAR_JUROS_NA_REFORMA { get; set; }
        public DateTime? DT_TERM_VIGENCIA { get; set; }
        public string TP_COBRANCA_IOF { get; set; }
        public string TP_COBRANCA_TX { get; set; }
        public string CONSIDERAR_RENOVACOES_ADM { get; set; }
        public string TP_COBRANCA_SEGURO { get; set; }
        public string CONSIDERAR_RENOVACOES_SEGUROS { get; set; }
        public string TP_COBRANCA_INAD { get; set; }
        public string CONSIDERAR_RENOVACOES_INAD { get; set; }
        public string TIPO_CALC_ADM { get; set; }
        public string SEGURO_TABELADO { get; set; }
        public string IOF_IN1609 { get; set; }

        #region Métodos Publicos

        public static IEnumerable<TaxaEncargo> Criar(List<TaxasEncargosEntidade> dtEncargos)
        {
            foreach (var encargo in dtEncargos)
            {
                yield return Criar(encargo);
            }
        }

        public static IEnumerable<TaxaEncargo> Criar(List<TaxasEncargosPlanoEntidade> dtEncargos)
        {
            foreach (var encargo in dtEncargos)
            {
                yield return Criar(encargo);
            }
        }

        public static TaxaEncargo Criar(TaxasEncargosEntidade row)
        {
            return new TaxaEncargo
            {
                COD_IND_JU_MORA = row.COD_IND_JU_MORA,
                CONSIDERAR_JUROS_CONC = row.CONSIDERAR_JUROS_CONC,
                CORRIGE_SALDO_QUITACAO_MANUAL = row.CORRIGE_SALDO_QUITACAO_MANUAL,
                CORRIGE_SALDO_RENOVACAO = row.CORRIGE_SALDO_RENOVACAO,
                CORRIGIR_SALDO_DEV = row.CORRIGIR_SALDO_DEV,
                DIA_PRO_RATA_SALDO = row.DIA_PRO_RATA_SALDO,
                SEQUENCIA = row.SEQUENCIA,
                CARENCIA_DIA_UTIL = row.CARENCIA_DIA_UTIL,
                CARENCIA_VENCIMENTO = row.CARENCIA_VENCIMENTO,
                CONSIDERAR_CORR_PREST = row.CONSIDERAR_CORR_PREST,
                CONSIDERAR_MULTA = row.CONSIDERAR_MULTA,
                CORRIGIR_PREST_ATRASO = row.CORRIGIR_PREST_ATRASO,
                PERIODO_CARENCIA = row.PERIODO_CARENCIA,
                TX_JUROS_MORA = row.TX_JUROS_MORA,
                TX_MULTA = row.TX_MULTA,
                DT_INIC_VIGENCIA = row.DT_INIC_VIGENCIA,
                DT_TERM_VIGENCIA = row.DT_TERM_VIGENCIA,
                TP_COBRANCA_IOF = row.TP_COBRANCA_IOF,
                TX_IOF = row.TX_IOF,
                TX_IOF_FIXA = row.TX_IOF_FIXA,
                TP_COBRANCA_TX = row.TP_COBRANCA_TX,
                TP_COBRANCA_SEGURO = row.TP_COBRANCA_SEGURO,
                CONSIDERAR_RENOVACOES_ADM = row.CONSIDERAR_RENOVACOES_ADM,
                CONSIDERAR_RENOVACOES_SEGUROS = row.CONSIDERAR_RENOVACOES_SEGUROS,
                CONSIDERAR_RENOVACOES_INAD = row.CONSIDERAR_RENOVACOES_INAD,
                TP_COBRANCA_INAD = row.TP_COBRANCA_INAD,
                TX_ADM = row.TX_ADM,
                TX_INAD = row.TX_INAD,
                TX_SEGURO = row.TX_SEGURO,
                COBRAR_JUROS_NA_REFORMA = row.COBRAR_JUROS_NA_REFORMA,
                CONSIDERAR_IOF_COMPL_INAD = row.CONSIDERAR_IOF_COMPL_INAD,
                TIPO_CALC_ADM = row.TIPO_CALC_ADM,
                SEGURO_TABELADO = row.SEGURO_TABELADO,
                IOF_IN1609 = row.IOF_IN1609,
            };
        }

        public static TaxaEncargo Criar(TaxasEncargosPlanoEntidade row)
        {
            return new TaxaEncargo
            {
                CD_PLANO = row.CD_PLANO,
                COD_IND_JU_MORA = row.COD_IND_JU_MORA,
                CONSIDERAR_JUROS_CONC = row.CONSIDERAR_JUROS_CONC,
                CORRIGE_SALDO_QUITACAO_MANUAL = row.CORRIGE_SALDO_QUITACAO_MANUAL,
                CORRIGE_SALDO_RENOVACAO = row.CORRIGE_SALDO_RENOVACAO,
                CORRIGIR_SALDO_DEV = row.CORRIGIR_SALDO_DEV,
                DIA_PRO_RATA_SALDO = row.DIA_PRO_RATA_SALDO,
                SEQUENCIA = row.SEQUENCIA,
                CARENCIA_DIA_UTIL = row.CARENCIA_DIA_UTIL,
                CARENCIA_VENCIMENTO = row.CARENCIA_VENCIMENTO,
                CONSIDERAR_CORR_PREST = row.CONSIDERAR_CORR_PREST,
                CONSIDERAR_MULTA = row.CONSIDERAR_MULTA,
                CORRIGIR_PREST_ATRASO = row.CORRIGIR_PREST_ATRASO,
                PERIODO_CARENCIA = row.PERIODO_CARENCIA,
                TX_JUROS_MORA = row.TX_JUROS_MORA,
                TX_MULTA = row.TX_MULTA,
                DT_INIC_VIGENCIA = row.DT_INIC_VIGENCIA,
                DT_TERM_VIGENCIA = row.DT_TERM_VIGENCIA,
                TP_COBRANCA_IOF = row.TP_COBRANCA_IOF,
                TX_IOF = row.TX_IOF,
                TX_IOF_FIXA = row.TX_IOF_FIXA,
                TP_COBRANCA_TX = row.TP_COBRANCA_TX,
                TP_COBRANCA_SEGURO = row.TP_COBRANCA_SEGURO,
                CONSIDERAR_RENOVACOES_ADM = row.CONSIDERAR_RENOVACOES_ADM,
                CONSIDERAR_RENOVACOES_SEGUROS = row.CONSIDERAR_RENOVACOES_SEGUROS,
                CONSIDERAR_RENOVACOES_INAD = row.CONSIDERAR_RENOVACOES_INAD,
                TP_COBRANCA_INAD = row.TP_COBRANCA_INAD,
                TX_ADM = row.TX_ADM,
                TX_INAD = row.TX_INAD,
                TX_SEGURO = row.TX_SEGURO,
                COBRAR_JUROS_NA_REFORMA = row.COBRAR_JUROS_NA_REFORMA,
                CONSIDERAR_IOF_COMPL_INAD = row.CONSIDERAR_IOF_COMPL_INAD,
                TIPO_CALC_ADM = row.TIPO_CALC_ADM,
                SEGURO_TABELADO = row.SEGURO_TABELADO,
                IOF_IN1609 = row.IOF_IN1609
            };
        }

        #endregion
    }
}
