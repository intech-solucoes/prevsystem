using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class DocumentoPlanoProxy : DocumentoPlanoDAO
	{
		public DocumentoPlanoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}