using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebContribuicaoProxy : WebContribuicaoDAO
	{
		public WebContribuicaoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}