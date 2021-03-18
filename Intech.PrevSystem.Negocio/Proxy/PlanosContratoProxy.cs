using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class PlanosContratoProxy : PlanosContratoDAO
	{
		public PlanosContratoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}