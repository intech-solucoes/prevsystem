using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class EmpresaProxy : EmpresaDAO
	{
		public EmpresaProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
