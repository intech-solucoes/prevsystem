﻿#region Usings
using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
#endregion

namespace Intech.PrevSystem.Dados.DAO
{   
    public abstract class PlanoVinculadoDAO : BaseDAO<PlanoVinculadoEntidade>
    {
        
		public virtual IEnumerable<PlanoVinculadoEntidade> BuscarPorContratoTrabalho(int SQ_CONTRATO_TRABALHO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT       FI_PLANO_PREVIDENCIAL.DS_PLANO_PREVIDENCIAL,       FI_SIT_PLANO.DS_SIT_PLANO,       FI_SIT_INSCRICAO.DS_SIT_INSCRICAO,       FI_MOT_SIT_PLANO.DS_MOT_SIT_PLANO,       FI_PLANO_PREVIDENCIAL.NR_CODIGO_CNPB,       FI_PLANO_VINCULADO.DT_INSC_PLANO,      FI_PLANO_VINCULADO.DT_SITUACAO,      FI_PLANO_PREVIDENCIAL.CD_INDICE_VALORIZACAO,      FI_PLANO_VINCULADO.*  FROM FI_PLANO_VINCULADO   INNER JOIN FI_PLANO_PREVIDENCIAL ON FI_PLANO_PREVIDENCIAL.SQ_PLANO_PREVIDENCIAL = FI_PLANO_VINCULADO.SQ_PLANO_PREVIDENCIAL  INNER JOIN FI_SIT_PLANO ON FI_SIT_PLANO.SQ_SIT_PLANO = FI_PLANO_VINCULADO.SQ_SIT_PLANO  INNER JOIN FI_MOT_SIT_PLANO ON FI_MOT_SIT_PLANO.SQ_MOT_SIT_PLANO = FI_PLANO_VINCULADO.SQ_MOT_SIT_PLANO  LEFT JOIN FI_SIT_INSCRICAO ON FI_SIT_INSCRICAO.SQ_SIT_INSCRICAO = FI_PLANO_VINCULADO.SQ_SIT_INSCRICAO  WHERE SQ_CONTRATO_TRABALHO = @SQ_CONTRATO_TRABALHO    AND FI_PLANO_VINCULADO.SQ_SIT_PLANO NOT IN (2, 6, 7)", new { SQ_CONTRATO_TRABALHO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT FI_PLANO_PREVIDENCIAL.DS_PLANO_PREVIDENCIAL, FI_SIT_PLANO.DS_SIT_PLANO, FI_SIT_INSCRICAO.DS_SIT_INSCRICAO, FI_MOT_SIT_PLANO.DS_MOT_SIT_PLANO, FI_PLANO_PREVIDENCIAL.NR_CODIGO_CNPB, FI_PLANO_VINCULADO.DT_INSC_PLANO, FI_PLANO_VINCULADO.DT_SITUACAO, FI_PLANO_PREVIDENCIAL.CD_INDICE_VALORIZACAO, FI_PLANO_VINCULADO.* FROM FI_PLANO_VINCULADO INNER  JOIN FI_PLANO_PREVIDENCIAL  ON FI_PLANO_PREVIDENCIAL.SQ_PLANO_PREVIDENCIAL=FI_PLANO_VINCULADO.SQ_PLANO_PREVIDENCIAL INNER  JOIN FI_SIT_PLANO  ON FI_SIT_PLANO.SQ_SIT_PLANO=FI_PLANO_VINCULADO.SQ_SIT_PLANO INNER  JOIN FI_MOT_SIT_PLANO  ON FI_MOT_SIT_PLANO.SQ_MOT_SIT_PLANO=FI_PLANO_VINCULADO.SQ_MOT_SIT_PLANO LEFT JOIN FI_SIT_INSCRICAO  ON FI_SIT_INSCRICAO.SQ_SIT_INSCRICAO=FI_PLANO_VINCULADO.SQ_SIT_INSCRICAO WHERE SQ_CONTRATO_TRABALHO=:SQ_CONTRATO_TRABALHO AND FI_PLANO_VINCULADO.SQ_SIT_PLANO NOT  IN (2, 6, 7)", new { SQ_CONTRATO_TRABALHO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual PlanoVinculadoEntidade BuscarPorContratoTrabalhoPlano(int SQ_CONTRATO_TRABALHO, int SQ_PLANO_PREVIDENCIAL)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<PlanoVinculadoEntidade>("SELECT       FI_PLANO_PREVIDENCIAL.DS_PLANO_PREVIDENCIAL,       FI_SIT_PLANO.DS_SIT_PLANO,       FI_SIT_INSCRICAO.DS_SIT_INSCRICAO,       FI_MOT_SIT_PLANO.DS_MOT_SIT_PLANO,       FI_PLANO_PREVIDENCIAL.NR_CODIGO_CNPB,       FI_PLANO_VINCULADO.DT_INSC_PLANO,      FI_PLANO_VINCULADO.DT_SITUACAO,      FI_PLANO_PREVIDENCIAL.CD_INDICE_VALORIZACAO,  	FI_OPCAO_TRIBUTACAO.DS_OPCAO_TRIBUTACAO,      FI_PLANO_VINCULADO.*  FROM FI_PLANO_VINCULADO   INNER JOIN FI_PLANO_PREVIDENCIAL ON FI_PLANO_PREVIDENCIAL.SQ_PLANO_PREVIDENCIAL = FI_PLANO_VINCULADO.SQ_PLANO_PREVIDENCIAL  INNER JOIN FI_SIT_PLANO ON FI_SIT_PLANO.SQ_SIT_PLANO = FI_PLANO_VINCULADO.SQ_SIT_PLANO  INNER JOIN FI_MOT_SIT_PLANO ON FI_MOT_SIT_PLANO.SQ_MOT_SIT_PLANO = FI_PLANO_VINCULADO.SQ_MOT_SIT_PLANO  INNER JOIN FI_SIT_INSCRICAO ON FI_SIT_INSCRICAO.SQ_SIT_INSCRICAO = FI_PLANO_VINCULADO.SQ_SIT_INSCRICAO  INNER JOIN FI_OPCAO_TRIBUTACAO ON FI_OPCAO_TRIBUTACAO.SQ_OPCAO_TRIBUTACAO = FI_PLANO_VINCULADO.SQ_OPCAO_TRIBUTACAO  WHERE SQ_CONTRATO_TRABALHO = @SQ_CONTRATO_TRABALHO    AND FI_PLANO_VINCULADO.SQ_SIT_PLANO NOT IN (2, 6)    AND FI_PLANO_PREVIDENCIAL.SQ_PLANO_PREVIDENCIAL = @SQ_PLANO_PREVIDENCIAL", new { SQ_CONTRATO_TRABALHO, SQ_PLANO_PREVIDENCIAL });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<PlanoVinculadoEntidade>("SELECT FI_PLANO_PREVIDENCIAL.DS_PLANO_PREVIDENCIAL, FI_SIT_PLANO.DS_SIT_PLANO, FI_SIT_INSCRICAO.DS_SIT_INSCRICAO, FI_MOT_SIT_PLANO.DS_MOT_SIT_PLANO, FI_PLANO_PREVIDENCIAL.NR_CODIGO_CNPB, FI_PLANO_VINCULADO.DT_INSC_PLANO, FI_PLANO_VINCULADO.DT_SITUACAO, FI_PLANO_PREVIDENCIAL.CD_INDICE_VALORIZACAO, FI_OPCAO_TRIBUTACAO.DS_OPCAO_TRIBUTACAO, FI_PLANO_VINCULADO.* FROM FI_PLANO_VINCULADO INNER  JOIN FI_PLANO_PREVIDENCIAL  ON FI_PLANO_PREVIDENCIAL.SQ_PLANO_PREVIDENCIAL=FI_PLANO_VINCULADO.SQ_PLANO_PREVIDENCIAL INNER  JOIN FI_SIT_PLANO  ON FI_SIT_PLANO.SQ_SIT_PLANO=FI_PLANO_VINCULADO.SQ_SIT_PLANO INNER  JOIN FI_MOT_SIT_PLANO  ON FI_MOT_SIT_PLANO.SQ_MOT_SIT_PLANO=FI_PLANO_VINCULADO.SQ_MOT_SIT_PLANO INNER  JOIN FI_SIT_INSCRICAO  ON FI_SIT_INSCRICAO.SQ_SIT_INSCRICAO=FI_PLANO_VINCULADO.SQ_SIT_INSCRICAO INNER  JOIN FI_OPCAO_TRIBUTACAO  ON FI_OPCAO_TRIBUTACAO.SQ_OPCAO_TRIBUTACAO=FI_PLANO_VINCULADO.SQ_OPCAO_TRIBUTACAO WHERE SQ_CONTRATO_TRABALHO=:SQ_CONTRATO_TRABALHO AND FI_PLANO_VINCULADO.SQ_SIT_PLANO NOT  IN (2, 6) AND FI_PLANO_PREVIDENCIAL.SQ_PLANO_PREVIDENCIAL=:SQ_PLANO_PREVIDENCIAL", new { SQ_CONTRATO_TRABALHO, SQ_PLANO_PREVIDENCIAL });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PlanoVinculadoEntidade> BuscarPorCpf(string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT       FI_PLANO_PREVIDENCIAL.DS_PLANO_PREVIDENCIAL,       FI_SIT_PLANO.DS_SIT_PLANO,       FI_SIT_INSCRICAO.DS_SIT_INSCRICAO,       FI_MOT_SIT_PLANO.DS_MOT_SIT_PLANO,       FI_PLANO_PREVIDENCIAL.NR_CODIGO_CNPB,       FI_PLANO_VINCULADO.DT_INSC_PLANO,      FI_PLANO_VINCULADO.DT_SITUACAO,      FI_PLANO_PREVIDENCIAL.CD_INDICE_VALORIZACAO,      FI_PLANO_VINCULADO.*  FROM FI_PLANO_VINCULADO   INNER JOIN FI_PLANO_PREVIDENCIAL ON FI_PLANO_PREVIDENCIAL.SQ_PLANO_PREVIDENCIAL = FI_PLANO_VINCULADO.SQ_PLANO_PREVIDENCIAL  INNER JOIN FI_SIT_PLANO ON FI_SIT_PLANO.SQ_SIT_PLANO = FI_PLANO_VINCULADO.SQ_SIT_PLANO  INNER JOIN FI_MOT_SIT_PLANO ON FI_MOT_SIT_PLANO.SQ_MOT_SIT_PLANO = FI_PLANO_VINCULADO.SQ_MOT_SIT_PLANO  INNER JOIN FI_SIT_INSCRICAO ON FI_SIT_INSCRICAO.SQ_SIT_INSCRICAO = FI_PLANO_VINCULADO.SQ_SIT_INSCRICAO  INNER JOIN FI_CONTRATO_TRABALHO ON FI_CONTRATO_TRABALHO.SQ_CONTRATO_TRABALHO = FI_PLANO_VINCULADO.SQ_CONTRATO_TRABALHO  INNER JOIN FI_PESSOA ON FI_PESSOA.CD_PESSOA = FI_CONTRATO_TRABALHO.CD_PESSOA  INNER JOIN FI_PESSOA_FISICA ON FI_PESSOA_FISICA.CD_PESSOA = FI_CONTRATO_TRABALHO.CD_PESSOA  WHERE FI_PESSOA_FISICA.NR_CPF = @CPF    AND FI_PLANO_VINCULADO.SQ_SIT_PLANO NOT IN (2, 6)  ORDER BY FI_PLANO_VINCULADO.DT_INSC_PLANO DESC", new { CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT FI_PLANO_PREVIDENCIAL.DS_PLANO_PREVIDENCIAL, FI_SIT_PLANO.DS_SIT_PLANO, FI_SIT_INSCRICAO.DS_SIT_INSCRICAO, FI_MOT_SIT_PLANO.DS_MOT_SIT_PLANO, FI_PLANO_PREVIDENCIAL.NR_CODIGO_CNPB, FI_PLANO_VINCULADO.DT_INSC_PLANO, FI_PLANO_VINCULADO.DT_SITUACAO, FI_PLANO_PREVIDENCIAL.CD_INDICE_VALORIZACAO, FI_PLANO_VINCULADO.* FROM FI_PLANO_VINCULADO INNER  JOIN FI_PLANO_PREVIDENCIAL  ON FI_PLANO_PREVIDENCIAL.SQ_PLANO_PREVIDENCIAL=FI_PLANO_VINCULADO.SQ_PLANO_PREVIDENCIAL INNER  JOIN FI_SIT_PLANO  ON FI_SIT_PLANO.SQ_SIT_PLANO=FI_PLANO_VINCULADO.SQ_SIT_PLANO INNER  JOIN FI_MOT_SIT_PLANO  ON FI_MOT_SIT_PLANO.SQ_MOT_SIT_PLANO=FI_PLANO_VINCULADO.SQ_MOT_SIT_PLANO INNER  JOIN FI_SIT_INSCRICAO  ON FI_SIT_INSCRICAO.SQ_SIT_INSCRICAO=FI_PLANO_VINCULADO.SQ_SIT_INSCRICAO INNER  JOIN FI_CONTRATO_TRABALHO  ON FI_CONTRATO_TRABALHO.SQ_CONTRATO_TRABALHO=FI_PLANO_VINCULADO.SQ_CONTRATO_TRABALHO INNER  JOIN FI_PESSOA  ON FI_PESSOA.CD_PESSOA=FI_CONTRATO_TRABALHO.CD_PESSOA INNER  JOIN FI_PESSOA_FISICA  ON FI_PESSOA_FISICA.CD_PESSOA=FI_CONTRATO_TRABALHO.CD_PESSOA WHERE FI_PESSOA_FISICA.NR_CPF=:CPF AND FI_PLANO_VINCULADO.SQ_SIT_PLANO NOT  IN (2, 6) ORDER BY FI_PLANO_VINCULADO.DT_INSC_PLANO DESC", new { CPF });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PlanoVinculadoEntidade> BuscarPorFundacaoEmpresaCpf(string CD_FUNDACAO, string CD_EMPRESA, string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST,          TB_CATEGORIA.CD_CATEGORIA,          TB_CATEGORIA.DS_CATEGORIA,          TB_PLANOS.DS_PLANO,         CS_PLANOS_VINC.*  FROM   CS_PLANOS_VINC   INNER JOIN TB_PLANOS ON CS_PLANOS_VINC.CD_FUNDACAO = TB_PLANOS.CD_FUNDACAO                       AND CS_PLANOS_VINC.CD_PLANO = TB_PLANOS.CD_PLANO   INNER JOIN TB_SIT_PLANO ON CS_PLANOS_VINC.CD_SIT_PLANO = TB_SIT_PLANO.CD_SIT_PLANO   LEFT OUTER JOIN TB_PERFIL_INVEST ON CS_PLANOS_VINC.CD_PERFIL_INVEST = TB_PERFIL_INVEST.CD_PERFIL_INVEST   INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_INSCRICAO = CS_PLANOS_VINC.NUM_INSCRICAO   INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = CS_FUNCIONARIO.COD_ENTID  INNER JOIN TB_CATEGORIA ON TB_CATEGORIA.CD_CATEGORIA = TB_SIT_PLANO.CD_CATEGORIA   WHERE  ( CS_FUNCIONARIO.CD_FUNDACAO = @CD_FUNDACAO )          AND ( CS_PLANOS_VINC.CD_FUNDACAO = @CD_FUNDACAO )          AND ( TB_PLANOS.CD_FUNDACAO = @CD_FUNDACAO )          AND ( CS_FUNCIONARIO.CD_EMPRESA = @CD_EMPRESA )          AND ( EE_ENTIDADE.CPF_CGC = @CPF )         AND ( TB_CATEGORIA.CD_CATEGORIA <> '2' )", new { CD_FUNDACAO, CD_EMPRESA, CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST, TB_CATEGORIA.CD_CATEGORIA, TB_CATEGORIA.DS_CATEGORIA, TB_PLANOS.DS_PLANO, CS_PLANOS_VINC.* FROM CS_PLANOS_VINC INNER  JOIN TB_PLANOS  ON CS_PLANOS_VINC.CD_FUNDACAO=TB_PLANOS.CD_FUNDACAO AND CS_PLANOS_VINC.CD_PLANO=TB_PLANOS.CD_PLANO INNER  JOIN TB_SIT_PLANO  ON CS_PLANOS_VINC.CD_SIT_PLANO=TB_SIT_PLANO.CD_SIT_PLANO LEFT OUTER JOIN TB_PERFIL_INVEST  ON CS_PLANOS_VINC.CD_PERFIL_INVEST=TB_PERFIL_INVEST.CD_PERFIL_INVEST INNER  JOIN CS_FUNCIONARIO  ON CS_FUNCIONARIO.NUM_INSCRICAO=CS_PLANOS_VINC.NUM_INSCRICAO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=CS_FUNCIONARIO.COD_ENTID INNER  JOIN TB_CATEGORIA  ON TB_CATEGORIA.CD_CATEGORIA=TB_SIT_PLANO.CD_CATEGORIA WHERE (CS_FUNCIONARIO.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_PLANOS_VINC.CD_FUNDACAO=:CD_FUNDACAO) AND (TB_PLANOS.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_FUNCIONARIO.CD_EMPRESA=:CD_EMPRESA) AND (EE_ENTIDADE.CPF_CGC=:CPF) AND (TB_CATEGORIA.CD_CATEGORIA<>'2')", new { CD_FUNDACAO, CD_EMPRESA, CPF });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PlanoVinculadoEntidade> BuscarPorFundacaoEmpresaCpfPensionista(string CD_FUNDACAO, string CD_EMPRESA, string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST,          TB_CATEGORIA.CD_CATEGORIA,          TB_CATEGORIA.DS_CATEGORIA,          TB_PLANOS.DS_PLANO,         CS_PLANOS_VINC.*  FROM   CS_PLANOS_VINC   INNER JOIN TB_PLANOS ON CS_PLANOS_VINC.CD_FUNDACAO = TB_PLANOS.CD_FUNDACAO                       AND CS_PLANOS_VINC.CD_PLANO = TB_PLANOS.CD_PLANO   INNER JOIN TB_SIT_PLANO ON CS_PLANOS_VINC.CD_SIT_PLANO = TB_SIT_PLANO.CD_SIT_PLANO   LEFT OUTER JOIN TB_PERFIL_INVEST ON CS_PLANOS_VINC.CD_PERFIL_INVEST = TB_PERFIL_INVEST.CD_PERFIL_INVEST   INNER JOIN GB_RECEBEDOR_BENEFICIO ON GB_RECEBEDOR_BENEFICIO.NUM_INSCRICAO = CS_PLANOS_VINC.NUM_INSCRICAO   INNER JOIN EE_ENTIDADE ON EE_ENTIDADE.COD_ENTID = GB_RECEBEDOR_BENEFICIO.COD_ENTID  INNER JOIN TB_CATEGORIA ON TB_CATEGORIA.CD_CATEGORIA = TB_SIT_PLANO.CD_CATEGORIA   WHERE  ( GB_RECEBEDOR_BENEFICIO.CD_FUNDACAO = @CD_FUNDACAO )          AND ( CS_PLANOS_VINC.CD_FUNDACAO = @CD_FUNDACAO )          AND ( TB_PLANOS.CD_FUNDACAO = @CD_FUNDACAO )          AND ( GB_RECEBEDOR_BENEFICIO.CD_EMPRESA = @CD_EMPRESA )          AND ( EE_ENTIDADE.CPF_CGC =  @CPF )         AND ( TB_CATEGORIA.CD_CATEGORIA <> '2' )", new { CD_FUNDACAO, CD_EMPRESA, CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST, TB_CATEGORIA.CD_CATEGORIA, TB_CATEGORIA.DS_CATEGORIA, TB_PLANOS.DS_PLANO, CS_PLANOS_VINC.* FROM CS_PLANOS_VINC INNER  JOIN TB_PLANOS  ON CS_PLANOS_VINC.CD_FUNDACAO=TB_PLANOS.CD_FUNDACAO AND CS_PLANOS_VINC.CD_PLANO=TB_PLANOS.CD_PLANO INNER  JOIN TB_SIT_PLANO  ON CS_PLANOS_VINC.CD_SIT_PLANO=TB_SIT_PLANO.CD_SIT_PLANO LEFT OUTER JOIN TB_PERFIL_INVEST  ON CS_PLANOS_VINC.CD_PERFIL_INVEST=TB_PERFIL_INVEST.CD_PERFIL_INVEST INNER  JOIN GB_RECEBEDOR_BENEFICIO  ON GB_RECEBEDOR_BENEFICIO.NUM_INSCRICAO=CS_PLANOS_VINC.NUM_INSCRICAO INNER  JOIN EE_ENTIDADE  ON EE_ENTIDADE.COD_ENTID=GB_RECEBEDOR_BENEFICIO.COD_ENTID INNER  JOIN TB_CATEGORIA  ON TB_CATEGORIA.CD_CATEGORIA=TB_SIT_PLANO.CD_CATEGORIA WHERE (GB_RECEBEDOR_BENEFICIO.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_PLANOS_VINC.CD_FUNDACAO=:CD_FUNDACAO) AND (TB_PLANOS.CD_FUNDACAO=:CD_FUNDACAO) AND (GB_RECEBEDOR_BENEFICIO.CD_EMPRESA=:CD_EMPRESA) AND (EE_ENTIDADE.CPF_CGC=:CPF) AND (TB_CATEGORIA.CD_CATEGORIA<>'2')", new { CD_FUNDACAO, CD_EMPRESA, CPF });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PlanoVinculadoEntidade> BuscarPorFundacaoEmpresaMatricula(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST,          TB_CATEGORIA.CD_CATEGORIA,          TB_CATEGORIA.DS_CATEGORIA,          TB_SIT_PLANO.DS_SIT_PLANO,         TB_PLANOS.DS_PLANO,         TB_PLANOS.COD_CNPB,         CS_PLANOS_VINC.*  FROM   CS_PLANOS_VINC   INNER JOIN TB_PLANOS ON CS_PLANOS_VINC.CD_FUNDACAO = TB_PLANOS.CD_FUNDACAO                       AND CS_PLANOS_VINC.CD_PLANO = TB_PLANOS.CD_PLANO   INNER JOIN TB_SIT_PLANO ON CS_PLANOS_VINC.CD_SIT_PLANO = TB_SIT_PLANO.CD_SIT_PLANO   LEFT OUTER JOIN TB_PERFIL_INVEST ON CS_PLANOS_VINC.CD_PERFIL_INVEST = TB_PERFIL_INVEST.CD_PERFIL_INVEST   INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_INSCRICAO = CS_PLANOS_VINC.NUM_INSCRICAO   INNER JOIN TB_CATEGORIA ON TB_CATEGORIA.CD_CATEGORIA = TB_SIT_PLANO.CD_CATEGORIA   WHERE  ( CS_FUNCIONARIO.CD_FUNDACAO = @CD_FUNDACAO )          AND ( CS_PLANOS_VINC.CD_FUNDACAO = @CD_FUNDACAO )          AND ( TB_PLANOS.CD_FUNDACAO = @CD_FUNDACAO )          AND ( CS_FUNCIONARIO.CD_EMPRESA = @CD_EMPRESA )          AND ( CS_FUNCIONARIO.NUM_MATRICULA = @NUM_MATRICULA )         AND ( TB_CATEGORIA.CD_CATEGORIA <> '2' )", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST, TB_CATEGORIA.CD_CATEGORIA, TB_CATEGORIA.DS_CATEGORIA, TB_SIT_PLANO.DS_SIT_PLANO, TB_PLANOS.DS_PLANO, TB_PLANOS.COD_CNPB, CS_PLANOS_VINC.* FROM CS_PLANOS_VINC INNER  JOIN TB_PLANOS  ON CS_PLANOS_VINC.CD_FUNDACAO=TB_PLANOS.CD_FUNDACAO AND CS_PLANOS_VINC.CD_PLANO=TB_PLANOS.CD_PLANO INNER  JOIN TB_SIT_PLANO  ON CS_PLANOS_VINC.CD_SIT_PLANO=TB_SIT_PLANO.CD_SIT_PLANO LEFT OUTER JOIN TB_PERFIL_INVEST  ON CS_PLANOS_VINC.CD_PERFIL_INVEST=TB_PERFIL_INVEST.CD_PERFIL_INVEST INNER  JOIN CS_FUNCIONARIO  ON CS_FUNCIONARIO.NUM_INSCRICAO=CS_PLANOS_VINC.NUM_INSCRICAO INNER  JOIN TB_CATEGORIA  ON TB_CATEGORIA.CD_CATEGORIA=TB_SIT_PLANO.CD_CATEGORIA WHERE (CS_FUNCIONARIO.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_PLANOS_VINC.CD_FUNDACAO=:CD_FUNDACAO) AND (TB_PLANOS.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_FUNCIONARIO.CD_EMPRESA=:CD_EMPRESA) AND (CS_FUNCIONARIO.NUM_MATRICULA=:NUM_MATRICULA) AND (TB_CATEGORIA.CD_CATEGORIA<>'2')", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PlanoVinculadoEntidade> BuscarPorFundacaoEmpresaMatriculaPermiteEmprestimo(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST,          TB_CATEGORIA.CD_CATEGORIA,          TB_CATEGORIA.DS_CATEGORIA,          TB_SIT_PLANO.DS_SIT_PLANO,         TB_PLANOS.DS_PLANO,         TB_PLANOS.COD_CNPB,         CS_PLANOS_VINC.*  FROM   CS_PLANOS_VINC   INNER JOIN TB_PLANOS ON CS_PLANOS_VINC.CD_FUNDACAO = TB_PLANOS.CD_FUNDACAO                       AND CS_PLANOS_VINC.CD_PLANO = TB_PLANOS.CD_PLANO   INNER JOIN TB_SIT_PLANO ON CS_PLANOS_VINC.CD_SIT_PLANO = TB_SIT_PLANO.CD_SIT_PLANO   LEFT OUTER JOIN TB_PERFIL_INVEST ON CS_PLANOS_VINC.CD_PERFIL_INVEST = TB_PERFIL_INVEST.CD_PERFIL_INVEST   INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_INSCRICAO = CS_PLANOS_VINC.NUM_INSCRICAO   INNER JOIN TB_CATEGORIA ON TB_CATEGORIA.CD_CATEGORIA = TB_SIT_PLANO.CD_CATEGORIA   INNER JOIN TB_EMPRESA_PLANOS ON TB_EMPRESA_PLANOS.CD_PLANO = CS_PLANOS_VINC.CD_PLANO  WHERE  ( CS_FUNCIONARIO.CD_FUNDACAO = @CD_FUNDACAO )          AND ( CS_PLANOS_VINC.CD_FUNDACAO = @CD_FUNDACAO )          AND ( TB_PLANOS.CD_FUNDACAO = @CD_FUNDACAO )          AND ( CS_FUNCIONARIO.CD_EMPRESA = @CD_EMPRESA )          AND ( CS_FUNCIONARIO.NUM_MATRICULA = @NUM_MATRICULA )         AND ( TB_CATEGORIA.CD_CATEGORIA <> '2' )         AND ( TB_CATEGORIA.PERMITE_EMPRESTIMO = 'S')         AND ( TB_EMPRESA_PLANOS.PERMITE_EMPRESTIMO = 'S' )         AND ( TB_EMPRESA_PLANOS.CD_EMPRESA = @CD_EMPRESA )", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST, TB_CATEGORIA.CD_CATEGORIA, TB_CATEGORIA.DS_CATEGORIA, TB_SIT_PLANO.DS_SIT_PLANO, TB_PLANOS.DS_PLANO, TB_PLANOS.COD_CNPB, CS_PLANOS_VINC.* FROM CS_PLANOS_VINC INNER  JOIN TB_PLANOS  ON CS_PLANOS_VINC.CD_FUNDACAO=TB_PLANOS.CD_FUNDACAO AND CS_PLANOS_VINC.CD_PLANO=TB_PLANOS.CD_PLANO INNER  JOIN TB_SIT_PLANO  ON CS_PLANOS_VINC.CD_SIT_PLANO=TB_SIT_PLANO.CD_SIT_PLANO LEFT OUTER JOIN TB_PERFIL_INVEST  ON CS_PLANOS_VINC.CD_PERFIL_INVEST=TB_PERFIL_INVEST.CD_PERFIL_INVEST INNER  JOIN CS_FUNCIONARIO  ON CS_FUNCIONARIO.NUM_INSCRICAO=CS_PLANOS_VINC.NUM_INSCRICAO INNER  JOIN TB_CATEGORIA  ON TB_CATEGORIA.CD_CATEGORIA=TB_SIT_PLANO.CD_CATEGORIA INNER  JOIN TB_EMPRESA_PLANOS  ON TB_EMPRESA_PLANOS.CD_PLANO=CS_PLANOS_VINC.CD_PLANO WHERE (CS_FUNCIONARIO.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_PLANOS_VINC.CD_FUNDACAO=:CD_FUNDACAO) AND (TB_PLANOS.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_FUNCIONARIO.CD_EMPRESA=:CD_EMPRESA) AND (CS_FUNCIONARIO.NUM_MATRICULA=:NUM_MATRICULA) AND (TB_CATEGORIA.CD_CATEGORIA<>'2') AND (TB_CATEGORIA.PERMITE_EMPRESTIMO='S') AND (TB_EMPRESA_PLANOS.PERMITE_EMPRESTIMO='S') AND (TB_EMPRESA_PLANOS.CD_EMPRESA=:CD_EMPRESA)", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual PlanoVinculadoEntidade BuscarPorFundacaoEmpresaMatriculaPlano(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST,          TB_CATEGORIA.CD_CATEGORIA,          TB_CATEGORIA.DS_CATEGORIA,          TB_SIT_PLANO.DS_SIT_PLANO,         TB_PLANOS.DS_PLANO,         TB_PLANOS.COD_CNPB,         CS_PLANOS_VINC.*  FROM   CS_PLANOS_VINC   INNER JOIN TB_PLANOS ON CS_PLANOS_VINC.CD_FUNDACAO = TB_PLANOS.CD_FUNDACAO                       AND CS_PLANOS_VINC.CD_PLANO = TB_PLANOS.CD_PLANO   INNER JOIN TB_SIT_PLANO ON CS_PLANOS_VINC.CD_SIT_PLANO = TB_SIT_PLANO.CD_SIT_PLANO   LEFT OUTER JOIN TB_PERFIL_INVEST ON CS_PLANOS_VINC.CD_PERFIL_INVEST = TB_PERFIL_INVEST.CD_PERFIL_INVEST   INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_INSCRICAO = CS_PLANOS_VINC.NUM_INSCRICAO   INNER JOIN TB_CATEGORIA ON TB_CATEGORIA.CD_CATEGORIA = TB_SIT_PLANO.CD_CATEGORIA   WHERE  ( CS_FUNCIONARIO.CD_FUNDACAO = @CD_FUNDACAO )          AND ( CS_PLANOS_VINC.CD_FUNDACAO = @CD_FUNDACAO )          AND ( TB_PLANOS.CD_FUNDACAO = @CD_FUNDACAO )          AND ( CS_FUNCIONARIO.CD_EMPRESA = @CD_EMPRESA )          AND ( CS_FUNCIONARIO.NUM_MATRICULA = @NUM_MATRICULA )         AND ( TB_CATEGORIA.CD_CATEGORIA <> '2' )         AND ( CS_PLANOS_VINC.CD_PLANO = @CD_PLANO )", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST, TB_CATEGORIA.CD_CATEGORIA, TB_CATEGORIA.DS_CATEGORIA, TB_SIT_PLANO.DS_SIT_PLANO, TB_PLANOS.DS_PLANO, TB_PLANOS.COD_CNPB, CS_PLANOS_VINC.* FROM CS_PLANOS_VINC INNER  JOIN TB_PLANOS  ON CS_PLANOS_VINC.CD_FUNDACAO=TB_PLANOS.CD_FUNDACAO AND CS_PLANOS_VINC.CD_PLANO=TB_PLANOS.CD_PLANO INNER  JOIN TB_SIT_PLANO  ON CS_PLANOS_VINC.CD_SIT_PLANO=TB_SIT_PLANO.CD_SIT_PLANO LEFT OUTER JOIN TB_PERFIL_INVEST  ON CS_PLANOS_VINC.CD_PERFIL_INVEST=TB_PERFIL_INVEST.CD_PERFIL_INVEST INNER  JOIN CS_FUNCIONARIO  ON CS_FUNCIONARIO.NUM_INSCRICAO=CS_PLANOS_VINC.NUM_INSCRICAO INNER  JOIN TB_CATEGORIA  ON TB_CATEGORIA.CD_CATEGORIA=TB_SIT_PLANO.CD_CATEGORIA WHERE (CS_FUNCIONARIO.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_PLANOS_VINC.CD_FUNDACAO=:CD_FUNDACAO) AND (TB_PLANOS.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_FUNCIONARIO.CD_EMPRESA=:CD_EMPRESA) AND (CS_FUNCIONARIO.NUM_MATRICULA=:NUM_MATRICULA) AND (TB_CATEGORIA.CD_CATEGORIA<>'2') AND (CS_PLANOS_VINC.CD_PLANO=:CD_PLANO)", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PlanoVinculadoEntidade> BuscarPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST,          TB_CATEGORIA.CD_CATEGORIA,          TB_CATEGORIA.DS_CATEGORIA,          TB_SIT_PLANO.DS_SIT_PLANO,         TB_PLANOS.DS_PLANO,         TB_PLANOS.COD_CNPB,         CS_PLANOS_VINC.*,  	   CS_FUNCIONARIO.CD_EMPRESA  FROM   CS_PLANOS_VINC   INNER JOIN TB_PLANOS ON CS_PLANOS_VINC.CD_FUNDACAO = TB_PLANOS.CD_FUNDACAO                       AND CS_PLANOS_VINC.CD_PLANO = TB_PLANOS.CD_PLANO   INNER JOIN TB_SIT_PLANO ON CS_PLANOS_VINC.CD_SIT_PLANO = TB_SIT_PLANO.CD_SIT_PLANO   LEFT OUTER JOIN TB_PERFIL_INVEST ON CS_PLANOS_VINC.CD_PERFIL_INVEST = TB_PERFIL_INVEST.CD_PERFIL_INVEST   INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_INSCRICAO = CS_PLANOS_VINC.NUM_INSCRICAO   INNER JOIN TB_CATEGORIA ON TB_CATEGORIA.CD_CATEGORIA = TB_SIT_PLANO.CD_CATEGORIA   WHERE  ( CS_FUNCIONARIO.CD_FUNDACAO = @CD_FUNDACAO )          AND ( CS_PLANOS_VINC.CD_FUNDACAO = @CD_FUNDACAO )          AND ( TB_PLANOS.CD_FUNDACAO = @CD_FUNDACAO )           AND ( CS_FUNCIONARIO.NUM_INSCRICAO = @NUM_INSCRICAO )", new { CD_FUNDACAO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST, TB_CATEGORIA.CD_CATEGORIA, TB_CATEGORIA.DS_CATEGORIA, TB_SIT_PLANO.DS_SIT_PLANO, TB_PLANOS.DS_PLANO, TB_PLANOS.COD_CNPB, CS_PLANOS_VINC.*, CS_FUNCIONARIO.CD_EMPRESA FROM CS_PLANOS_VINC INNER  JOIN TB_PLANOS  ON CS_PLANOS_VINC.CD_FUNDACAO=TB_PLANOS.CD_FUNDACAO AND CS_PLANOS_VINC.CD_PLANO=TB_PLANOS.CD_PLANO INNER  JOIN TB_SIT_PLANO  ON CS_PLANOS_VINC.CD_SIT_PLANO=TB_SIT_PLANO.CD_SIT_PLANO LEFT OUTER JOIN TB_PERFIL_INVEST  ON CS_PLANOS_VINC.CD_PERFIL_INVEST=TB_PERFIL_INVEST.CD_PERFIL_INVEST INNER  JOIN CS_FUNCIONARIO  ON CS_FUNCIONARIO.NUM_INSCRICAO=CS_PLANOS_VINC.NUM_INSCRICAO INNER  JOIN TB_CATEGORIA  ON TB_CATEGORIA.CD_CATEGORIA=TB_SIT_PLANO.CD_CATEGORIA WHERE (CS_FUNCIONARIO.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_PLANOS_VINC.CD_FUNDACAO=:CD_FUNDACAO) AND (TB_PLANOS.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_FUNCIONARIO.NUM_INSCRICAO=:NUM_INSCRICAO)", new { CD_FUNDACAO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PlanoVinculadoEntidade> BuscarPorFundacaoMatricula(string CD_FUNDACAO, string NUM_MATRICULA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST,          TB_CATEGORIA.CD_CATEGORIA,          TB_CATEGORIA.DS_CATEGORIA,          TB_SIT_PLANO.DS_SIT_PLANO,         TB_PLANOS.DS_PLANO,         TB_PLANOS.COD_CNPB,         CS_PLANOS_VINC.*,  	   CS_FUNCIONARIO.CD_EMPRESA  FROM   CS_PLANOS_VINC   INNER JOIN TB_PLANOS ON CS_PLANOS_VINC.CD_FUNDACAO = TB_PLANOS.CD_FUNDACAO                       AND CS_PLANOS_VINC.CD_PLANO = TB_PLANOS.CD_PLANO   INNER JOIN TB_SIT_PLANO ON CS_PLANOS_VINC.CD_SIT_PLANO = TB_SIT_PLANO.CD_SIT_PLANO   LEFT OUTER JOIN TB_PERFIL_INVEST ON CS_PLANOS_VINC.CD_PERFIL_INVEST = TB_PERFIL_INVEST.CD_PERFIL_INVEST   INNER JOIN CS_FUNCIONARIO ON CS_FUNCIONARIO.NUM_INSCRICAO = CS_PLANOS_VINC.NUM_INSCRICAO   INNER JOIN TB_CATEGORIA ON TB_CATEGORIA.CD_CATEGORIA = TB_SIT_PLANO.CD_CATEGORIA   WHERE  ( CS_FUNCIONARIO.CD_FUNDACAO = @CD_FUNDACAO )          AND ( CS_PLANOS_VINC.CD_FUNDACAO = @CD_FUNDACAO )          AND ( TB_PLANOS.CD_FUNDACAO = @CD_FUNDACAO )           AND ( CS_FUNCIONARIO.NUM_MATRICULA = @NUM_MATRICULA )         AND ( TB_CATEGORIA.CD_CATEGORIA <> '2' )", new { CD_FUNDACAO, NUM_MATRICULA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT TB_PERFIL_INVEST.DS_PERFIL_INVEST, TB_CATEGORIA.CD_CATEGORIA, TB_CATEGORIA.DS_CATEGORIA, TB_SIT_PLANO.DS_SIT_PLANO, TB_PLANOS.DS_PLANO, TB_PLANOS.COD_CNPB, CS_PLANOS_VINC.*, CS_FUNCIONARIO.CD_EMPRESA FROM CS_PLANOS_VINC INNER  JOIN TB_PLANOS  ON CS_PLANOS_VINC.CD_FUNDACAO=TB_PLANOS.CD_FUNDACAO AND CS_PLANOS_VINC.CD_PLANO=TB_PLANOS.CD_PLANO INNER  JOIN TB_SIT_PLANO  ON CS_PLANOS_VINC.CD_SIT_PLANO=TB_SIT_PLANO.CD_SIT_PLANO LEFT OUTER JOIN TB_PERFIL_INVEST  ON CS_PLANOS_VINC.CD_PERFIL_INVEST=TB_PERFIL_INVEST.CD_PERFIL_INVEST INNER  JOIN CS_FUNCIONARIO  ON CS_FUNCIONARIO.NUM_INSCRICAO=CS_PLANOS_VINC.NUM_INSCRICAO INNER  JOIN TB_CATEGORIA  ON TB_CATEGORIA.CD_CATEGORIA=TB_SIT_PLANO.CD_CATEGORIA WHERE (CS_FUNCIONARIO.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_PLANOS_VINC.CD_FUNDACAO=:CD_FUNDACAO) AND (TB_PLANOS.CD_FUNDACAO=:CD_FUNDACAO) AND (CS_FUNCIONARIO.NUM_MATRICULA=:NUM_MATRICULA) AND (TB_CATEGORIA.CD_CATEGORIA<>'2')", new { CD_FUNDACAO, NUM_MATRICULA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<PlanoVinculadoEntidade> FSFBuscarSaldado(string CD_FUNDACAO, string CD_PLANO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT PL.CD_PLANO,         ST.DS_SIT_PLANO,         PV.DT_INSC_PLANO,         HR.DT_INIC_VALIDADE,         HR2.VL_RENDA_FUNDACAO as VL_BENEF_SALDADO_INICIAL,         HR.VL_RENDA_FUNDACAO as VL_BENEF_SALDADO_ATUAL  FROM CS_PLANOS_VINC PV        INNER JOIN CS_FUNCIONARIO FN ON               FN.CD_FUNDACAO   = PV.CD_FUNDACAO AND              FN.NUM_INSCRICAO = PV.NUM_INSCRICAO        INNER JOIN TB_SIT_PLANO ST ON              ST.CD_SIT_PLANO = PV.CD_SIT_PLANO        INNER JOIN TB_PLANOS PL ON              PL.CD_FUNDACAO = PV.CD_FUNDACAO AND              PL.CD_PLANO    = PV.CD_PLANO        INNER JOIN GB_PROCESSOS_BENEFICIO PB ON              PB.CD_FUNDACAO   = PV.CD_FUNDACAO AND              PB.NUM_INSCRICAO = PV.NUM_INSCRICAO AND              PB.CD_PLANO = PV.CD_PLANO        INNER JOIN GB_HIST_RENDAS HR ON              HR.CD_FUNDACAO  = PB.CD_FUNDACAO AND              HR.CD_EMPRESA   = PB.CD_EMPRESA AND              HR.CD_PLANO     = PB.CD_PLANO AND              HR.CD_ESPECIE   = PB.CD_ESPECIE AND              HR.ANO_PROCESSO = PB.ANO_PROCESSO AND              HR.NUM_PROCESSO = PB.NUM_PROCESSO        INNER JOIN GB_HIST_RENDAS HR2 ON              HR2.CD_FUNDACAO  = PB.CD_FUNDACAO AND              HR2.CD_EMPRESA   = PB.CD_EMPRESA AND              HR2.CD_PLANO     = PB.CD_PLANO AND              HR2.CD_ESPECIE   = PB.CD_ESPECIE AND              HR2.ANO_PROCESSO = PB.ANO_PROCESSO AND              HR2.NUM_PROCESSO = PB.NUM_PROCESSO  WHERE PV.CD_FUNDACAO = @CD_FUNDACAO    AND PV.CD_PLANO = @CD_PLANO    AND PV.NUM_INSCRICAO = @NUM_INSCRICAO    AND HR.DT_INIC_VALIDADE = (SELECT MAX(HR2.DT_INIC_VALIDADE)                                 FROM GB_HIST_RENDAS HR2                                 WHERE HR2.CD_FUNDACAO  = PB.CD_FUNDACAO                                   AND    HR2.CD_EMPRESA   = PB.CD_EMPRESA                                   AND    HR2.CD_PLANO     = PB.CD_PLANO                                   AND    HR2.CD_ESPECIE   = PB.CD_ESPECIE                                   AND    HR2.ANO_PROCESSO = PB.ANO_PROCESSO                                   AND    HR2.NUM_PROCESSO = PB.NUM_PROCESSO)    AND HR2.DT_INIC_VALIDADE = (SELECT MIN(HR2.DT_INIC_VALIDADE)                                 FROM GB_HIST_RENDAS HR2                                 WHERE HR2.CD_FUNDACAO  = PB.CD_FUNDACAO                                   AND    HR2.CD_EMPRESA   = PB.CD_EMPRESA                                   AND    HR2.CD_PLANO     = PB.CD_PLANO                                   AND    HR2.CD_ESPECIE   = PB.CD_ESPECIE                                   AND    HR2.ANO_PROCESSO = PB.ANO_PROCESSO                                   AND    HR2.NUM_PROCESSO = PB.NUM_PROCESSO)", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<PlanoVinculadoEntidade>("SELECT PL.CD_PLANO, ST.DS_SIT_PLANO, PV.DT_INSC_PLANO, HR.DT_INIC_VALIDADE, HR2.VL_RENDA_FUNDACAO AS VL_BENEF_SALDADO_INICIAL, HR.VL_RENDA_FUNDACAO AS VL_BENEF_SALDADO_ATUAL FROM CS_PLANOS_VINC  PV  INNER  JOIN CS_FUNCIONARIO   FN  ON FN.CD_FUNDACAO=PV.CD_FUNDACAO AND FN.NUM_INSCRICAO=PV.NUM_INSCRICAO INNER  JOIN TB_SIT_PLANO   ST  ON ST.CD_SIT_PLANO=PV.CD_SIT_PLANO INNER  JOIN TB_PLANOS   PL  ON PL.CD_FUNDACAO=PV.CD_FUNDACAO AND PL.CD_PLANO=PV.CD_PLANO INNER  JOIN GB_PROCESSOS_BENEFICIO   PB  ON PB.CD_FUNDACAO=PV.CD_FUNDACAO AND PB.NUM_INSCRICAO=PV.NUM_INSCRICAO AND PB.CD_PLANO=PV.CD_PLANO INNER  JOIN GB_HIST_RENDAS   HR  ON HR.CD_FUNDACAO=PB.CD_FUNDACAO AND HR.CD_EMPRESA=PB.CD_EMPRESA AND HR.CD_PLANO=PB.CD_PLANO AND HR.CD_ESPECIE=PB.CD_ESPECIE AND HR.ANO_PROCESSO=PB.ANO_PROCESSO AND HR.NUM_PROCESSO=PB.NUM_PROCESSO INNER  JOIN GB_HIST_RENDAS   HR2  ON HR2.CD_FUNDACAO=PB.CD_FUNDACAO AND HR2.CD_EMPRESA=PB.CD_EMPRESA AND HR2.CD_PLANO=PB.CD_PLANO AND HR2.CD_ESPECIE=PB.CD_ESPECIE AND HR2.ANO_PROCESSO=PB.ANO_PROCESSO AND HR2.NUM_PROCESSO=PB.NUM_PROCESSO WHERE PV.CD_FUNDACAO=:CD_FUNDACAO AND PV.CD_PLANO=:CD_PLANO AND PV.NUM_INSCRICAO=:NUM_INSCRICAO AND HR.DT_INIC_VALIDADE=(SELECT MAX(HR2.DT_INIC_VALIDADE) FROM GB_HIST_RENDAS  HR2  WHERE HR2.CD_FUNDACAO=PB.CD_FUNDACAO AND HR2.CD_EMPRESA=PB.CD_EMPRESA AND HR2.CD_PLANO=PB.CD_PLANO AND HR2.CD_ESPECIE=PB.CD_ESPECIE AND HR2.ANO_PROCESSO=PB.ANO_PROCESSO AND HR2.NUM_PROCESSO=PB.NUM_PROCESSO) AND HR2.DT_INIC_VALIDADE=(SELECT MIN(HR2.DT_INIC_VALIDADE) FROM GB_HIST_RENDAS  HR2  WHERE HR2.CD_FUNDACAO=PB.CD_FUNDACAO AND HR2.CD_EMPRESA=PB.CD_EMPRESA AND HR2.CD_PLANO=PB.CD_PLANO AND HR2.CD_ESPECIE=PB.CD_ESPECIE AND HR2.ANO_PROCESSO=PB.ANO_PROCESSO AND HR2.NUM_PROCESSO=PB.NUM_PROCESSO)", new { CD_FUNDACAO, CD_PLANO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual int MigradoPlano1(string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT COUNT(CD_SIT_PLANO)  FROM CS_PLANOS_VINC  WHERE NUM_INSCRICAO = @NUM_INSCRICAO    AND CD_PLANO = '0001'    AND CD_SIT_PLANO = '09'", new { NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<int>("SELECT COUNT(CD_SIT_PLANO) FROM CS_PLANOS_VINC WHERE NUM_INSCRICAO=:NUM_INSCRICAO AND CD_PLANO='0001' AND CD_SIT_PLANO='09'", new { NUM_INSCRICAO });
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
