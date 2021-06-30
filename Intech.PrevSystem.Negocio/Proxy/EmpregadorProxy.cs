using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class EmpregadorProxy : EmpregadorDAO
	{
		public EmpregadorProxy (IDbTransaction tx = null) : base(tx) { }
	}
}