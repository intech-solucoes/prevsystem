using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class ParametrosProxy : ParametrosDAO
	{
		public ParametrosProxy (IDbTransaction tx = null) : base(tx) { }
	}
}