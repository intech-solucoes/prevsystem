using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class GrauParentescoProxy : GrauParentescoDAO
	{
		public GrauParentescoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
