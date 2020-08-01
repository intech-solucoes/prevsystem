using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Intech.PrevSystem.Entidades
{
	[Table("WEB_RECAD_DADOS")]
	public class WebRecadDadosEntidade
	{
		[Key]
		public decimal OID_RECAD_DADOS { get; set; }
		public decimal OID_RECAD_PUBLICO_ALVO { get; set; }
		public DateTime DTA_SOLICITACAO { get; set; }
		public string COD_PROTOCOLO { get; set; }
		public string DES_ORIGEM { get; set; }
		public DateTime? DTA_RECUSA { get; set; }
		public string TXT_MOTIVO_RECUSA { get; set; }
		public string NOM_PESSOA { get; set; }
		public DateTime? DTA_NASCIMENTO { get; set; }
		public string COD_CPF { get; set; }
		public string COD_RG { get; set; }
		public string DES_ORGAO_EXPEDIDOR { get; set; }
		public DateTime? DTA_EXPEDICAO_RG { get; set; }
		public DateTime? DTA_ADMISSAO { get; set; }
		public string DES_NATURALIDADE { get; set; }
		public string COD_UF_NATURALIDADE { get; set; }
		public string DES_UF_NATURALIDADE { get; set; }
		public string COD_NACIONALIDADE { get; set; }
		public string DES_NACIONALIDADE { get; set; }
		public string NOM_MAE { get; set; }
		public string NOM_PAI { get; set; }
		public string COD_ESTADO_CIVIL { get; set; }
		public string DES_ESTADO_CIVIL { get; set; }
		public string NOM_CONJUGE { get; set; }
		public string COD_CPF_CONJUGE { get; set; }
		public DateTime? DTA_NASC_CONJUGE { get; set; }
		public string COD_CEP { get; set; }
		public string DES_END_LOGRADOURO { get; set; }
		public string DES_END_NUMERO { get; set; }
		public string DES_END_COMPLEMENTO { get; set; }
		public string DES_END_BAIRRO { get; set; }
		public string DES_END_CIDADE { get; set; }
		public string COD_END_UF { get; set; }
		public string DES_END_UF { get; set; }
		public string COD_PAIS { get; set; }
		public string DES_PAIS { get; set; }
		public string COD_EMAIL { get; set; }
		public string COD_TELEFONE_FIXO { get; set; }
		public string COD_TELEFONE_CELULAR { get; set; }
		public string COD_CARGO { get; set; }
		public string DES_CARGO { get; set; }
		public string COD_SEXO { get; set; }
		public string DES_SEXO { get; set; }
		public string COD_BANCO { get; set; }
		public string DES_BANCO { get; set; }
		public string COD_AGENCIA { get; set; }
		public string COD_DV_AGENCIA { get; set; }
		public string COD_CONTA_CORRENTE { get; set; }
		public string COD_DV_CONTA_CORRENTE { get; set; }
		public string COD_ESPECIE_INSS { get; set; }
		public string DES_ESPECIE_INSS { get; set; }
		public string COD_BENEF_INSS { get; set; }
		public string IND_PPE { get; set; }
		public string IND_PPE_FAMILIAR { get; set; }
		public string IND_FATCA { get; set; }
	}
}
