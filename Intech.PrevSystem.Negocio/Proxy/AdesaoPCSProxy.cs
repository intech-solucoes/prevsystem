using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class AdesaoPCSProxy : AdesaoPCSDAO
	{
		public AdesaoPCSProxy (IDbTransaction tx = null) : base(tx) { }
	}
}