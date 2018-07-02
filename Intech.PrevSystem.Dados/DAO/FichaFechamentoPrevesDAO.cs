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
    public abstract class FichaFechamentoPrevesDAO : BaseDAO<FichaFechamentoPrevesEntidade>
    {
		public virtual IEnumerable<FichaFechamentoPrevesEntidade> BuscarRelatorioPorFundacaoEmpresaPlanoInscricaoReferencia(string CD_FUNDACAO, string CD_EMPRESA, string CD_PLANO, string NUM_INSCRICAO, string DT_INICIO, string DT_FIM)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<FichaFechamentoPrevesEntidade>("SELECT FF.*, 	LO.DS_LOTACAO FROM CC_FICHA_FECHAMENTO_PREVES FF INNER JOIN CS_FUNCIONARIO FUNC ON FUNC.NUM_INSCRICAO = FF.NUM_INSCRICAO INNER JOIN TB_LOTACAO LO ON LO.CD_LOTACAO = FUNC.CD_LOTACAO 						AND LO.CD_EMPRESA = FUNC.CD_EMPRESA WHERE FF.CD_FUNDACAO = @CD_FUNDACAO   AND FF.CD_EMPRESA = @CD_EMPRESA   AND FF.CD_PLANO = @CD_PLANO   AND FF.NUM_INSCRICAO = @NUM_INSCRICAO   AND ('' + FF.ANO_REF + FF.MES_REF BETWEEN @DT_INICIO AND @DT_FIM)   AND FF.IND_ANALITICO_SINTETICO = 'S' ORDER BY FF.CD_FUNDACAO,          FF.CD_EMPRESA,          FF.NUM_INSCRICAO,          FF.ANO_REF,          FF.MES_REF,          FF.ANO_COMP,          FF.MES_COMP,          FF.NUM_SEQ,          FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, DT_INICIO, DT_FIM });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<FichaFechamentoPrevesEntidade>("SELECT FF.*, LO.DS_LOTACAO FROM CC_FICHA_FECHAMENTO_PREVES  FF  INNER  JOIN CS_FUNCIONARIO   FUNC  ON FUNC.NUM_INSCRICAO=FF.NUM_INSCRICAO INNER  JOIN TB_LOTACAO   LO  ON LO.CD_LOTACAO=FUNC.CD_LOTACAO AND LO.CD_EMPRESA=FUNC.CD_EMPRESA WHERE FF.CD_FUNDACAO=:CD_FUNDACAO AND FF.CD_EMPRESA=:CD_EMPRESA AND FF.CD_PLANO=:CD_PLANO AND FF.NUM_INSCRICAO=:NUM_INSCRICAO AND ('' || FF.ANO_REF || FF.MES_REF BETWEEN :DT_INICIO AND :DT_FIM) AND FF.IND_ANALITICO_SINTETICO='S' ORDER BY FF.CD_FUNDACAO, FF.CD_EMPRESA, FF.NUM_INSCRICAO, FF.ANO_REF, FF.MES_REF, FF.ANO_COMP, FF.MES_COMP, FF.NUM_SEQ, FF.IND_TIPO", new { CD_FUNDACAO, CD_EMPRESA, CD_PLANO, NUM_INSCRICAO, DT_INICIO, DT_FIM });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
