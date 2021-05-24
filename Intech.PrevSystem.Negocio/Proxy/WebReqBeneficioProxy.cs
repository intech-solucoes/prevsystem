using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebReqBeneficioProxy : WebReqBeneficioDAO
	{
		public WebReqBeneficioProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
