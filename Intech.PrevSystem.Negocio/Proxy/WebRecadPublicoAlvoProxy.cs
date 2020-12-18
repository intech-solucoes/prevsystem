using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebRecadPublicoAlvoProxy : WebRecadPublicoAlvoDAO
	{
		public WebRecadPublicoAlvoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
