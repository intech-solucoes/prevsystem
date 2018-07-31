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
    public abstract class RecebedorBeneficioDAO : BaseDAO<RecebedorBeneficioEntidade>
    {
        
		public virtual RecebedorBeneficioEntidade BuscarPensionistaPorCpf(string CPF)
		{
			try
			{
				if(AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.QuerySingleOrDefault<RecebedorBeneficioEntidade>("SELECT RB.* FROM GB_RECEBEDOR_BENEFICIO RB     INNER JOIN EE_ENTIDADE EE ON EE.COD_ENTID = RB.COD_ENTID     LEFT OUTER JOIN CS_DADOS_PESSOAIS DP ON DP.COD_ENTID = EE.COD_ENTID      INNER JOIN GB_PROCESSOS_BENEFICIO PB ON PB.CD_FUNDACAO = RB.CD_FUNDACAO                  AND PB.NUM_INSCRICAO = RB.NUM_INSCRICAO     INNER JOIN GB_ESPECIE_BENEFICIO EB ON EB.CD_ESPECIE = PB.CD_ESPECIE WHERE RB.CD_TIPO_RECEBEDOR = 'G'   AND EE.CPF_CGC = @CPF   AND EB.CD_GRUPO_ESPECIE = '2'   AND PB.DT_TERMINO >= GETDATE()   AND EXISTS (SELECT BP.CD_FUNDACAO                  FROM GB_BENEFICIARIO_PREVIDENCIAL BP                WHERE BP.CD_FUNDACAO = RB.CD_FUNDACAO                  AND BP.NUM_INSCRICAO = RB.NUM_INSCRICAO                  AND BP.NUM_SEQ_GR_FAMIL = RB.NUM_SEQ_GR_FAMIL                  AND BP.DT_TERMINO_VALIDADE >= GETDATE())", new { CPF });
				else if(AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.QuerySingleOrDefault<RecebedorBeneficioEntidade>("SELECT RB.* FROM GB_RECEBEDOR_BENEFICIO  RB  INNER  JOIN EE_ENTIDADE   EE  ON EE.COD_ENTID=RB.COD_ENTID LEFT OUTER JOIN CS_DADOS_PESSOAIS   DP  ON DP.COD_ENTID=EE.COD_ENTID INNER  JOIN GB_PROCESSOS_BENEFICIO   PB  ON PB.CD_FUNDACAO=RB.CD_FUNDACAO AND PB.NUM_INSCRICAO=RB.NUM_INSCRICAO INNER  JOIN GB_ESPECIE_BENEFICIO   EB  ON EB.CD_ESPECIE=PB.CD_ESPECIE WHERE RB.CD_TIPO_RECEBEDOR='G' AND EE.CPF_CGC=:CPF AND EB.CD_GRUPO_ESPECIE='2' AND PB.DT_TERMINO>=SYSDATE AND  EXISTS (SELECT BP.CD_FUNDACAO FROM GB_BENEFICIARIO_PREVIDENCIAL  BP  WHERE BP.CD_FUNDACAO=RB.CD_FUNDACAO AND BP.NUM_INSCRICAO=RB.NUM_INSCRICAO AND BP.NUM_SEQ_GR_FAMIL=RB.NUM_SEQ_GR_FAMIL AND BP.DT_TERMINO_VALIDADE>=SYSDATE)", new { CPF });
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
