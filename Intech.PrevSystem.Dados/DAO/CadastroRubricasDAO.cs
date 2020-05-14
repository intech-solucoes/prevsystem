using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class CadastroRubricasDAO : BaseDAO<CadastroRubricasEntidade>
	{
		public virtual List<CadastroRubricasEntidade> BuscarPorFundacaoInscricaoEmpresa(string CD_FUNDACAO, string NUM_INSCRICAO, string CD_EMPRESA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<CadastroRubricasEntidade>("SELECT *  FROM CC_CADASTRO_RUBRICAS  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO    AND CD_EMPRESA = @CD_EMPRESA", new { CD_FUNDACAO, NUM_INSCRICAO, CD_EMPRESA }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<CadastroRubricasEntidade>("SELECT * FROM CC_CADASTRO_RUBRICAS WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_EMPRESA=:CD_EMPRESA", new { CD_FUNDACAO, NUM_INSCRICAO, CD_EMPRESA }).ToList();
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
