using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class BoletoAvulsoProxy : BoletoAvulsoDAO
	{
		public BoletoAvulsoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
