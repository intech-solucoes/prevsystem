using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class IndiceValoresProxy : IndiceValoresDAO
	{
		public IndiceValoresProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
