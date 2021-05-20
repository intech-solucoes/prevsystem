using Intech.PrevSystem.Dados.DAO;
using System.Data;

namespace Intech.PrevSystem.Negocio.Proxy
{
	public class CarenciasDisponiveisProxy : CarenciasDisponiveisDAO
	{
		public CarenciasDisponiveisProxy (IDbTransaction tx = null) : base(tx) { }
	}
}