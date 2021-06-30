using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class RubricaProxy : RubricaDAO
	{
		public RubricaProxy (IDbTransaction tx = null) : base(tx) { }
	}
}