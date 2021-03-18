using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class RecebedorBeneficioProxy : RecebedorBeneficioDAO
	{
		public RecebedorBeneficioProxy (IDbTransaction tx = null) : base(tx) { }
	}
}