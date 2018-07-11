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
    public abstract class FichaFinanceiraAssistidoDAO : BaseDAO<FichaFinanceiraAssistidoEntidade>
    {
        
		public virtual IEnumerable<FichaFinanceiraAssistidoEntidade> BuscarDatas(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, DateTime DT_REFERENCIA)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<FichaFinanceiraAssistidoEntidade>("SELECT DT_REFERENCIA, CD_TIPO_FOLHA FROM GB_FICHA_FINANC_ASSISTIDO INNER JOIN GB_RECEBEDOR_BENEFICIO ON GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR = GB_RECEBEDOR_BENEFICIO.SEQ_RECEBEDOR WHERE GB_FICHA_FINANC_ASSISTIDO.CD_FUNDACAO = @CD_FUNDACAO   AND GB_RECEBEDOR_BENEFICIO.CD_FUNDACAO = @CD_FUNDACAO   AND GB_FICHA_FINANC_ASSISTIDO.CD_EMPRESA = @CD_EMPRESA   AND GB_RECEBEDOR_BENEFICIO.CD_EMPRESA = @CD_EMPRESA   AND GB_FICHA_FINANC_ASSISTIDO.CD_PLANO = @CD_PLANO   AND NUM_MATRICULA = @NUM_MATRICULA   AND DT_REFERENCIA >= @DT_REFERENCIA GROUP BY DT_REFERENCIA, CD_TIPO_FOLHA ORDER BY DT_REFERENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_REFERENCIA });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<FichaFinanceiraAssistidoEntidade>("SELECT DT_REFERENCIA, CD_TIPO_FOLHA FROM GB_FICHA_FINANC_ASSISTIDO INNER  JOIN GB_RECEBEDOR_BENEFICIO  ON GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR=GB_RECEBEDOR_BENEFICIO.SEQ_RECEBEDOR WHERE GB_FICHA_FINANC_ASSISTIDO.CD_FUNDACAO=:CD_FUNDACAO AND GB_RECEBEDOR_BENEFICIO.CD_FUNDACAO=:CD_FUNDACAO AND GB_FICHA_FINANC_ASSISTIDO.CD_EMPRESA=:CD_EMPRESA AND GB_RECEBEDOR_BENEFICIO.CD_EMPRESA=:CD_EMPRESA AND GB_FICHA_FINANC_ASSISTIDO.CD_PLANO=:CD_PLANO AND NUM_MATRICULA=:NUM_MATRICULA AND DT_REFERENCIA>=:DT_REFERENCIA GROUP BY DT_REFERENCIA, CD_TIPO_FOLHA ORDER BY DT_REFERENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_REFERENCIA });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual IEnumerable<FichaFinanceiraAssistidoEntidade> BuscarDatasPorRecebedor(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, int SEQ_RECEBEDOR, string CD_PLANO, DateTime DT_REFERENCIA)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<FichaFinanceiraAssistidoEntidade>("SELECT DT_REFERENCIA, CD_TIPO_FOLHA FROM GB_FICHA_FINANC_ASSISTIDO INNER JOIN GB_RECEBEDOR_BENEFICIO ON GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR = GB_RECEBEDOR_BENEFICIO.SEQ_RECEBEDOR WHERE GB_FICHA_FINANC_ASSISTIDO.CD_FUNDACAO = @CD_FUNDACAO   AND GB_RECEBEDOR_BENEFICIO.CD_FUNDACAO = @CD_FUNDACAO   AND GB_FICHA_FINANC_ASSISTIDO.CD_EMPRESA = @CD_EMPRESA   AND GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR = @SEQ_RECEBEDOR   AND GB_RECEBEDOR_BENEFICIO.CD_EMPRESA = @CD_EMPRESA   AND GB_FICHA_FINANC_ASSISTIDO.CD_PLANO = @CD_PLANO   AND NUM_MATRICULA = @NUM_MATRICULA   AND DT_REFERENCIA >= @DT_REFERENCIA GROUP BY DT_REFERENCIA, CD_TIPO_FOLHA ORDER BY DT_REFERENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SEQ_RECEBEDOR, CD_PLANO, DT_REFERENCIA });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<FichaFinanceiraAssistidoEntidade>("SELECT DT_REFERENCIA, CD_TIPO_FOLHA FROM GB_FICHA_FINANC_ASSISTIDO INNER  JOIN GB_RECEBEDOR_BENEFICIO  ON GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR=GB_RECEBEDOR_BENEFICIO.SEQ_RECEBEDOR WHERE GB_FICHA_FINANC_ASSISTIDO.CD_FUNDACAO=:CD_FUNDACAO AND GB_RECEBEDOR_BENEFICIO.CD_FUNDACAO=:CD_FUNDACAO AND GB_FICHA_FINANC_ASSISTIDO.CD_EMPRESA=:CD_EMPRESA AND GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR=:SEQ_RECEBEDOR AND GB_RECEBEDOR_BENEFICIO.CD_EMPRESA=:CD_EMPRESA AND GB_FICHA_FINANC_ASSISTIDO.CD_PLANO=:CD_PLANO AND NUM_MATRICULA=:NUM_MATRICULA AND DT_REFERENCIA>=:DT_REFERENCIA GROUP BY DT_REFERENCIA, CD_TIPO_FOLHA ORDER BY DT_REFERENCIA DESC", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SEQ_RECEBEDOR, CD_PLANO, DT_REFERENCIA });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual IEnumerable<FichaFinanceiraAssistidoEntidade> BuscarPorFundacaoEmpresaMatriculaPlanoReferencia(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, DateTime DT_REFERENCIA, string CD_TIPO_FOLHA)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<FichaFinanceiraAssistidoEntidade>("SELECT GB_FICHA_FINANC_ASSISTIDO.*,        GB_RUBRICAS_PREVIDENCIAL.DS_RUBRICA,        GB_RUBRICAS_PREVIDENCIAL.RUBRICA_PROV_DESC,        GB_RUBRICAS_PREVIDENCIAL.ID_RUB_SUPLEMENTACAO FROM GB_FICHA_FINANC_ASSISTIDO INNER JOIN GB_RECEBEDOR_BENEFICIO ON GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR = GB_RECEBEDOR_BENEFICIO.SEQ_RECEBEDOR INNER JOIN GB_RUBRICAS_PREVIDENCIAL ON GB_RUBRICAS_PREVIDENCIAL.CD_RUBRICA = GB_FICHA_FINANC_ASSISTIDO.CD_RUBRICA WHERE GB_FICHA_FINANC_ASSISTIDO.CD_FUNDACAO = @CD_FUNDACAO   AND GB_RECEBEDOR_BENEFICIO.CD_FUNDACAO = @CD_FUNDACAO   AND GB_FICHA_FINANC_ASSISTIDO.CD_EMPRESA = @CD_EMPRESA   AND GB_RECEBEDOR_BENEFICIO.CD_EMPRESA = @CD_EMPRESA   AND GB_FICHA_FINANC_ASSISTIDO.CD_PLANO = @CD_PLANO   AND GB_RECEBEDOR_BENEFICIO.NUM_MATRICULA = @NUM_MATRICULA   AND GB_RUBRICAS_PREVIDENCIAL.EMITE_FOLHA = 'S'   AND GB_RUBRICAS_PREVIDENCIAL.INCID_LIQUIDO = 'S'   AND GB_FICHA_FINANC_ASSISTIDO.DT_REFERENCIA = @DT_REFERENCIA   AND GB_FICHA_FINANC_ASSISTIDO.CD_TIPO_FOLHA = @CD_TIPO_FOLHA", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_REFERENCIA, CD_TIPO_FOLHA });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<FichaFinanceiraAssistidoEntidade>("SELECT GB_FICHA_FINANC_ASSISTIDO.*, GB_RUBRICAS_PREVIDENCIAL.DS_RUBRICA, GB_RUBRICAS_PREVIDENCIAL.RUBRICA_PROV_DESC, GB_RUBRICAS_PREVIDENCIAL.ID_RUB_SUPLEMENTACAO FROM GB_FICHA_FINANC_ASSISTIDO INNER  JOIN GB_RECEBEDOR_BENEFICIO  ON GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR=GB_RECEBEDOR_BENEFICIO.SEQ_RECEBEDOR INNER  JOIN GB_RUBRICAS_PREVIDENCIAL  ON GB_RUBRICAS_PREVIDENCIAL.CD_RUBRICA=GB_FICHA_FINANC_ASSISTIDO.CD_RUBRICA WHERE GB_FICHA_FINANC_ASSISTIDO.CD_FUNDACAO=:CD_FUNDACAO AND GB_RECEBEDOR_BENEFICIO.CD_FUNDACAO=:CD_FUNDACAO AND GB_FICHA_FINANC_ASSISTIDO.CD_EMPRESA=:CD_EMPRESA AND GB_RECEBEDOR_BENEFICIO.CD_EMPRESA=:CD_EMPRESA AND GB_FICHA_FINANC_ASSISTIDO.CD_PLANO=:CD_PLANO AND GB_RECEBEDOR_BENEFICIO.NUM_MATRICULA=:NUM_MATRICULA AND GB_RUBRICAS_PREVIDENCIAL.EMITE_FOLHA='S' AND GB_RUBRICAS_PREVIDENCIAL.INCID_LIQUIDO='S' AND GB_FICHA_FINANC_ASSISTIDO.DT_REFERENCIA=:DT_REFERENCIA AND GB_FICHA_FINANC_ASSISTIDO.CD_TIPO_FOLHA=:CD_TIPO_FOLHA", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_REFERENCIA, CD_TIPO_FOLHA });
			else
				throw new Exception("Provider não suportado!");
		}
		public virtual IEnumerable<FichaFinanceiraAssistidoEntidade> BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaRecebedor(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, int SEQ_RECEBEDOR, string CD_PLANO, DateTime DT_REFERENCIA, string CD_TIPO_FOLHA)
		{
			if(AppSettings.IS_SQL_SERVER_PROVIDER)
				return Conexao.Query<FichaFinanceiraAssistidoEntidade>("SELECT GB_FICHA_FINANC_ASSISTIDO.*,        GB_RUBRICAS_PREVIDENCIAL.DS_RUBRICA,        GB_RUBRICAS_PREVIDENCIAL.RUBRICA_PROV_DESC,        GB_RUBRICAS_PREVIDENCIAL.ID_RUB_SUPLEMENTACAO FROM GB_FICHA_FINANC_ASSISTIDO INNER JOIN GB_RECEBEDOR_BENEFICIO ON GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR = GB_RECEBEDOR_BENEFICIO.SEQ_RECEBEDOR INNER JOIN GB_RUBRICAS_PREVIDENCIAL ON GB_RUBRICAS_PREVIDENCIAL.CD_RUBRICA = GB_FICHA_FINANC_ASSISTIDO.CD_RUBRICA WHERE GB_FICHA_FINANC_ASSISTIDO.CD_FUNDACAO = @CD_FUNDACAO   AND GB_RECEBEDOR_BENEFICIO.CD_FUNDACAO = @CD_FUNDACAO   AND GB_FICHA_FINANC_ASSISTIDO.CD_EMPRESA = @CD_EMPRESA   AND GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR = @SEQ_RECEBEDOR   AND GB_RECEBEDOR_BENEFICIO.CD_EMPRESA = @CD_EMPRESA   AND GB_FICHA_FINANC_ASSISTIDO.CD_PLANO = @CD_PLANO   AND GB_RECEBEDOR_BENEFICIO.NUM_MATRICULA = @NUM_MATRICULA   AND GB_RUBRICAS_PREVIDENCIAL.EMITE_FOLHA = 'S'   AND GB_RUBRICAS_PREVIDENCIAL.INCID_LIQUIDO = 'S'   AND GB_FICHA_FINANC_ASSISTIDO.DT_REFERENCIA = @DT_REFERENCIA   AND GB_FICHA_FINANC_ASSISTIDO.CD_TIPO_FOLHA = @CD_TIPO_FOLHA", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SEQ_RECEBEDOR, CD_PLANO, DT_REFERENCIA, CD_TIPO_FOLHA });
			else if(AppSettings.IS_ORACLE_PROVIDER)
				return Conexao.Query<FichaFinanceiraAssistidoEntidade>("SELECT GB_FICHA_FINANC_ASSISTIDO.*, GB_RUBRICAS_PREVIDENCIAL.DS_RUBRICA, GB_RUBRICAS_PREVIDENCIAL.RUBRICA_PROV_DESC, GB_RUBRICAS_PREVIDENCIAL.ID_RUB_SUPLEMENTACAO FROM GB_FICHA_FINANC_ASSISTIDO INNER  JOIN GB_RECEBEDOR_BENEFICIO  ON GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR=GB_RECEBEDOR_BENEFICIO.SEQ_RECEBEDOR INNER  JOIN GB_RUBRICAS_PREVIDENCIAL  ON GB_RUBRICAS_PREVIDENCIAL.CD_RUBRICA=GB_FICHA_FINANC_ASSISTIDO.CD_RUBRICA WHERE GB_FICHA_FINANC_ASSISTIDO.CD_FUNDACAO=:CD_FUNDACAO AND GB_RECEBEDOR_BENEFICIO.CD_FUNDACAO=:CD_FUNDACAO AND GB_FICHA_FINANC_ASSISTIDO.CD_EMPRESA=:CD_EMPRESA AND GB_FICHA_FINANC_ASSISTIDO.SEQ_RECEBEDOR=:SEQ_RECEBEDOR AND GB_RECEBEDOR_BENEFICIO.CD_EMPRESA=:CD_EMPRESA AND GB_FICHA_FINANC_ASSISTIDO.CD_PLANO=:CD_PLANO AND GB_RECEBEDOR_BENEFICIO.NUM_MATRICULA=:NUM_MATRICULA AND GB_RUBRICAS_PREVIDENCIAL.EMITE_FOLHA='S' AND GB_RUBRICAS_PREVIDENCIAL.INCID_LIQUIDO='S' AND GB_FICHA_FINANC_ASSISTIDO.DT_REFERENCIA=:DT_REFERENCIA AND GB_FICHA_FINANC_ASSISTIDO.CD_TIPO_FOLHA=:CD_TIPO_FOLHA", new { CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SEQ_RECEBEDOR, CD_PLANO, DT_REFERENCIA, CD_TIPO_FOLHA });
			else
				throw new Exception("Provider não suportado!");
		}
    }
}
