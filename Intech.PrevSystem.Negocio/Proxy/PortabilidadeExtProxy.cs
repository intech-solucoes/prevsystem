using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class PortabilidadeExtProxy : PortabilidadeExtDAO
	{
		public PortabilidadeExtProxy (IDbTransaction tx = null) : base(tx) { }
	}
}