using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebDocExigidoProxy : WebDocExigidoDAO
	{
		public WebDocExigidoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}