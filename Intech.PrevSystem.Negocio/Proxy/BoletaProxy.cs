using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class BoletaProxy : BoletaDAO
	{
		public BoletaProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
