using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class CSAvaliacaoProxy : CSAvaliacaoDAO
	{
		public CSAvaliacaoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}