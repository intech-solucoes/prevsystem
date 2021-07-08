using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class IndiceValoresDAO : BaseDAO<IndiceValoresEntidade>
	{
		public IndiceValoresDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<IndiceValoresEntidade> BuscarCotaPorPlano(string CD_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<IndiceValoresEntidade>("SELECT * FROM TB_IND_VALORES WHERE COD_IND = (SELECT DISTINCT IND_RESERVA_POUP                     FROM TB_EMPRESA_PLANOS                    WHERE CD_PLANO = @CD_PLANO)   AND DT_IND = (SELECT MAX(IV2.DT_IND)                    FROM TB_IND_VALORES IV2                   WHERE IV2.COD_IND = TB_IND_VALORES.COD_IND)", new { CD_PLANO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<IndiceValoresEntidade>("", new { CD_PLANO }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<IndiceValoresEntidade> BuscarPorCdEmpresaPlano(string CD_EMPRESA, string CD_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<IndiceValoresEntidade>("SELECT *   FROM TB_IND_VALORES IV  WHERE IV.COD_IND = (SELECT IND_RESERVA_POUP                        FROM TB_EMPRESA_PLANOS                       WHERE CD_EMPRESA = @CD_EMPRESA                         AND CD_PLANO = @CD_PLANO) ORDER BY DT_IND DESC", new { CD_EMPRESA, CD_PLANO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<IndiceValoresEntidade>("SELECT * FROM TB_IND_VALORES  IV  WHERE IV.COD_IND=(SELECT IND_RESERVA_POUP FROM TB_EMPRESA_PLANOS WHERE CD_EMPRESA=:CD_EMPRESA AND CD_PLANO=:CD_PLANO) ORDER BY DT_IND DESC", new { CD_EMPRESA, CD_PLANO }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<IndiceValoresEntidade> BuscarPorCdEmpresaPlanoReferencia(string CD_EMPRESA, string CD_PLANO, string DT_REFERENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<IndiceValoresEntidade>("SELECT *   FROM TB_IND_VALORES IV  WHERE IV.COD_IND = (SELECT IND_RESERVA_POUP                         FROM TB_EMPRESA_PLANOS                        WHERE CD_EMPRESA = @CD_EMPRESA                         AND CD_PLANO = @CD_PLANO)   AND IV.DT_IND <= @DT_REFERENCIA ORDER BY DT_IND DESC", new { CD_EMPRESA, CD_PLANO, DT_REFERENCIA }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<IndiceValoresEntidade>("SELECT * FROM TB_IND_VALORES  IV  WHERE IV.COD_IND=(SELECT IND_RESERVA_POUP FROM TB_EMPRESA_PLANOS WHERE CD_EMPRESA=:CD_EMPRESA AND CD_PLANO=:CD_PLANO) AND IV.DT_IND<=:DT_REFERENCIA ORDER BY DT_IND DESC", new { CD_EMPRESA, CD_PLANO, DT_REFERENCIA }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<IndiceValoresEntidade> BuscarPorCodigo(string COD_IND)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<IndiceValoresEntidade>("SELECT * FROM TB_IND_VALORES WHERE COD_IND = @COD_IND ORDER BY DT_IND DESC", new { COD_IND }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<IndiceValoresEntidade>("SELECT * FROM TB_IND_VALORES WHERE COD_IND=:COD_IND ORDER BY DT_IND DESC", new { COD_IND }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual IndiceValoresEntidade BuscarReservaPoupanca(DateTime DT_REFERENCIA)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<IndiceValoresEntidade>("SELECT DISTINCT IV.*   FROM TB_IND_VALORES IV  INNER JOIN TB_EMPRESA_PLANOS EP ON IV.COD_IND = EP.IND_RESERVA_POUP WHERE EP.CD_FUNDACAO = '01'   AND EP.CD_PLANO = '0002'   AND IV.DT_IND = @DT_REFERENCIA", new { DT_REFERENCIA }, Transaction);
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<IndiceValoresEntidade>("SELECT DISTINCT IV.* FROM TB_IND_VALORES  IV  INNER  JOIN TB_EMPRESA_PLANOS   EP  ON IV.COD_IND=EP.IND_RESERVA_POUP WHERE EP.CD_FUNDACAO='01' AND EP.CD_PLANO='0002' AND IV.DT_IND=:DT_REFERENCIA", new { DT_REFERENCIA }, Transaction);
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<IndiceValoresEntidade> BuscarUltimoPorCodigo(string COD_IND)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<IndiceValoresEntidade>("SELECT *   FROM TB_IND_VALORES V  WHERE COD_IND = @COD_IND   AND V.DT_IND = (SELECT MAX(DT_IND)                      FROM TB_IND_VALORES                     WHERE COD_IND = V.COD_IND)", new { COD_IND }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<IndiceValoresEntidade>("SELECT * FROM TB_IND_VALORES  V  WHERE COD_IND=:COD_IND AND V.DT_IND=(SELECT MAX(DT_IND) FROM TB_IND_VALORES WHERE COD_IND=V.COD_IND)", new { COD_IND }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

		public virtual List<IndiceValoresEntidade> BuscarUltimoPorCodigoDataAtual(string COD_IND, DateTime DATA_ATUAL)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<IndiceValoresEntidade>("SELECT *  FROM TB_IND_VALORES  WHERE COD_IND = @COD_IND   AND DT_IND = (SELECT MAX(ID2.DT_IND)                   FROM TB_IND_VALORES ID2                  WHERE ID2.COD_IND = TB_IND_VALORES.COD_IND                    AND ID2.DT_IND <= @DATA_ATUAL)", new { COD_IND, DATA_ATUAL }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<IndiceValoresEntidade>("SELECT * FROM TB_IND_VALORES WHERE COD_IND=:COD_IND AND DT_IND=(SELECT MAX(ID2.DT_IND) FROM TB_IND_VALORES  ID2  WHERE ID2.COD_IND=TB_IND_VALORES.COD_IND AND ID2.DT_IND<=:DATA_ATUAL)", new { COD_IND, DATA_ATUAL }, Transaction).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				if(Transaction == null)
					Conexao.Close();
			}
		}

	}
}