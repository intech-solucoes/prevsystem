#region Usings
using Intech.PrevSystem.Entidades.Constantes;
using System;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Entidades
{
    public static class IndiceExtensao
    {
        public static decimal BuscarValorEm(this IndiceEntidade indice, DateTime data)
        {
            if (indice.PERIODIC == DMN_PERIODICIDADE.MENSAL)
                return indice.VALORES.First(x => x.DT_IND.MenorOuIgualQueMesAno(data)).VALOR_IND;
            else
                return indice.VALORES.First(x => x.DT_IND <= data).VALOR_IND;
        }

        /// <summary>
        /// Obtém o valor do índice em uma determinada data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>
        /// O valor de um índice em uma data é dado pelo valor do índice na data 
        /// ou, caso não exista cadastro para a data informada, o valor do índice 
        /// na data imediatamente inferior.
        /// Imagine que existem valores cadastrados para o índice nas seguintes datas:
        /// 01/01/2008 - 100
        /// 01/02/2008 - 101
        /// 01/03/2008 - 102
        /// 
        /// O valor na data 01/02/2008 é 101, em 02/02/2008 é 101, em 15/01/2008 é 100.
        /// Em 31/12/2007 não existe valor cadastrado e o método irá retornar 0 (zero).
        /// </remarks>
        public static decimal ObtemValorEm(this IndiceEntidade indice, DateTime data)
        {
            if (indice.VALORES.Count > 0)
            {
                if (indice.PERIODIC == DMN_PERIODICIDADE.MENSAL)
                    return indice.VALORES.OrderBy(x => x.DT_IND).LastOrDefault(x => x.DT_IND.MenorOuIgualQueMesAno(data)).VALOR_IND;
                else
                    return indice.VALORES.OrderBy(x => x.DT_IND).LastOrDefault(x => x.DT_IND <= data).VALOR_IND;
            }
            
            return 0;
        }

        /// <summary>
        /// Obtém o Variaçao do índice em uma determinada data.
        /// </summary>        
        public static decimal ObtemVariacaoEm(this IndiceEntidade indice, DateTime data)
        {
            if (indice.VALORES.Count > 0)
            {
                if (indice.PERIODIC == DMN_PERIODICIDADE.MENSAL)
                    return indice.VALORES.OrderBy(x => x.DT_IND).LastOrDefault(x => x.DT_IND.MenorOuIgualQueMesAno(data)).VARIACAO_IND;
                else
                    return indice.VALORES.OrderBy(x => x.DT_IND).LastOrDefault(x => x.DT_IND <= data).VARIACAO_IND;
            }

            return 0;
        }
    }
}
