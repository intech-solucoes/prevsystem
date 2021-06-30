using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class FaixaRubricaProxy : FaixaRubricaDAO
	{
		public FaixaRubricaProxy (IDbTransaction tx = null) : base(tx) { }
	}
}