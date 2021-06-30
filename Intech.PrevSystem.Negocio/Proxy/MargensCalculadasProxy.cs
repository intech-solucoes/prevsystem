using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class MargensCalculadasProxy : MargensCalculadasDAO
	{
		public MargensCalculadasProxy (IDbTransaction tx = null) : base(tx) { }
	}
}