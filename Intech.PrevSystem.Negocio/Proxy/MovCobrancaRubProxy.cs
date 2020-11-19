using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class MovCobrancaRubProxy : MovCobrancaRubDAO
	{
		public MovCobrancaRubProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
