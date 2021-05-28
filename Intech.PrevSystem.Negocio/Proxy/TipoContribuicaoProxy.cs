using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class TipoContribuicaoProxy : TipoContribuicaoDAO
	{
		public TipoContribuicaoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}