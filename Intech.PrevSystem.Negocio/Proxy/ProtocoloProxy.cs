using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System.Collections.Generic;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class ProtocoloProxy : ProtocoloDAO
	{
		public ProtocoloProxy (IDbTransaction tx = null) : base(tx) { }

        public override List<ProtocoloEntidade> BuscarPorFundacaoEmpresaMatricula(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA)
        {
            var comprovantes = base.BuscarPorFundacaoEmpresaMatricula(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA);

            foreach(var comprovante in comprovantes)
            {
                comprovante.DS_DTA_SOLICITACAO = comprovante.DTA_SOLICITACAO.ToString("dd/MM/yyyy hh:mm:ss");
                comprovante.DS_DTA_EFETIVACAO = comprovante.DTA_EFETIVACAO.HasValue ? comprovante.DTA_EFETIVACAO.Value.ToString("dd/MM/yyyy hh:mm:ss") : null;
            }

            return comprovantes;
        }
    }
}