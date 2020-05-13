﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class DadosPessoaisDAO : BaseDAO<DadosPessoaisEntidade>
	{
		public virtual DadosPessoaisEntidade BuscarPensionistaPorCdPessoa(int CD_PESSOA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<DadosPessoaisEntidade>("SELECT FI_PESSOA.NO_PESSOA,          FI_PESSOA_FISICA.IR_SEXO,          FI_PESSOA_FISICA.DT_NASCIMENTO,          FI_PESSOA_FISICA.NR_CPF,          FI_PESSOA.CD_PESSOA,          CASE            WHEN FI_PESSOA_FISICA.IR_SEXO = 'M' THEN 'MASCULINO'            WHEN FI_PESSOA_FISICA.IR_SEXO = 'F' THEN 'FEMININO'          END AS DS_SEXO,          ENDERECO.NR_CEP,          ENDERECO.DS_ENDERECO,          ENDERECO.NR_ENDERECO,          ENDERECO.DS_COMPLEMENTO,          ENDERECO.NO_BAIRRO,          ENDERECO.NR_FONE,          ENDERECO.NR_CELULAR,          ENDERECO.NO_EMAIL   FROM   FR_USUARIO A   INNER JOIN FR_USUARIO_GRUPO B ON B.USR_CODIGO = A.USR_CODIGO   INNER JOIN FR_GRUPO C ON C.GRP_CODIGO = B.GRP_CODIGO   INNER JOIN FI_PESSOA ON FI_PESSOA.CD_PESSOA = A.CD_PESSOA   INNER JOIN FI_PESSOA_FISICA ON FI_PESSOA_FISICA.CD_PESSOA = A.CD_PESSOA   INNER JOIN FI_ENDERECO_PESSOA AS ENDERECO ON ENDERECO.CD_PESSOA = A.CD_PESSOA   WHERE IC_CATEG_USUARIO = 'PE'     AND FI_PESSOA.CD_PESSOA = @CD_PESSOA", new { CD_PESSOA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<DadosPessoaisEntidade>("SELECT FI_PESSOA.NO_PESSOA, FI_PESSOA_FISICA.IR_SEXO, FI_PESSOA_FISICA.DT_NASCIMENTO, FI_PESSOA_FISICA.NR_CPF, FI_PESSOA.CD_PESSOA, CASE  WHEN FI_PESSOA_FISICA.IR_SEXO='M' THEN 'MASCULINO' WHEN FI_PESSOA_FISICA.IR_SEXO='F' THEN 'FEMININO' END  AS DS_SEXO, ENDERECO.NR_CEP, ENDERECO.DS_ENDERECO, ENDERECO.NR_ENDERECO, ENDERECO.DS_COMPLEMENTO, ENDERECO.NO_BAIRRO, ENDERECO.NR_FONE, ENDERECO.NR_CELULAR, ENDERECO.NO_EMAIL FROM FR_USUARIO  A  INNER  JOIN FR_USUARIO_GRUPO   B  ON B.USR_CODIGO=A.USR_CODIGO INNER  JOIN FR_GRUPO   C  ON C.GRP_CODIGO=B.GRP_CODIGO INNER  JOIN FI_PESSOA  ON FI_PESSOA.CD_PESSOA=A.CD_PESSOA INNER  JOIN FI_PESSOA_FISICA  ON FI_PESSOA_FISICA.CD_PESSOA=A.CD_PESSOA INNER  JOIN FI_ENDERECO_PESSOA ENDERECO  ON ENDERECO.CD_PESSOA=A.CD_PESSOA WHERE IC_CATEG_USUARIO='PE' AND FI_PESSOA.CD_PESSOA=:CD_PESSOA", new { CD_PESSOA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual DadosPessoaisEntidade BuscarPensionistaTodosPorCdPessoa(int CD_PESSOA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<DadosPessoaisEntidade>("SELECT RB.SQ_PROCESSO,         RB.CD_PESSOA_RECEB,         PE.NO_PESSOA,         PF.NR_CPF,         CASE              WHEN PF.IR_SEXO = 'M' THEN 'MASCULINO'              WHEN PF.IR_SEXO = 'F' THEN 'FEMININO'              ELSE 'NÃO INFORMADO'         END AS IR_SEXO,         PF.DT_NASCIMENTO,         PF.NO_MAE,         PF.NO_PAI,         PF.NO_NATURALIDADE,         CASE               WHEN PF.EE_POLITICAMENTE_EXPOSTO = 'S' THEN 'SIM'              ELSE 'NÃO'         END  AS EE_POLITICAMENTE_EXPOSTO,         CASE               WHEN PF.EE_US_PERSON = 'S' THEN 'SIM'              ELSE 'NÃO'         END  AS EE_US_PERSON,         PF.CD_ESTADO_CIVIL,         EC.DS_ESTADO_CIVIL,         PF.CD_GRAU_INSTRUCAO,         GI.DS_GRAU_INSTRUCAO,         PF.SQ_PAIS_NACIONALIDADE,         PA.NO_PAIS AS NO_PAIS_NACIONALIDADE,         CB.CD_BANCO,         BA.NO_BANCO,         BAC.CD_AGENCIA,         BAC.DV_AGENCIA,         CB.NR_CC,         CB.DV_CC,         EP.SQ_ENDERECO,         EP.CD_TIPO_ENDERECO,         TE.DS_TIPO_ENDERECO,         EP.CD_MUNICIPIO,         MU.DS_MUNICIPIO,         EP.CD_UF,         EP.NR_CEP,         EP.DS_ENDERECO,         EP.NR_ENDERECO,         EP.DS_COMPLEMENTO,         EP.NO_BAIRRO,         EP.NR_FONE,         EP.NR_CELULAR,         EP.NO_EMAIL,         EP.SQ_TIPO_LOGRADOURO,         TL.NO_TIPO_LOGRADOURO                                FROM fi_recebedor_beneficio RB         INNER JOIN fi_pessoa PE ON PE.CD_PESSOA = RB.CD_PESSOA_RECEB         INNER JOIN fi_pessoa_fisica PF ON PF.CD_PESSOA = RB.CD_PESSOA_RECEB         LEFT OUTER JOIN fi_conta_bancaria CB ON CB.SQ_CONTA_BANCARIA = PE.SQ_CONTA_BANCARIA         LEFT OUTER JOIN fi_banco BA ON BA.CD_BANCO = CB.CD_BANCO         LEFT OUTER JOIN fi_banco_agencia BAC ON BAC.CD_BANCO = CB.CD_BANCO              AND BAC.CD_PESSOA_AGENCIA = CB.CD_PESSOA_AGENCIA         LEFT OUTER JOIN fi_estado_civil EC ON EC.CD_ESTADO_CIVIL = PF.CD_ESTADO_CIVIL         LEFT OUTER JOIN fi_grau_instrucao GI ON GI.CD_GRAU_INSTRUCAO = PF.CD_GRAU_INSTRUCAO         LEFT OUTER JOIN fi_paises PA ON PA.SQ_PAIS = PF.SQ_PAIS_NACIONALIDADE         LEFT OUTER JOIN fi_endereco_pessoa EP ON EP.CD_PESSOA = PF.CD_PESSOA              AND EP.SQ_ENDERECO = (SELECT MAX(EP2.SQ_ENDERECO)                                      FROM fi_endereco_pessoa EP2                                     WHERE EP2.CD_PESSOA = PF.CD_PESSOA                                       AND EP2.IR_CORRESPONDENCIA = 'S')         LEFT OUTER JOIN fi_tipo_endereco TE ON TE.CD_TIPO_ENDERECO = EP.CD_TIPO_ENDERECO         LEFT OUTER JOIN fi_municipio MU ON MU.CD_MUNICIPIO = EP.CD_MUNICIPIO         LEFT OUTER JOIN fi_tipo_logradouro TL on TL.SQ_TIPO_LOGRADOURO = EP.SQ_TIPO_LOGRADOURO  WHERE RB.SQ_GRUPO_FAMILIAR > 0    AND RB.CD_PESSOA_RECEB = @CD_PESSOA", new { CD_PESSOA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<DadosPessoaisEntidade>("SELECT RB.SQ_PROCESSO, RB.CD_PESSOA_RECEB, PE.NO_PESSOA, PF.NR_CPF, CASE  WHEN PF.IR_SEXO='M' THEN 'MASCULINO' WHEN PF.IR_SEXO='F' THEN 'FEMININO' ELSE 'NÃO INFORMADO' END  AS IR_SEXO, PF.DT_NASCIMENTO, PF.NO_MAE, PF.NO_PAI, PF.NO_NATURALIDADE, CASE  WHEN PF.EE_POLITICAMENTE_EXPOSTO='S' THEN 'SIM' ELSE 'NÃO' END  AS EE_POLITICAMENTE_EXPOSTO, CASE  WHEN PF.EE_US_PERSON='S' THEN 'SIM' ELSE 'NÃO' END  AS EE_US_PERSON, PF.CD_ESTADO_CIVIL, EC.DS_ESTADO_CIVIL, PF.CD_GRAU_INSTRUCAO, GI.DS_GRAU_INSTRUCAO, PF.SQ_PAIS_NACIONALIDADE, PA.NO_PAIS AS NO_PAIS_NACIONALIDADE, CB.CD_BANCO, BA.NO_BANCO, BAC.CD_AGENCIA, BAC.DV_AGENCIA, CB.NR_CC, CB.DV_CC, EP.SQ_ENDERECO, EP.CD_TIPO_ENDERECO, TE.DS_TIPO_ENDERECO, EP.CD_MUNICIPIO, MU.DS_MUNICIPIO, EP.CD_UF, EP.NR_CEP, EP.DS_ENDERECO, EP.NR_ENDERECO, EP.DS_COMPLEMENTO, EP.NO_BAIRRO, EP.NR_FONE, EP.NR_CELULAR, EP.NO_EMAIL, EP.SQ_TIPO_LOGRADOURO, TL.NO_TIPO_LOGRADOURO FROM FI_RECEBEDOR_BENEFICIO  RB  INNER  JOIN FI_PESSOA   PE  ON PE.CD_PESSOA=RB.CD_PESSOA_RECEB INNER  JOIN FI_PESSOA_FISICA   PF  ON PF.CD_PESSOA=RB.CD_PESSOA_RECEB LEFT OUTER JOIN FI_CONTA_BANCARIA   CB  ON CB.SQ_CONTA_BANCARIA=PE.SQ_CONTA_BANCARIA LEFT OUTER JOIN FI_BANCO   BA  ON BA.CD_BANCO=CB.CD_BANCO LEFT OUTER JOIN FI_BANCO_AGENCIA   BAC  ON BAC.CD_BANCO=CB.CD_BANCO AND BAC.CD_PESSOA_AGENCIA=CB.CD_PESSOA_AGENCIA LEFT OUTER JOIN FI_ESTADO_CIVIL   EC  ON EC.CD_ESTADO_CIVIL=PF.CD_ESTADO_CIVIL LEFT OUTER JOIN FI_GRAU_INSTRUCAO   GI  ON GI.CD_GRAU_INSTRUCAO=PF.CD_GRAU_INSTRUCAO LEFT OUTER JOIN FI_PAISES   PA  ON PA.SQ_PAIS=PF.SQ_PAIS_NACIONALIDADE LEFT OUTER JOIN FI_ENDERECO_PESSOA   EP  ON EP.CD_PESSOA=PF.CD_PESSOA AND EP.SQ_ENDERECO=(SELECT MAX(EP2.SQ_ENDERECO) FROM FI_ENDERECO_PESSOA  EP2  WHERE EP2.CD_PESSOA=PF.CD_PESSOA AND EP2.IR_CORRESPONDENCIA='S') LEFT OUTER JOIN FI_TIPO_ENDERECO   TE  ON TE.CD_TIPO_ENDERECO=EP.CD_TIPO_ENDERECO LEFT OUTER JOIN FI_MUNICIPIO   MU  ON MU.CD_MUNICIPIO=EP.CD_MUNICIPIO LEFT OUTER JOIN FI_TIPO_LOGRADOURO   TL  ON TL.SQ_TIPO_LOGRADOURO=EP.SQ_TIPO_LOGRADOURO WHERE RB.SQ_GRUPO_FAMILIAR>0 AND RB.CD_PESSOA_RECEB=:CD_PESSOA", new { CD_PESSOA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual DadosPessoaisEntidade BuscarPorCdPessoa(int CD_PESSOA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<DadosPessoaisEntidade>("SELECT       CONTRATO.SQ_CONTRATO_TRABALHO,       CONTRATO.NR_REGISTRO,       CONTRATO.DT_ADMISSAO,       CONTRATO.DT_DEMISSAO,       FI_PESSOA.NO_PESSOA,       FI_PESSOA_FISICA.IR_SEXO,       FI_PESSOA_FISICA.DT_NASCIMENTO,       FI_PESSOA_FISICA.NR_CPF,      FI_PESSOA.CD_PESSOA,      EMPRESA.NO_SIGLA AS SIGLA_EMPRESA,  	CASE  		WHEN FI_PESSOA_FISICA.IR_SEXO = 'M' THEN 'MASCULINO'  		WHEN FI_PESSOA_FISICA.IR_SEXO = 'F' THEN 'FEMININO'  	END AS DS_SEXO,  	ENDERECO.NR_CEP,  	ENDERECO.DS_ENDERECO,  	ENDERECO.NR_ENDERECO,  	ENDERECO.DS_COMPLEMENTO,  	ENDERECO.NO_BAIRRO,  	ENDERECO.NR_FONE,  	ENDERECO.NR_CELULAR,  	ENDERECO.NO_EMAIL  FROM FI_CONTRATO_TRABALHO AS CONTRATO  INNER JOIN FI_PESSOA ON FI_PESSOA.CD_PESSOA = CONTRATO.CD_PESSOA  INNER JOIN FI_PESSOA_FISICA ON FI_PESSOA_FISICA.CD_PESSOA = CONTRATO.CD_PESSOA  INNER JOIN FI_PESSOA AS EMPRESA ON EMPRESA.CD_PESSOA = CONTRATO.CD_PESSOA_PATR  INNER JOIN FI_ENDERECO_PESSOA AS ENDERECO ON ENDERECO.CD_PESSOA = CONTRATO.CD_PESSOA  WHERE FI_PESSOA.CD_PESSOA = @CD_PESSOA", new { CD_PESSOA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<DadosPessoaisEntidade>("SELECT CONTRATO.SQ_CONTRATO_TRABALHO, CONTRATO.NR_REGISTRO, CONTRATO.DT_ADMISSAO, CONTRATO.DT_DEMISSAO, FI_PESSOA.NO_PESSOA, FI_PESSOA_FISICA.IR_SEXO, FI_PESSOA_FISICA.DT_NASCIMENTO, FI_PESSOA_FISICA.NR_CPF, FI_PESSOA.CD_PESSOA, EMPRESA.NO_SIGLA AS SIGLA_EMPRESA, CASE  WHEN FI_PESSOA_FISICA.IR_SEXO='M' THEN 'MASCULINO' WHEN FI_PESSOA_FISICA.IR_SEXO='F' THEN 'FEMININO' END  AS DS_SEXO, ENDERECO.NR_CEP, ENDERECO.DS_ENDERECO, ENDERECO.NR_ENDERECO, ENDERECO.DS_COMPLEMENTO, ENDERECO.NO_BAIRRO, ENDERECO.NR_FONE, ENDERECO.NR_CELULAR, ENDERECO.NO_EMAIL FROM FI_CONTRATO_TRABALHO CONTRATO INNER  JOIN FI_PESSOA  ON FI_PESSOA.CD_PESSOA=CONTRATO.CD_PESSOA INNER  JOIN FI_PESSOA_FISICA  ON FI_PESSOA_FISICA.CD_PESSOA=CONTRATO.CD_PESSOA INNER  JOIN FI_PESSOA EMPRESA  ON EMPRESA.CD_PESSOA=CONTRATO.CD_PESSOA_PATR INNER  JOIN FI_ENDERECO_PESSOA ENDERECO  ON ENDERECO.CD_PESSOA=CONTRATO.CD_PESSOA WHERE FI_PESSOA.CD_PESSOA=:CD_PESSOA", new { CD_PESSOA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual DadosPessoaisEntidade BuscarPorCodEntid(string COD_ENTID)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<DadosPessoaisEntidade>("SELECT      CS_DADOS_PESSOAIS.*,      EE_ENTIDADE.CPF_CGC,      EE_ENTIDADE.NOME_ENTID  FROM CS_DADOS_PESSOAIS  INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_DADOS_PESSOAIS.COD_ENTID  WHERE CS_DADOS_PESSOAIS.COD_ENTID = @COD_ENTID", new { COD_ENTID });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<DadosPessoaisEntidade>("SELECT CS_DADOS_PESSOAIS.*, EE_ENTIDADE.CPF_CGC, EE_ENTIDADE.NOME_ENTID FROM CS_DADOS_PESSOAIS INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_DADOS_PESSOAIS.COD_ENTID WHERE CS_DADOS_PESSOAIS.COD_ENTID=:COD_ENTID", new { COD_ENTID });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual DadosPessoaisEntidade BuscarTodosPorCdPessoa(int CD_PESSOA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<DadosPessoaisEntidade>("SELECT CT.SQ_CONTRATO_TRABALHO,         CT.CD_PESSOA,         PE_PATR.NO_PESSOA AS NO_EMPRESA,         CT.NR_REGISTRO,         CT.DT_ADMISSAO,         PE.NO_PESSOA,         PF.NR_CPF,         PF.IR_SEXO,         CASE              WHEN PF.IR_SEXO = 'M' THEN 'MASCULINO'              WHEN PF.IR_SEXO = 'F' THEN 'FEMININO'              ELSE 'NÃO INFORMADO'         END AS DS_SEXO,         PF.DT_NASCIMENTO,         PF.NO_MAE,         PF.NO_PAI,         PF.NO_NATURALIDADE,         CASE               WHEN PF.EE_POLITICAMENTE_EXPOSTO = 'S' THEN 'SIM'              ELSE 'NÃO'         END  AS EE_POLITICAMENTE_EXPOSTO,         CASE               WHEN PF.EE_US_PERSON = 'S' THEN 'SIM'              ELSE 'NÃO'         END  AS EE_US_PERSON,         PF.CD_ESTADO_CIVIL,         EC.DS_ESTADO_CIVIL,         PF.CD_GRAU_INSTRUCAO,         GI.DS_GRAU_INSTRUCAO,         PF.SQ_PAIS_NACIONALIDADE,         PA.NO_PAIS AS NO_PAIS_NACIONALIDADE,         CB.CD_BANCO,         BA.NO_BANCO,         BAC.CD_AGENCIA,         BAC.DV_AGENCIA,         CB.NR_CC,         CB.DV_CC,         EP.SQ_ENDERECO,         EP.CD_TIPO_ENDERECO,         TE.DS_TIPO_ENDERECO,         EP.CD_MUNICIPIO,         MU.DS_MUNICIPIO,         EP.CD_UF,         EP.NR_CEP,         EP.DS_ENDERECO,         EP.NR_ENDERECO,         EP.DS_COMPLEMENTO,         EP.NO_BAIRRO,         EP.NR_FONE,         EP.NR_CELULAR,         EP.NO_EMAIL,         EP.SQ_TIPO_LOGRADOURO,         TL.NO_TIPO_LOGRADOURO                              FROM fi_contrato_trabalho CT      INNER JOIN fi_pessoa PE ON PE.CD_PESSOA = CT.CD_PESSOA      INNER JOIN fi_pessoa_fisica PF ON PF.CD_PESSOA = CT.CD_PESSOA      INNER JOIN fi_pessoa PE_PATR ON PE_PATR.CD_PESSOA = CT.CD_PESSOA_PATR      LEFT OUTER JOIN fi_conta_bancaria CB ON CB.SQ_CONTA_BANCARIA = PE.SQ_CONTA_BANCARIA      LEFT OUTER JOIN fi_banco BA ON BA.CD_BANCO = CB.CD_BANCO      LEFT OUTER JOIN fi_banco_agencia BAC ON BAC.CD_BANCO = CB.CD_BANCO          AND BAC.CD_PESSOA_AGENCIA = CB.CD_PESSOA_AGENCIA      LEFT OUTER JOIN fi_estado_civil EC ON EC.CD_ESTADO_CIVIL = PF.CD_ESTADO_CIVIL      LEFT OUTER JOIN fi_grau_instrucao GI ON GI.CD_GRAU_INSTRUCAO = PF.CD_GRAU_INSTRUCAO      LEFT OUTER JOIN fi_paises PA ON PA.SQ_PAIS = PF.SQ_PAIS_NACIONALIDADE      LEFT OUTER JOIN fi_endereco_pessoa EP ON EP.CD_PESSOA = PF.CD_PESSOA          AND EP.SQ_ENDERECO = (SELECT MAX(EP2.SQ_ENDERECO)                                  FROM fi_endereco_pessoa EP2                                  WHERE EP2.CD_PESSOA = PF.CD_PESSOA)      LEFT OUTER JOIN fi_tipo_endereco TE ON TE.CD_TIPO_ENDERECO = EP.CD_TIPO_ENDERECO      LEFT OUTER JOIN fi_municipio MU ON MU.CD_MUNICIPIO = EP.CD_MUNICIPIO      LEFT OUTER JOIN fi_tipo_logradouro TL on TL.SQ_TIPO_LOGRADOURO = EP.SQ_TIPO_LOGRADOURO  WHERE CT.CD_PESSOA = @CD_PESSOA", new { CD_PESSOA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<DadosPessoaisEntidade>("SELECT CT.SQ_CONTRATO_TRABALHO, CT.CD_PESSOA, PE_PATR.NO_PESSOA AS NO_EMPRESA, CT.NR_REGISTRO, CT.DT_ADMISSAO, PE.NO_PESSOA, PF.NR_CPF, PF.IR_SEXO, CASE  WHEN PF.IR_SEXO='M' THEN 'MASCULINO' WHEN PF.IR_SEXO='F' THEN 'FEMININO' ELSE 'NÃO INFORMADO' END  AS DS_SEXO, PF.DT_NASCIMENTO, PF.NO_MAE, PF.NO_PAI, PF.NO_NATURALIDADE, CASE  WHEN PF.EE_POLITICAMENTE_EXPOSTO='S' THEN 'SIM' ELSE 'NÃO' END  AS EE_POLITICAMENTE_EXPOSTO, CASE  WHEN PF.EE_US_PERSON='S' THEN 'SIM' ELSE 'NÃO' END  AS EE_US_PERSON, PF.CD_ESTADO_CIVIL, EC.DS_ESTADO_CIVIL, PF.CD_GRAU_INSTRUCAO, GI.DS_GRAU_INSTRUCAO, PF.SQ_PAIS_NACIONALIDADE, PA.NO_PAIS AS NO_PAIS_NACIONALIDADE, CB.CD_BANCO, BA.NO_BANCO, BAC.CD_AGENCIA, BAC.DV_AGENCIA, CB.NR_CC, CB.DV_CC, EP.SQ_ENDERECO, EP.CD_TIPO_ENDERECO, TE.DS_TIPO_ENDERECO, EP.CD_MUNICIPIO, MU.DS_MUNICIPIO, EP.CD_UF, EP.NR_CEP, EP.DS_ENDERECO, EP.NR_ENDERECO, EP.DS_COMPLEMENTO, EP.NO_BAIRRO, EP.NR_FONE, EP.NR_CELULAR, EP.NO_EMAIL, EP.SQ_TIPO_LOGRADOURO, TL.NO_TIPO_LOGRADOURO FROM FI_CONTRATO_TRABALHO  CT  INNER  JOIN FI_PESSOA   PE  ON PE.CD_PESSOA=CT.CD_PESSOA INNER  JOIN FI_PESSOA_FISICA   PF  ON PF.CD_PESSOA=CT.CD_PESSOA INNER  JOIN FI_PESSOA   PE_PATR  ON PE_PATR.CD_PESSOA=CT.CD_PESSOA_PATR LEFT OUTER JOIN FI_CONTA_BANCARIA   CB  ON CB.SQ_CONTA_BANCARIA=PE.SQ_CONTA_BANCARIA LEFT OUTER JOIN FI_BANCO   BA  ON BA.CD_BANCO=CB.CD_BANCO LEFT OUTER JOIN FI_BANCO_AGENCIA   BAC  ON BAC.CD_BANCO=CB.CD_BANCO AND BAC.CD_PESSOA_AGENCIA=CB.CD_PESSOA_AGENCIA LEFT OUTER JOIN FI_ESTADO_CIVIL   EC  ON EC.CD_ESTADO_CIVIL=PF.CD_ESTADO_CIVIL LEFT OUTER JOIN FI_GRAU_INSTRUCAO   GI  ON GI.CD_GRAU_INSTRUCAO=PF.CD_GRAU_INSTRUCAO LEFT OUTER JOIN FI_PAISES   PA  ON PA.SQ_PAIS=PF.SQ_PAIS_NACIONALIDADE LEFT OUTER JOIN FI_ENDERECO_PESSOA   EP  ON EP.CD_PESSOA=PF.CD_PESSOA AND EP.SQ_ENDERECO=(SELECT MAX(EP2.SQ_ENDERECO) FROM FI_ENDERECO_PESSOA  EP2  WHERE EP2.CD_PESSOA=PF.CD_PESSOA) LEFT OUTER JOIN FI_TIPO_ENDERECO   TE  ON TE.CD_TIPO_ENDERECO=EP.CD_TIPO_ENDERECO LEFT OUTER JOIN FI_MUNICIPIO   MU  ON MU.CD_MUNICIPIO=EP.CD_MUNICIPIO LEFT OUTER JOIN FI_TIPO_LOGRADOURO   TL  ON TL.SQ_TIPO_LOGRADOURO=EP.SQ_TIPO_LOGRADOURO WHERE CT.CD_PESSOA=:CD_PESSOA", new { CD_PESSOA });
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
