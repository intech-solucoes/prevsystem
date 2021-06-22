using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebReqBeneficioDocProxy : WebReqBeneficioDocDAO
	{
		public WebReqBeneficioDocProxy (IDbTransaction tx = null) : base(tx) { }

        public void Insert(WebReqBeneficioDocEntidade dados)
        {
            base.Insert(
                dados.OID_REQ_BENEFICIO,
                dados.OID_DOC_EXIGIDO,
                dados.TXT_NOME_FISICO
            );
        }
    }
}
