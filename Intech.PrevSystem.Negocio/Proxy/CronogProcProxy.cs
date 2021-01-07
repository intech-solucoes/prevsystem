using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class CronogProcProxy : CronogProcDAO
	{
		public CronogProcProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
