using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class NaturezaProxy : NaturezaDAO
	{
		public NaturezaProxy (IDbTransaction tx = null) : base(tx) { }
	}
}