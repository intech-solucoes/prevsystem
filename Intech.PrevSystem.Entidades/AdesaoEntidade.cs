using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
    [Table("WEB_ADESAO")]
    public class AdesaoEntidade
    {
		[Key]
		public decimal OID_ADESAO { get; set; }
		public string COD_FUNDACAO { get; set; }
		public string COD_CPF { get; set; }
		public string NOM_PESSOA { get; set; }
		public DateTime DTA_NASCIMENTO { get; set; }
		public string COD_EMPRESA { get; set; }
		public string DES_EMPRESA { get; set; }
		public string COD_MATRICULA { get; set; }
		public DateTime DTA_ADMISSAO { get; set; }
		public string COD_EMAIL { get; set; }
		public string COD_CARGO { get; set; }
		public string DES_CARGO { get; set; }
		public string COD_SEXO { get; set; }
		public string DES_SEXO { get; set; }
		public string COD_NACIONALIDADE { get; set; }
		public string DES_NACIONALIDADE { get; set; }
		public string COD_NATURALIDADE { get; set; }
		public string DES_NATURALIDADE { get; set; }
		public string COD_UF_NATURALIDADE { get; set; }
		public string DES_UF_NATURALIDADE { get; set; }
		public string COD_RG { get; set; }
		public string DES_ORGAO_EXPEDIDOR { get; set; }
		public DateTime? DTA_EXPEDICAO_RG { get; set; }
		public string COD_ESTADO_CIVIL { get; set; }
		public string DES_ESTADO_CIVIL { get; set; }
		public string NOM_MAE { get; set; }
		public string NOM_PAI { get; set; }
		public string COD_CEP { get; set; }
		public string DES_END_LOGRADOURO { get; set; }
		public string DES_END_NUMERO { get; set; }
		public string DES_END_COMPLEMENTO { get; set; }
		public string DES_END_BAIRRO { get; set; }
		public string DES_END_CIDADE { get; set; }
		public string COD_END_UF { get; set; }
		public string DES_END_UF { get; set; }
		public string COD_TELEFONE_FIXO { get; set; }
		public string COD_TELEFONE_CELULAR { get; set; }
		public string COD_BANCO { get; set; }
		public string DES_BANCO { get; set; }
		public string COD_AGENCIA { get; set; }
		public string COD_DV_AGENCIA { get; set; }
		public string COD_CONTA_CORRENTE { get; set; }
		public string COD_DV_CONTA_CORRENTE { get; set; }
		public string IND_PPE { get; set; }
		public string IND_PPE_FAMILIAR { get; set; }
		public string IND_FATCA { get; set; }
		public string IND_SIT_ADESAO { get; set; }
		public DateTime DTA_CRIACAO { get; set; }
		[Write(false)] public List<AdesaoDependenteEntidade> Dependentes { get; set; }
		[Write(false)] public AdesaoContribEntidade Contrib { get; set; }
		[Write(false)] public AdesaoPlanoEntidade Plano { get; set; }
        
    }
}
