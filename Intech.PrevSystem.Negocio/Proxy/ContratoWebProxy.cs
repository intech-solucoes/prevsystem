using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class ContratoWebProxy : ContratoWebDAO
	{
		public ContratoWebProxy (IDbTransaction tx = null) : base(tx) { }
	}
}