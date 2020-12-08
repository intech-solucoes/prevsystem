using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class ContribuicaoIndividualProxy : ContribuicaoIndividualDAO
	{
		public ContribuicaoIndividualProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
