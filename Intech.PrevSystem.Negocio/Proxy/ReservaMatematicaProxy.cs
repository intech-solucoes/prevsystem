using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class ReservaMatematicaProxy : ReservaMatematicaDAO
	{
		public ReservaMatematicaProxy (IDbTransaction tx = null) : base(tx) { }
	}
}