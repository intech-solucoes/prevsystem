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
    public abstract class FaixaValorContribDAO : BaseDAO<FaixaValorContribEntidade>
    {
        
		public virtual IEnumerable<FaixaValorContribEntidade> BuscarPorFundacaoPlanoTipoContribMantenedora(string CD_FUNDACAO, string CD_PLANO, string CD_TIPO_CONTRIBUICAO, string CD_MANTENEDORA)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<FaixaValorContribEntidade>("SELECT * FROM  TB_FAIXA_VALOR_CONTRIB WHERE CD_FUNDACAO = @CD_FUNDACAO   AND CD_PLANO = @CD_PLANO   AND CD_TIPO_CONTRIBUICAO = @CD_TIPO_CONTRIBUICAO   AND CD_MANTENEDORA = @CD_MANTENEDORA", new { CD_FUNDACAO, CD_PLANO, CD_TIPO_CONTRIBUICAO, CD_MANTENEDORA });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<FaixaValorContribEntidade>("SELECT * FROM TB_FAIXA_VALOR_CONTRIB WHERE CD_FUNDACAO=:CD_FUNDACAO AND CD_PLANO=:CD_PLANO AND CD_TIPO_CONTRIBUICAO=:CD_TIPO_CONTRIBUICAO AND CD_MANTENEDORA=:CD_MANTENEDORA", new { CD_FUNDACAO, CD_PLANO, CD_TIPO_CONTRIBUICAO, CD_MANTENEDORA });
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
