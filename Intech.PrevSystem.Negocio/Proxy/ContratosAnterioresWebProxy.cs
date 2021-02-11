using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class ContratosAnterioresWebProxy : ContratosAnterioresWebDAO
	{
		public ContratosAnterioresWebProxy (IDbTransaction tx = null) : base(tx) { }
	}
}