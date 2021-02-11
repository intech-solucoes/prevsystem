using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class BancoAgProxy : BancoAgDAO
	{
		public BancoAgProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
