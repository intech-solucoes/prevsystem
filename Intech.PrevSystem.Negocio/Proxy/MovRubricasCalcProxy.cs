using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class MovRubricasCalcProxy : MovRubricasCalcDAO
	{
		public MovRubricasCalcProxy (IDbTransaction tx = null) : base(tx) { }
	}
}