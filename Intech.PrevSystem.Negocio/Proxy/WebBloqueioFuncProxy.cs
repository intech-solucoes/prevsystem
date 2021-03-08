using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebBloqueioFuncProxy : WebBloqueioFuncDAO
	{
		public WebBloqueioFuncProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
