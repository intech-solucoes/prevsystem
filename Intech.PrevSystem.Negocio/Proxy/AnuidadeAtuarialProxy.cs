using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class AnuidadeAtuarialProxy : AnuidadeAtuarialDAO
	{
		public AnuidadeAtuarialProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
