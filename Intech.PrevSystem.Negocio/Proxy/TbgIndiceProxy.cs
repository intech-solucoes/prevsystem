#region Usings
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class TbgIndiceProxy : TbgIndiceDAO
    {
        public TbgIndiceEntidade BuscarPorCodIndice(string COD_INDICE, bool todos = false)
        {
            var indice = base.BuscarPorCodIndice(COD_INDICE);

            if(todos)
                indice.Valores = new TbgIndiceValProxy().BuscarPorCodIndice(COD_INDICE).ToList();
            else
                indice.Valores = new TbgIndiceValProxy().BuscarUltimoPorCodIndice(COD_INDICE).ToList();

            return indice;
        }

        public TbgIndiceEntidade BuscarPorCodIndiceData(string COD_INDICE, DateTime data)
        {
            var indice = base.BuscarPorCodIndice(COD_INDICE);
            indice.Valores = new TbgIndiceValProxy().BuscarPorCodIndiceData(COD_INDICE, data).ToList();

            return indice;
        }
    }
}