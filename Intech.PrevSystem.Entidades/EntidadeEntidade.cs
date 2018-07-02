using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("EE_ENTIDADE")]
    public class EntidadeEntidade
    {
		public int COD_ENTID { get; set; }
		public string SIGLA_ENTID { get; set; }
		public string NOME_ENTID { get; set; }
		public string GRP_INVEST { get; set; }
		public string GRP_ADMINIST { get; set; }
		public string GRP_PREVI { get; set; }
		public string GRP_ASSIST { get; set; }
		public string BANCO { get; set; }
		public string FUNDACAO { get; set; }
		public string EMPRESA_SA { get; set; }
		public string CUSTODIANTE { get; set; }
		public string CORRETORA { get; set; }
		public string FORNECEDOR { get; set; }
		public string PREST_SERV { get; set; }
		public string PARTICIPANTE { get; set; }
		public string RECEB_BENEF { get; set; }
		public string CD_TIPO_CORRESP { get; set; }
		public string PATROCINADORA { get; set; }
		public string LOCATARIO { get; set; }
		public string COD_CUSTOD { get; set; }
		public string SEGURADORA { get; set; }
		public string COD_CETIP { get; set; }
		public string FISIC_JURID { get; set; }
		public string CPF_CGC { get; set; }
		public string ISS { get; set; }
		public string NUM_BANCO { get; set; }
		public string NUM_AGENCIA { get; set; }
		public string NUM_CONTA { get; set; }
		public string END_ENTID { get; set; }
		public string BAIRRO_ENTID { get; set; }
		public string CID_ENTID { get; set; }
		public string UF_ENTID { get; set; }
		public string CEP_ENTID { get; set; }
		public string FONE_ENTID { get; set; }
		public string FAX_ENTID { get; set; }
		public string CONTA_AUX { get; set; }
		public string OBS_ENTID { get; set; }
		public string E_MAIL { get; set; }
		public string CX_POSTAL { get; set; }
		public string NR_END_ENTID { get; set; }
		public string COMP_END_ENTID { get; set; }
		public string COD_ISIN { get; set; }
		public string TP_CONTA { get; set; }
		public string AUTONOMO { get; set; }
		public decimal? DEPENDENTE { get; set; }
		public string ISENTO_RETENCAO { get; set; }
		public string INSCRICAO_INSS { get; set; }
		public string CBO { get; set; }
		public string INSCRICAO_ISS { get; set; }
		public string OBRIG_CONTR { get; set; }
		public string EMIT_RESP { get; set; }
		public string SEXO { get; set; }
		public DateTime? DT_NASCIMENTO { get; set; }
		public string NATURALIDADE { get; set; }
		public string NACIONALIDADE { get; set; }
		public string ESTADO_CIVIL { get; set; }
		public string NOME_PAI { get; set; }
		public string NOME_MAE { get; set; }
		public string CONJUGE { get; set; }
		public string IDENTIDADE { get; set; }
		public string ORGAO_EXP { get; set; }
		public DateTime? DT_EXPEDICAO { get; set; }
		public string NATUREZA_DOC { get; set; }
		public string OCUPACAO_PROF { get; set; }
		public string NIRE { get; set; }
		public string ATIVIDADE_PRINC { get; set; }
		public string REPRES_BENEF { get; set; }
		public string GERA_DES { get; set; }
		public string CD_EXTERNO { get; set; }
		public string SIT_PAT_FINANCEIRA { get; set; }
		public string SIT_PAT_RENDIMENTOS { get; set; }
		public string PF_ENQUADRAMENTO { get; set; }
		public string RECEBE_EMAIL { get; set; }
		public string SENHA { get; set; }
		public string SENHA_ANT1 { get; set; }
		public string SENHA_ANT2 { get; set; }
		public string SENHA_ANT3 { get; set; }
		public string SENHA_ANT4 { get; set; }
		public string SENHA_ANT5 { get; set; }
		public string POLIT_EXP { get; set; }
		public string TIPO_PPE { get; set; }
		public string COD_OCORRENCIA { get; set; }
		public string COD_CATEGORIA { get; set; }
		public string NUM_CONTA_SAL { get; set; }
		public string NUM_BANCO_SAL { get; set; }
		public string NUM_AGENCIA_SAL { get; set; }
		public string AG_RISCO { get; set; }
		public string COD_IMP_PATRIM { get; set; }
		public string ATIVO { get; set; }
		public int? TP_REGIME_TRIBUTACAO { get; set; }
		public string IND_TIPO_CONTA { get; set; }
		public string E_MAIL_CONTATO { get; set; }
		public string BLOQUEADA { get; set; }
		public decimal? NUM_TENTATIVAS { get; set; }
		public DateTime? DT_EXPIRA { get; set; }
		public decimal? NUM_PROX_SENHA_ALT { get; set; }
		public string PLANO { get; set; }
		public string CONSOLIDADO { get; set; }
		public string RECEB_RESGATE { get; set; }
		public string DEBITO_AUTO { get; set; }
		public string AUTORIZA_DEB { get; set; }
		public string NUM_NIF_EFINANCEIRA { get; set; }
		public string IND_FATCA { get; set; }
		public string CD_PAIS_EFINANCEIRA { get; set; }
        
    }
}
