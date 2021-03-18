using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class TaxasConcessaoProxy : TaxasConcessaoDAO
	{
		public TaxasConcessaoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
