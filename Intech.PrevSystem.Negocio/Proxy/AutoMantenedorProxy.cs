using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class AutoMantenedorProxy : AutoMantenedorDAO
	{
		public AutoMantenedorProxy (IDbTransaction tx = null) : base(tx) { }
	}
}