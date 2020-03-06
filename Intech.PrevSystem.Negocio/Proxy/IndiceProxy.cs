#region Usings
using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using Microsoft.Extensions.Configuration;
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class IndiceProxy : IndiceDAO
    {
        public override IndiceEntidade BuscarPorCodigo(string COD_IND)
        {
            var indice = base.BuscarPorCodigo(COD_IND);

            if(indice != null)
                indice.VALORES = new IndiceValoresProxy().BuscarPorCodigo(COD_IND).ToList();

            return indice;
        }

        public IndiceEntidade BuscarUltimoPorCodigo(string COD_IND)
        {
            var indice = base.BuscarPorCodigo(COD_IND);

            if (indice != null)
                indice.VALORES = new IndiceValoresProxy().BuscarUltimoPorCodigo(COD_IND).ToList();

            return indice;
        }

        public IndiceValoresEntidade BuscarUltimoPorCodigoData(string COD_IND)
        {

            var valorindice = new IndiceValoresProxy().BuscarUltimoPorCodigo(COD_IND).FirstOrDefault();

            return valorindice;
        }
    }
}
