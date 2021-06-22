using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebReqBeneficioDescProxy : WebReqBeneficioDescDAO
	{
		public WebReqBeneficioDescProxy (IDbTransaction tx = null) : base(tx) { }

        public void Insert(WebReqBeneficioDescEntidade dados)
        {
            base.Insert(
                dados.OID_REQ_BENEFICIO,
                dados.OID_DESC_AUTORIZADO,
                dados.IND_AUTORIZADO
            );
        }
    }
}
