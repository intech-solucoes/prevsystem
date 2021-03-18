using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class ContratosAnterioresProxy : ContratosAnterioresDAO
	{
		public ContratosAnterioresProxy (IDbTransaction tx = null) : base(tx) { }
	}
}