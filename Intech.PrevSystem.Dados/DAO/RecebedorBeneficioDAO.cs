﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class RecebedorBeneficioDAO : BaseDAO<RecebedorBeneficioEntidade>
	{
		public virtual List<RecebedorBeneficioEntidade> BuscarPensionistaPorCpf(string CPF)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<RecebedorBeneficioEntidade>("SELECT RB.*  FROM GB_RECEBEDOR_BENEFICIO RB      INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = RB.COD_ENTID      LEFT OUTER JOIN CS_DADOS_PESSOAIS DP ON DP.COD_ENTID = EE.COD_ENTID       INNER JOIN GB_PROCESSOS_BENEFICIO PB ON PB.CD_FUNDACAO = RB.CD_FUNDACAO                   AND PB.NUM_INSCRICAO = RB.NUM_INSCRICAO      INNER JOIN GB_ESPECIE_BENEFICIO EB ON EB.CD_ESPECIE = PB.CD_ESPECIE  WHERE RB.CD_TIPO_RECEBEDOR = 'G'    AND EE.CPF_CGC = @CPF    AND EB.CD_GRUPO_ESPECIE IN ('2', '4')", new { CPF }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<RecebedorBeneficioEntidade>("SELECT RB.* FROM GB_RECEBEDOR_BENEFICIO  RB  INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=RB.COD_ENTID LEFT OUTER JOIN CS_DADOS_PESSOAIS   DP  ON DP.COD_ENTID=EE.COD_ENTID INNER  JOIN GB_PROCESSOS_BENEFICIO   PB  ON PB.CD_FUNDACAO=RB.CD_FUNDACAO AND PB.NUM_INSCRICAO=RB.NUM_INSCRICAO INNER  JOIN GB_ESPECIE_BENEFICIO   EB  ON EB.CD_ESPECIE=PB.CD_ESPECIE WHERE RB.CD_TIPO_RECEBEDOR='G' AND EE.CPF_CGC=:CPF AND EB.CD_GRUPO_ESPECIE IN ('2', '4')", new { CPF }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual RecebedorBeneficioEntidade BuscarPorFundacaoEmpresaInscricao(string CD_FUNDACAO, string CD_EMPRESA, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<RecebedorBeneficioEntidade>("SELECT RB.*  FROM GB_RECEBEDOR_BENEFICIO RB      INNER JOIN GB_PROCESSOS_BENEFICIO PB ON PB.CD_FUNDACAO = RB.CD_FUNDACAO          AND PB.NUM_INSCRICAO = RB.NUM_INSCRICAO      INNER JOIN GB_ESPECIE_BENEFICIO EB ON EB.CD_ESPECIE = PB.CD_ESPECIE  WHERE PB.DT_TERMINO >= GETDATE()    AND RB.CD_FUNDACAO = @CD_FUNDACAO    AND RB.CD_EMPRESA = @CD_EMPRESA    AND RB.NUM_INSCRICAO = @NUM_INSCRICAO", new { CD_FUNDACAO, CD_EMPRESA, NUM_INSCRICAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<RecebedorBeneficioEntidade>("SELECT RB.* FROM GB_RECEBEDOR_BENEFICIO  RB  INNER  JOIN GB_PROCESSOS_BENEFICIO   PB  ON PB.CD_FUNDACAO=RB.CD_FUNDACAO AND PB.NUM_INSCRICAO=RB.NUM_INSCRICAO INNER  JOIN GB_ESPECIE_BENEFICIO   EB  ON EB.CD_ESPECIE=PB.CD_ESPECIE WHERE PB.DT_TERMINO>=SYSDATE AND RB.CD_FUNDACAO=:CD_FUNDACAO AND RB.CD_EMPRESA=:CD_EMPRESA AND RB.NUM_INSCRICAO=:NUM_INSCRICAO", new { CD_FUNDACAO, CD_EMPRESA, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual RecebedorBeneficioEntidade BuscarPorFundacaoEmpresaInscricaoGrupoFamiliar(string CD_FUNDACAO, string CD_EMPRESA, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<RecebedorBeneficioEntidade>("SELECT RB.*  FROM GB_RECEBEDOR_BENEFICIO RB      INNER JOIN GB_PROCESSOS_BENEFICIO PB ON PB.CD_FUNDACAO = RB.CD_FUNDACAO                   AND PB.NUM_INSCRICAO = RB.NUM_INSCRICAO      INNER JOIN GB_ESPECIE_BENEFICIO EB ON EB.CD_ESPECIE = PB.CD_ESPECIE  WHERE RB.CD_TIPO_RECEBEDOR = 'G'    AND EB.CD_GRUPO_ESPECIE = '2'    AND PB.DT_TERMINO >= GETDATE()    AND RB.CD_FUNDACAO = @CD_FUNDACAO    AND RB.CD_EMPRESA = @CD_EMPRESA    AND RB.NUM_INSCRICAO = @NUM_INSCRICAO    AND EXISTS (SELECT BP.CD_FUNDACAO                   FROM GB_BENEFICIARIO_PREVIDENCIAL BP                 WHERE BP.CD_FUNDACAO = RB.CD_FUNDACAO                   AND BP.NUM_INSCRICAO = RB.NUM_INSCRICAO                   AND BP.NUM_SEQ_GR_FAMIL = RB.NUM_SEQ_GR_FAMIL                   AND BP.DT_TERMINO_VALIDADE >= GETDATE())", new { CD_FUNDACAO, CD_EMPRESA, NUM_INSCRICAO });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<RecebedorBeneficioEntidade>("SELECT RB.* FROM GB_RECEBEDOR_BENEFICIO  RB  INNER  JOIN GB_PROCESSOS_BENEFICIO   PB  ON PB.CD_FUNDACAO=RB.CD_FUNDACAO AND PB.NUM_INSCRICAO=RB.NUM_INSCRICAO INNER  JOIN GB_ESPECIE_BENEFICIO   EB  ON EB.CD_ESPECIE=PB.CD_ESPECIE WHERE RB.CD_TIPO_RECEBEDOR='G' AND EB.CD_GRUPO_ESPECIE='2' AND PB.DT_TERMINO>=SYSDATE AND RB.CD_FUNDACAO=:CD_FUNDACAO AND RB.CD_EMPRESA=:CD_EMPRESA AND RB.NUM_INSCRICAO=:NUM_INSCRICAO AND  EXISTS (SELECT BP.CD_FUNDACAO FROM GB_BENEFICIARIO_PREVIDENCIAL  BP  WHERE BP.CD_FUNDACAO=RB.CD_FUNDACAO AND BP.NUM_INSCRICAO=RB.NUM_INSCRICAO AND BP.NUM_SEQ_GR_FAMIL=RB.NUM_SEQ_GR_FAMIL AND BP.DT_TERMINO_VALIDADE>=SYSDATE)", new { CD_FUNDACAO, CD_EMPRESA, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual RecebedorBeneficioEntidade BuscarPorFundacaoEmpresaInscricaoSeqRecebedor(string CD_FUNDACAO, string CD_EMPRESA, string NUM_INSCRICAO, string SEQ_RECEBEDOR)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<RecebedorBeneficioEntidade>("SELECT RB.*  FROM GB_RECEBEDOR_BENEFICIO RB      INNER JOIN GB_PROCESSOS_BENEFICIO PB ON PB.CD_FUNDACAO = RB.CD_FUNDACAO          AND PB.NUM_INSCRICAO = RB.NUM_INSCRICAO      INNER JOIN GB_ESPECIE_BENEFICIO EB ON EB.CD_ESPECIE = PB.CD_ESPECIE  WHERE PB.DT_TERMINO >= GETDATE()    AND RB.CD_FUNDACAO = @CD_FUNDACAO    AND RB.CD_EMPRESA = @CD_EMPRESA    AND RB.NUM_INSCRICAO = @NUM_INSCRICAO    AND RB.SEQ_RECEBEDOR = @SEQ_RECEBEDOR", new { CD_FUNDACAO, CD_EMPRESA, NUM_INSCRICAO, SEQ_RECEBEDOR });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<RecebedorBeneficioEntidade>("SELECT RB.* FROM GB_RECEBEDOR_BENEFICIO  RB  INNER  JOIN GB_PROCESSOS_BENEFICIO   PB  ON PB.CD_FUNDACAO=RB.CD_FUNDACAO AND PB.NUM_INSCRICAO=RB.NUM_INSCRICAO INNER  JOIN GB_ESPECIE_BENEFICIO   EB  ON EB.CD_ESPECIE=PB.CD_ESPECIE WHERE PB.DT_TERMINO>=SYSDATE AND RB.CD_FUNDACAO=:CD_FUNDACAO AND RB.CD_EMPRESA=:CD_EMPRESA AND RB.NUM_INSCRICAO=:NUM_INSCRICAO AND RB.SEQ_RECEBEDOR=:SEQ_RECEBEDOR", new { CD_FUNDACAO, CD_EMPRESA, NUM_INSCRICAO, SEQ_RECEBEDOR });
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
