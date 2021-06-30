using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class FatorPlanoBDProxy : FatorPlanoBDDAO
	{
		public FatorPlanoBDProxy (IDbTransaction tx = null) : base(tx) { }
	}
}