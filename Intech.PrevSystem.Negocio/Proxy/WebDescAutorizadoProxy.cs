using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebDescAutorizadoProxy : WebDescAutorizadoDAO
	{
		public WebDescAutorizadoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}