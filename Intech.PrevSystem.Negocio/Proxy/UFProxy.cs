using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class UFProxy : UFDAO
	{
		public UFProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
