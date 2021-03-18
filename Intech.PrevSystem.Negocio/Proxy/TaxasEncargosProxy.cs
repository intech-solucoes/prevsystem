using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class TaxasEncargosProxy : TaxasEncargosDAO
	{
		public TaxasEncargosProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
