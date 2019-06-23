#region Usings
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
    public abstract class DependenteDAO : BaseDAO<DependenteEntidade>
    {
        
		public virtual IEnumerable<DependenteEntidade> BuscarPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *,  TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO    FROM CS_DEPENDENTE  INNER JOIN TB_GRAU_PARENTESCO ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO = CS_DEPENDENTE.CD_GRAU_PARENTESCO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *, TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO FROM CS_DEPENDENTE INNER  JOIN TB_GRAU_PARENTESCO  ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO=CS_DEPENDENTE.CD_GRAU_PARENTESCO WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO", new { CD_FUNDACAO, NUM_INSCRICAO });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual IEnumerable<DependenteEntidade> BuscarPorFundacaoInscricaoPlano(string CD_FUNDACAO, string NUM_INSCRICAO, string CD_PLANO)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *,  TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO    FROM CS_DEPENDENTE  INNER JOIN TB_GRAU_PARENTESCO ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO = CS_DEPENDENTE.CD_GRAU_PARENTESCO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO    AND CD_PLANO = @CD_PLANO", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *, TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO FROM CS_DEPENDENTE INNER  JOIN TB_GRAU_PARENTESCO  ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO=CS_DEPENDENTE.CD_GRAU_PARENTESCO WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_PLANO=:CD_PLANO", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO });
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
