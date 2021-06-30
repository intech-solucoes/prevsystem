using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class DocumentoProxy : DocumentoDAO
	{
		public DocumentoProxy (IDbTransaction tx = null) : base(tx) { }
	}
}