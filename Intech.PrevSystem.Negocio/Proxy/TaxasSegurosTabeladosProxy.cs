using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class TaxasSegurosTabeladosProxy : TaxasSegurosTabeladosDAO
	{
		public TaxasSegurosTabeladosProxy (IDbTransaction tx = null) : base(tx) { }
	}
}