using System;
using System.Collections.Generic;
using System.Text;

namespace Intech.PrevSystem.Entidades.Outros.Sabesprev
{
    public class ExtratoAssistidoEntidade
    {
        public string CD_FUNDACAO { get; set; }
        public string CD_EMPRESA { get; set; }
        public string CD_PLANO { get; set; }
        public string CD_ESPECIE { get; set; }
        public string ANO_PROCESSO { get; set; }
        public decimal NUM_PROCESSO { get; set; }
        public decimal NUM_INSCRICAO { get; set; }
        public string NUM_MATRICULA { get; set; }
        public string DS_ESPECIE { get; set; }
        public string DS_PLANO { get; set; }
        public string COD_CNPB { get; set; }
        public string DS_SITUACAO { get; set; }
        public DateTime DT_INICIO_FUND { get; set; }
        public decimal SALDO_INICIAL { get; set; }
        public decimal SALDO_ATUAL_GERAL { get; set; }
        public decimal VL_PERC_RESGATE { get; set; }
        public decimal VL_PARC_RESGATE { get; set; }
        public decimal SALDO_REVERSAO_BENEFICIO { get; set; }
        public decimal NUM_TOT_PARCELAS { get; set; }
        public decimal NUM_PARCELAS_PAG { get; set; }
        public DateTime DT_REFERENCIA { get; set; }
        public decimal VALOR_REAIS { get; set; }
        public decimal VALOR_COTAS { get; set; }
        public decimal SALDO_ATUAL { get; set; }
        public decimal SALDO_ATUAL_REAIS { get; set; }
        public DateTime DT_IND { get; set; }
        public decimal VALOR_IND { get; set; }
        public decimal VALOR_IND2 { get; set; }
        public decimal CD_TIPO_RENDA { get; set; }
        public string TIPO_RENDA { get; set; }
        public decimal RENTABILIDADE { get; set; }
    }
}
