using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebParametroProxy : WebParametroDAO
	{
		public WebParametroProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
