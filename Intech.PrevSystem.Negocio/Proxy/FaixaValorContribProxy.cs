using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class FaixaValorContribProxy : FaixaValorContribDAO
	{
		public FaixaValorContribProxy (IDbTransaction tx = null) : base(tx) { }
	}
}
