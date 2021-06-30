using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class SexoProxy : SexoDAO
	{
		public SexoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}