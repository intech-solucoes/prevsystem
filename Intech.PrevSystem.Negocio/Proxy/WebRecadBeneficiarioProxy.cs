using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class WebRecadBeneficiarioProxy : WebRecadBeneficiarioDAO
	{
		public WebRecadBeneficiarioProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
