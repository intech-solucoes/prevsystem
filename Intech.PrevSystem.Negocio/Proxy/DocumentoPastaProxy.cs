using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class DocumentoPastaProxy : DocumentoPastaDAO
	{
		public DocumentoPastaProxy (IDbTransaction tx = null) : base(tx) { }
	}
}