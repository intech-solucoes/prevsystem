using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class EntidadeDAO : BaseDAO<EntidadeEntidade>
	{
		public virtual void AtualizarEntidade(int COD_ENTID, string NOME_ENTID, string CPF_CGC, string END_ENTID, string NR_END_ENTID, string COMP_END_ENTID, string BAIRRO_ENTID, string CID_ENTID, string UF_ENTID, string CEP_ENTID, string NUM_BANCO, string NUM_AGENCIA, string NUM_CONTA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("UPDATE EE_ENTIDADE  SET NOME_ENTID = @NOME_ENTID, CPF_CGC = @CPF_CGC, END_ENTID = @END_ENTID, NR_END_ENTID = @NR_END_ENTID, COMP_END_ENTID = @COMP_END_ENTID, BAIRRO_ENTID = @BAIRRO_ENTID,   CID_ENTID = @CID_ENTID, UF_ENTID = @UF_ENTID, CEP_ENTID = @CEP_ENTID, NUM_BANCO =@NUM_BANCO, NUM_AGENCIA = @NUM_AGENCIA, NUM_CONTA = @NUM_CONTA  WHERE COD_ENTID = @COD_ENTID", new { COD_ENTID, NOME_ENTID, CPF_CGC, END_ENTID, NR_END_ENTID, COMP_END_ENTID, BAIRRO_ENTID, CID_ENTID, UF_ENTID, CEP_ENTID, NUM_BANCO, NUM_AGENCIA, NUM_CONTA });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("UPDATE EE_ENTIDADE SET NOME_ENTID=:NOME_ENTID, CPF_CGC=:CPF_CGC, END_ENTID=:END_ENTID, NR_END_ENTID=:NR_END_ENTID, COMP_END_ENTID=:COMP_END_ENTID, BAIRRO_ENTID=:BAIRRO_ENTID, CID_ENTID=:CID_ENTID, UF_ENTID=:UF_ENTID, CEP_ENTID=:CEP_ENTID, NUM_BANCO=:NUM_BANCO, NUM_AGENCIA=:NUM_AGENCIA, NUM_CONTA=:NUM_CONTA WHERE COD_ENTID=:COD_ENTID", new { COD_ENTID, NOME_ENTID, CPF_CGC, END_ENTID, NR_END_ENTID, COMP_END_ENTID, BAIRRO_ENTID, CID_ENTID, UF_ENTID, CEP_ENTID, NUM_BANCO, NUM_AGENCIA, NUM_CONTA });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual EntidadeEntidade BuscarPorCodEntid(string COD_ENTID)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<EntidadeEntidade>("SELECT *  FROM EE_ENTIDADE  WHERE COD_ENTID = @COD_ENTID", new { COD_ENTID });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<EntidadeEntidade>("SELECT * FROM EE_ENTIDADE WHERE COD_ENTID=:COD_ENTID", new { COD_ENTID });
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
