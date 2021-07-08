using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class RubricaDescontoProxy : RubricaDescontoDAO
	{
		public RubricaDescontoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}