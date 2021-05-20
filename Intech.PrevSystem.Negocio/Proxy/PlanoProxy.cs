using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class PlanoProxy : PlanoDAO
	{
		public PlanoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}