using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class TaxasConcessaoPlanoProxy : TaxasConcessaoPlanoDAO
	{
		public TaxasConcessaoPlanoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}