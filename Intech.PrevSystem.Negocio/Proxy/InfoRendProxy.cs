#region Usings
using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Dicionarios;

#endregion
namespace Intech.PrevSystem.Negocio.Proxy
{
    public class InfoRendProxy : InfoRendDAO
    {
        public override IEnumerable<InfoRendEntidade> BuscarPorOidHeader(decimal OID_HEADER_INFO_REND)
        {
            var lista = base.BuscarPorOidHeader(OID_HEADER_INFO_REND).ToList();

            lista.ForEach(infoRend =>
            {
                infoRend.COD_GRUPO = infoRend.COD_LINHA.Substring(0, 1);
                infoRend.DES_GRUPO = DicionariosInfoRend.Grupos.Single(x => x.Key == infoRend.COD_GRUPO).Value;
            });

            return lista;
        }
    }
}
