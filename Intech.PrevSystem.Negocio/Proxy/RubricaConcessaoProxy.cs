using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class RubricaConcessaoProxy : RubricaConcessaoDAO
	{
		public RubricaConcessaoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}