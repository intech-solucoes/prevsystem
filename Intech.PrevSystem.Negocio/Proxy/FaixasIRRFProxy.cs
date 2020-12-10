using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class FaixasIRRFProxy : FaixasIRRFDAO
	{
		public FaixasIRRFProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
