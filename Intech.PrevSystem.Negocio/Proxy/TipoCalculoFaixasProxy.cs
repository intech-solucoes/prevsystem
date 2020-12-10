using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class TipoCalculoFaixasProxy : TipoCalculoFaixasDAO
	{
		public TipoCalculoFaixasProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
