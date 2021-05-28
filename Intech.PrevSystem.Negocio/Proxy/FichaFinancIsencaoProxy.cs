using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class FichaFinancIsencaoProxy : FichaFinancIsencaoDAO
	{
		public FichaFinancIsencaoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}