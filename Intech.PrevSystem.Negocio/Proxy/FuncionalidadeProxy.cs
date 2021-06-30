using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class FuncionalidadeProxy : FuncionalidadeDAO
	{
		public FuncionalidadeProxy (IDbTransaction tx = null) : base(tx) { }
	}
}