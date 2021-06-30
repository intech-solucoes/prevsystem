using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class CadastroRubricasProxy : CadastroRubricasDAO
	{
		public CadastroRubricasProxy (IDbTransaction tx = null) : base(tx) { }
	}
}