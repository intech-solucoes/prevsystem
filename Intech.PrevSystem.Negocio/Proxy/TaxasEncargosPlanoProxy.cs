using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class TaxasEncargosPlanoProxy : TaxasEncargosPlanoDAO
	{
		public TaxasEncargosPlanoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}