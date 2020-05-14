using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("CS_FUNCIONARIO_NP")]
	public class FuncionarioNPEntidade
	{
		public string CD_FUNDACAO { get; set; }
		public string CD_EMPRESA { get; set; }
		public string NUM_MATRICULA { get; set; }
		public string NOME_ENTID { get; set; }
		public string CD_LOCALIDADE { get; set; }
		public string CD_LOTACAO { get; set; }
		public string CD_CARGO { get; set; }
		public string CD_FUNCAO { get; set; }
		public string CD_NIVEL_SALARIAL { get; set; }
		public DateTime? DT_NASCIMENTO { get; set; }
		public DateTime? DT_ADMISSAO { get; set; }
		public DateTime? DT_DEMISSAO { get; set; }
		public string CD_MOTIVO_DEMISSAO { get; set; }
		public string CD_SIT_EMPRESA { get; set; }
		public DateTime? DT_SITUACAO_EMPRESA { get; set; }
		public string SEXO { get; set; }
		public string CD_ESTADO_CIVIL { get; set; }
		public string CD_GRAU_INSTRUCAO { get; set; }
		public string END_ENTID { get; set; }
		public string COMP_END_ENTID { get; set; }
		public string NR_END_ENTID { get; set; }
		public string BAIRRO_ENTID { get; set; }
		public string CID_ENTID { get; set; }
		public string UF_ENTID { get; set; }
		public string CEP_ENTID { get; set; }
		public string FONE_ENTID { get; set; }
		public string FAX_ENTID { get; set; }
		public string E_MAIL { get; set; }
		public string FONE_CELULAR { get; set; }
		public string NATURALIDADE { get; set; }
		public string UF_NATURALIDADE { get; set; }
		public string CD_NACIONALIDADE { get; set; }
		public string NU_CTPS { get; set; }
		public string SERIE_CTPS { get; set; }
		public string UF_EMIS_CTPS { get; set; }
		public string CPF_CGC { get; set; }
		public string NU_IDENT { get; set; }
		public string ORG_EMIS_IDENT { get; set; }
		public string UF_EMIS_IDENT { get; set; }
		public DateTime? DT_EMIS_IDENT { get; set; }
		public string NUM_BANCO { get; set; }
		public string NUM_AGENCIA { get; set; }
		public string NUM_CONTA { get; set; }
		public string NOME_PAI { get; set; }
		public string NOME_MAE { get; set; }
		public string PIS { get; set; }
		public string CD_PAIS { get; set; }
		public string CX_POSTAL { get; set; }
		public string CD_TIPO_CORRESP { get; set; }
		public string FONE_TRAB { get; set; }
		public string FAX_TRAB { get; set; }
		public string RAMAL_TRAB { get; set; }
		public DateTime? DT_SOLICITACAO { get; set; }
	}
}
