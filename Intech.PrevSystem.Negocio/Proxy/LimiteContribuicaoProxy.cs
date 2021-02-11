using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class LimiteContribuicaoProxy : LimiteContribuicaoDAO
	{
		public LimiteContribuicaoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
