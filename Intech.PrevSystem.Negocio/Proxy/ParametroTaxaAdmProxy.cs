using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class ParametroTaxaAdmProxy : ParametroTaxaAdmDAO
	{
		public ParametroTaxaAdmProxy (IDbTransaction tx = null) : base(tx) { }
	}
}