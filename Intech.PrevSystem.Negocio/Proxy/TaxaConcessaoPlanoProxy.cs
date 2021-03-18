using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class TaxaConcessaoPlanoProxy : TaxaConcessaoPlanoDAO
	{
		public TaxaConcessaoPlanoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
