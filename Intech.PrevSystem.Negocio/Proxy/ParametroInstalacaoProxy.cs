using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class ParametroInstalacaoProxy : ParametroInstalacaoDAO
	{
		public ParametroInstalacaoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}