using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("CS_DADOS_PESSOAIS")]
    public class DadosPessoaisEntidade
    {
		public int COD_ENTID { get; set; }
		public string CD_NACIONALIDADE { get; set; }
		public string CD_GRAU_INSTRUCAO { get; set; }
		public string CD_ESTADO_CIVIL { get; set; }
		public string SEXO { get; set; }
		public string NATURALIDADE { get; set; }
		public string UF_NATURALIDADE { get; set; }
		public DateTime DT_NASCIMENTO { get; set; }
		public string NU_IDENT { get; set; }
		public string ORG_EMIS_IDENT { get; set; }
		public DateTime? DT_EMIS_IDENT { get; set; }
		public string NU_CTPS { get; set; }
		public string SERIE_CTPS { get; set; }
		public string UF_EMIS_CTPS { get; set; }
		public string COD_BANCO_COB { get; set; }
		public string COD_AGENC_COB { get; set; }
		public string CD_TIPO_COB { get; set; }
		public string NUM_CONTA_COB { get; set; }
		public string NOME_PAI { get; set; }
		public string NOME_MAE { get; set; }
		public string CD_PAIS { get; set; }
		public string NR_DEP_COB { get; set; }
		public decimal? QTD_DEPENDENTE { get; set; }
		public string CD_EMP_COB { get; set; }
		public string PS_DOENCA_CRONICA { get; set; }
		public string EMAIL_AUX { get; set; }
		public string FONE_CELULAR { get; set; }
		public DateTime? DT_FALECIMENTO { get; set; }
		public string ENVIAR_CARTAO { get; set; }
		public string CARTAO_ENVIADO { get; set; }
		public int? NUMERO_CARTAO { get; set; }
		public string SEGUNDA_VIA_CARTAO { get; set; }
		public string CARTAO_CANCELADO { get; set; }
		public string ALTERAR_DADOS_PORT { get; set; }
		public string CANCELAR_LIM_PORT { get; set; }
		public string SEGUNDA_VIA_SENHA { get; set; }
		public string SEGUNDA_VIA_EXTRATO { get; set; }
		public string CD_CANCELAMENTO_CARTAO { get; set; }
		public string LIBERAR_CARTAO { get; set; }
		public string INTERDICAO { get; set; }
		public string CNT_ABERT_CRED { get; set; }
		public int? COD_ENTID_CURADOR { get; set; }
		public string NOME_CONJUGE { get; set; }
		public string CPF_CONJUGE { get; set; }
		public string TEMPO_MILITAR { get; set; }
		public string END_CORREIO { get; set; }
		public string UF_EMIS_IDENT { get; set; }
		public string CD_OPERADORA { get; set; }
		public string APOSENTADO_INSS { get; set; }
		public string DIR_DOCUMENTOS { get; set; }
		public decimal? VL_MARGEM_CONSIG { get; set; }
		public string REG_ESTRANGEIRO { get; set; }
		public string PAIS_ORIGEM_PASSAPORTE { get; set; }
		public DateTime? DT_CHEGADA { get; set; }
		public string NOME_SOCIAL { get; set; }
		public string CPF_CGC { get; set; }
        
    }
}
