﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class WebRecadDadosDAO : BaseDAO<WebRecadDadosEntidade>
	{
		public virtual WebRecadDadosEntidade BuscarPorProtocolo(string COD_PROTOCOLO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebRecadDadosEntidade>("SELECT *   FROM WEB_RECAD_DADOS  WHERE COD_PROTOCOLO = @COD_PROTOCOLO", new { COD_PROTOCOLO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<WebRecadDadosEntidade>("SELECT * FROM WEB_RECAD_DADOS WHERE COD_PROTOCOLO=:COD_PROTOCOLO", new { COD_PROTOCOLO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual long Insert(decimal OID_RECAD_PUBLICO_ALVO, DateTime DTA_SOLICITACAO, string DES_ORIGEM, string COD_PROTOCOLO, DateTime DTA_RECUSA, string TXT_MOTIVO_RECUSA, string NOM_PESSOA, DateTime DTA_NASCIMENTO, string COD_CPF, string COD_RG, string DES_ORGAO_EXPEDIDOR, DateTime DTA_EXPEDICAO_RG, DateTime DTA_ADMISSAO, string DES_NATURALIDADE, string COD_UF_NATURALIDADE, string DES_UF_NATURALIDADE, string COD_NACIONALIDADE, string DES_NACIONALIDADE, string NOM_MAE, string NOM_PAI, string COD_ESTADO_CIVIL, string DES_ESTADO_CIVIL, string NOM_CONJUGE, string COD_CPF_CONJUGE, DateTime DTA_NASC_CONJUGE, string COD_CEP, string DES_END_LOGRADOURO, string DES_END_NUMERO, string DES_END_COMPLEMENTO, string DES_END_BAIRRO, string DES_END_CIDADE, string COD_END_UF, string DES_END_UF, string COD_PAIS, string DES_PAIS, string COD_EMAIL, string COD_TELEFONE_FIXO, string COD_TELEFONE_CELULAR, string COD_CARGO, string DES_CARGO, string COD_SEXO, string DES_SEXO, string COD_BANCO, string DES_BANCO, string COD_AGENCIA, string COD_DV_AGENCIA, string COD_CONTA_CORRENTE, string COD_DV_CONTA_CORRENTE, string COD_ESPECIE_INSS, string DES_ESPECIE_INSS, string COD_BENEF_INSS, string IND_PPE, string IND_PPE_FAMILIAR, string IND_FATCA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO WEB_RECAD_DADOS(  	OID_RECAD_PUBLICO_ALVO,      DTA_SOLICITACAO,      DES_ORIGEM,      COD_PROTOCOLO,      DTA_RECUSA,      TXT_MOTIVO_RECUSA,      NOM_PESSOA,      DTA_NASCIMENTO,      COD_CPF,      COD_RG,      DES_ORGAO_EXPEDIDOR,      DTA_EXPEDICAO_RG,      DTA_ADMISSAO,      DES_NATURALIDADE,      COD_UF_NATURALIDADE,      DES_UF_NATURALIDADE,      COD_NACIONALIDADE,      DES_NACIONALIDADE,      NOM_MAE,      NOM_PAI,      COD_ESTADO_CIVIL,      DES_ESTADO_CIVIL,      NOM_CONJUGE,      COD_CPF_CONJUGE,      DTA_NASC_CONJUGE,      COD_CEP,      DES_END_LOGRADOURO,      DES_END_NUMERO,      DES_END_COMPLEMENTO,      DES_END_BAIRRO,      DES_END_CIDADE,      COD_END_UF,      DES_END_UF,      COD_PAIS,      DES_PAIS,      COD_EMAIL,      COD_TELEFONE_FIXO,      COD_TELEFONE_CELULAR,      COD_CARGO,      DES_CARGO,      COD_SEXO,      DES_SEXO,      COD_BANCO,      DES_BANCO,      COD_AGENCIA,      COD_DV_AGENCIA,      COD_CONTA_CORRENTE,      COD_DV_CONTA_CORRENTE,      COD_ESPECIE_INSS,      DES_ESPECIE_INSS,      COD_BENEF_INSS,      IND_PPE,      IND_PPE_FAMILIAR,      IND_FATCA  )  VALUES(      @OID_RECAD_PUBLICO_ALVO,      @DTA_SOLICITACAO,      @DES_ORIGEM,      @COD_PROTOCOLO,      @DTA_RECUSA,      @TXT_MOTIVO_RECUSA,      @NOM_PESSOA,      @DTA_NASCIMENTO,      @COD_CPF,      @COD_RG,      @DES_ORGAO_EXPEDIDOR,      @DTA_EXPEDICAO_RG,      @DTA_ADMISSAO,      @DES_NATURALIDADE,      @COD_UF_NATURALIDADE,      @DES_UF_NATURALIDADE,      @COD_NACIONALIDADE,      @DES_NACIONALIDADE,      @NOM_MAE,      @NOM_PAI,      @COD_ESTADO_CIVIL,      @DES_ESTADO_CIVIL,      @NOM_CONJUGE,      @COD_CPF_CONJUGE,      @DTA_NASC_CONJUGE,      @COD_CEP,      @DES_END_LOGRADOURO,      @DES_END_NUMERO,      @DES_END_COMPLEMENTO,      @DES_END_BAIRRO,      @DES_END_CIDADE,      @COD_END_UF,      @DES_END_UF,      @COD_PAIS,      @DES_PAIS,      @COD_EMAIL,      @COD_TELEFONE_FIXO,      @COD_TELEFONE_CELULAR,      @COD_CARGO,      @DES_CARGO,      @COD_SEXO,      @DES_SEXO,      @COD_BANCO,      @DES_BANCO,      @COD_AGENCIA,      @COD_DV_AGENCIA,      @COD_CONTA_CORRENTE,      @COD_DV_CONTA_CORRENTE,      @COD_ESPECIE_INSS,      @DES_ESPECIE_INSS,      @COD_BENEF_INSS,      @IND_PPE,      @IND_PPE_FAMILIAR,      @IND_FATCA  )", new { OID_RECAD_PUBLICO_ALVO, DTA_SOLICITACAO, DES_ORIGEM, COD_PROTOCOLO, DTA_RECUSA, TXT_MOTIVO_RECUSA, NOM_PESSOA, DTA_NASCIMENTO, COD_CPF, COD_RG, DES_ORGAO_EXPEDIDOR, DTA_EXPEDICAO_RG, DTA_ADMISSAO, DES_NATURALIDADE, COD_UF_NATURALIDADE, DES_UF_NATURALIDADE, COD_NACIONALIDADE, DES_NACIONALIDADE, NOM_MAE, NOM_PAI, COD_ESTADO_CIVIL, DES_ESTADO_CIVIL, NOM_CONJUGE, COD_CPF_CONJUGE, DTA_NASC_CONJUGE, COD_CEP, DES_END_LOGRADOURO, DES_END_NUMERO, DES_END_COMPLEMENTO, DES_END_BAIRRO, DES_END_CIDADE, COD_END_UF, DES_END_UF, COD_PAIS, DES_PAIS, COD_EMAIL, COD_TELEFONE_FIXO, COD_TELEFONE_CELULAR, COD_CARGO, DES_CARGO, COD_SEXO, DES_SEXO, COD_BANCO, DES_BANCO, COD_AGENCIA, COD_DV_AGENCIA, COD_CONTA_CORRENTE, COD_DV_CONTA_CORRENTE, COD_ESPECIE_INSS, DES_ESPECIE_INSS, COD_BENEF_INSS, IND_PPE, IND_PPE_FAMILIAR, IND_FATCA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<long>("INSERT INTO WEB_RECAD_DADOS (OID_RECAD_DADOS,OID_RECAD_PUBLICO_ALVO, DTA_SOLICITACAO, DES_ORIGEM, COD_PROTOCOLO, DTA_RECUSA, TXT_MOTIVO_RECUSA, NOM_PESSOA, DTA_NASCIMENTO, COD_CPF, COD_RG, DES_ORGAO_EXPEDIDOR, DTA_EXPEDICAO_RG, DTA_ADMISSAO, DES_NATURALIDADE, COD_UF_NATURALIDADE, DES_UF_NATURALIDADE, COD_NACIONALIDADE, DES_NACIONALIDADE, NOM_MAE, NOM_PAI, COD_ESTADO_CIVIL, DES_ESTADO_CIVIL, NOM_CONJUGE, COD_CPF_CONJUGE, DTA_NASC_CONJUGE, COD_CEP, DES_END_LOGRADOURO, DES_END_NUMERO, DES_END_COMPLEMENTO, DES_END_BAIRRO, DES_END_CIDADE, COD_END_UF, DES_END_UF, COD_PAIS, DES_PAIS, COD_EMAIL, COD_TELEFONE_FIXO, COD_TELEFONE_CELULAR, COD_CARGO, DES_CARGO, COD_SEXO, DES_SEXO, COD_BANCO, DES_BANCO, COD_AGENCIA, COD_DV_AGENCIA, COD_CONTA_CORRENTE, COD_DV_CONTA_CORRENTE, COD_ESPECIE_INSS, DES_ESPECIE_INSS, COD_BENEF_INSS, IND_PPE, IND_PPE_FAMILIAR, IND_FATCA) VALUES (S_WEB_RECAD_DADOS.NEXTVAL,:OID_RECAD_PUBLICO_ALVO, :DTA_SOLICITACAO, :DES_ORIGEM, :COD_PROTOCOLO, :DTA_RECUSA, :TXT_MOTIVO_RECUSA, :NOM_PESSOA, :DTA_NASCIMENTO, :COD_CPF, :COD_RG, :DES_ORGAO_EXPEDIDOR, :DTA_EXPEDICAO_RG, :DTA_ADMISSAO, :DES_NATURALIDADE, :COD_UF_NATURALIDADE, :DES_UF_NATURALIDADE, :COD_NACIONALIDADE, :DES_NACIONALIDADE, :NOM_MAE, :NOM_PAI, :COD_ESTADO_CIVIL, :DES_ESTADO_CIVIL, :NOM_CONJUGE, :COD_CPF_CONJUGE, :DTA_NASC_CONJUGE, :COD_CEP, :DES_END_LOGRADOURO, :DES_END_NUMERO, :DES_END_COMPLEMENTO, :DES_END_BAIRRO, :DES_END_CIDADE, :COD_END_UF, :DES_END_UF, :COD_PAIS, :DES_PAIS, :COD_EMAIL, :COD_TELEFONE_FIXO, :COD_TELEFONE_CELULAR, :COD_CARGO, :DES_CARGO, :COD_SEXO, :DES_SEXO, :COD_BANCO, :DES_BANCO, :COD_AGENCIA, :COD_DV_AGENCIA, :COD_CONTA_CORRENTE, :COD_DV_CONTA_CORRENTE, :COD_ESPECIE_INSS, :DES_ESPECIE_INSS, :COD_BENEF_INSS, :IND_PPE, :IND_PPE_FAMILIAR, :IND_FATCA)", new { OID_RECAD_PUBLICO_ALVO, DTA_SOLICITACAO, DES_ORIGEM, COD_PROTOCOLO, DTA_RECUSA, TXT_MOTIVO_RECUSA, NOM_PESSOA, DTA_NASCIMENTO, COD_CPF, COD_RG, DES_ORGAO_EXPEDIDOR, DTA_EXPEDICAO_RG, DTA_ADMISSAO, DES_NATURALIDADE, COD_UF_NATURALIDADE, DES_UF_NATURALIDADE, COD_NACIONALIDADE, DES_NACIONALIDADE, NOM_MAE, NOM_PAI, COD_ESTADO_CIVIL, DES_ESTADO_CIVIL, NOM_CONJUGE, COD_CPF_CONJUGE, DTA_NASC_CONJUGE, COD_CEP, DES_END_LOGRADOURO, DES_END_NUMERO, DES_END_COMPLEMENTO, DES_END_BAIRRO, DES_END_CIDADE, COD_END_UF, DES_END_UF, COD_PAIS, DES_PAIS, COD_EMAIL, COD_TELEFONE_FIXO, COD_TELEFONE_CELULAR, COD_CARGO, DES_CARGO, COD_SEXO, DES_SEXO, COD_BANCO, DES_BANCO, COD_AGENCIA, COD_DV_AGENCIA, COD_CONTA_CORRENTE, COD_DV_CONTA_CORRENTE, COD_ESPECIE_INSS, DES_ESPECIE_INSS, COD_BENEF_INSS, IND_PPE, IND_PPE_FAMILIAR, IND_FATCA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

	}
}
