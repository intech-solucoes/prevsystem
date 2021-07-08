#region Usings
using System;
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

        public decimal BuscarValorEm(string codigo, DateTime data)
        {
            var indice = BuscarPorCodigo(codigo);

            if (indice.PERIODIC == "MEN")
            {
                return indice.VALORES
                    .OrderBy(x => x.DT_IND)
                    .LastOrDefault(x => x.DT_IND.MenorOuIgualQueMesAno(data))
                    .VALOR_IND;
            }
            else
            {
                return indice
                    .VALORES
                    .OrderBy(x => x.DT_IND).LastOrDefault(x => x.DT_IND <= data)
                    .VALOR_IND;
            }
        }

        public decimal BuscarVariacaoEm(string codigo, DateTime data)
        {
            var indice = BuscarPorCodigo(codigo);

            if (indice.PERIODIC == "MEN")
            {
                return indice.VALORES
                    .OrderBy(x => x.DT_IND)
                    .LastOrDefault(x => x.DT_IND.MenorOuIgualQueMesAno(data))
                    .VARIACAO_IND;
            }
            else
            {
                return indice
                    .VALORES
                    .OrderBy(x => x.DT_IND).LastOrDefault(x => x.DT_IND <= data)
                    .VARIACAO_IND;
            }
        }
    }
}
