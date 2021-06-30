using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class RegraCalcFundacaoProxy : RegraCalcFundacaoDAO
	{
		public RegraCalcFundacaoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}