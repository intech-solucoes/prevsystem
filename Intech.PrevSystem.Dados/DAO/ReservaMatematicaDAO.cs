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
	public abstract class ReservaMatematicaDAO : BaseDAO<ReservaMatematicaEntidade>
	{
		public ReservaMatematicaDAO (IDbTransaction tx = null) : base(tx) { }

		public virtual List<ReservaMatematicaEntidade> BuscarPorUltimoAnoByFundacaoInscricaoPlano(string CD_FUNDACAO, string NUM_INSCRICAO, string CD_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<ReservaMatematicaEntidade>("SELECT CD_FUNDACAO,        NUM_INSCRICAO,        CD_PLANO,        MES_REF,        ANO_REF,        SEQ_CONTRIBUICAO,        VL_RESERVA,        CT_RP_RESERVA,        CT_FD_RESERVA,        CT_RM_RESERVA FROM   CC_RESERVA_MATEMATICA WHERE  CD_FUNDACAO = @CD_FUNDACAO        AND NUM_INSCRICAO = @NUM_INSCRICAO        AND CD_PLANO = @CD_PLANO        AND ANO_REF = (SELECT MAX(ANO_REF) AS ANO_REF_AUX                       FROM   CC_RESERVA_MATEMATICA                       WHERE  CD_FUNDACAO = @CD_FUNDACAO                              AND NUM_INSCRICAO = @NUM_INSCRICAO                              AND CD_PLANO = @CD_PLANO)", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO }, Transaction).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<ReservaMatematicaEntidade>("SELECT CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO, MES_REF, ANO_REF, SEQ_CONTRIBUICAO, VL_RESERVA, CT_RP_RESERVA, CT_FD_RESERVA, CT_RM_RESERVA FROM CC_RESERVA_MATEMATICA WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_PLANO=:CD_PLANO AND ANO_REF=(SELECT MAX(ANO_REF) AS ANO_REF_AUX FROM CC_RESERVA_MATEMATICA WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_PLANO=:CD_PLANO)", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO }, Transaction).ToList();
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