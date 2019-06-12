#region Usings
using System;
using System.Collections.Generic;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Entidades.Extensoes
{
    public static class Feriado
    {
        public enum Estado { AC, AL, AP, AM, BA, CE, DF, GO, ES, MA, MT, MS, MG, PA, PB, PR, PE, PI, RJ, RN, RS, RO, RR, SP, SC, SE, TO };

        public enum Direcao
        {
            Posterior,
            Anterior
        };

        public static int UltimoDiaUtilDoMes(this DateTime data, IEnumerable<FeriadoEntidade> feriados)
        {
            DateTime dtTemp = new DateTime(data.Year, data.Month, data.UltimoDiaDoMes().Day);

            if (!dtTemp.EhDiaUtil(feriados.Select(x => x.DT_FERIADO)))
                return BuscarDataUtil(dtTemp, feriados, Direcao.Anterior, null).Day;
            else
                return dtTemp.Day;
        }

        /// <summary>
        /// BuscarDataUtil
        /// Retorna a data útil anterior ou posterior à 'dataBase'
        /// Reversa da função Dt_Data_Util do sistema em Delphi
        /// </summary>
        public static DateTime BuscarDataUtil(DateTime dataBase, IEnumerable<FeriadoEntidade> feriados, Direcao direcao, Estado? estado)
        {
            DateTime dtTmp = dataBase;
            string estadoTmp;
            const string todos = "";

            estadoTmp = estado.HasValue ? estado.Value.ToString() : todos;

            while (true)
            {
                if (direcao == Direcao.Posterior)
                    dtTmp = dtTmp.AddDays(1);
                else
                    dtTmp = dtTmp.AddDays(-1);


                if (dtTmp.DayOfWeek == DayOfWeek.Sunday)
                    if (direcao == Direcao.Posterior)
                        dtTmp = dtTmp.AddDays(1);
                    else
                        dtTmp = dtTmp.AddDays(-2);

                if (dtTmp.DayOfWeek == DayOfWeek.Saturday)
                    if (direcao == Direcao.Posterior)
                        dtTmp = dtTmp.AddDays(2);
                    else
                        dtTmp = dtTmp.AddDays(-1);

                //Se não for nem feriado local nem feriado estadual, achou a data
                var feriado = feriados
                    .Where((x => (x.DT_FERIADO == dtTmp && x.LOCAL == estadoTmp) || (x.DT_FERIADO == dtTmp && estadoTmp == todos)))
                    .SingleOrDefault();

                if (feriado == null)
                {
                    break;
                }
            }

            return dtTmp;
        }

        /// <summary>
        /// Retorna a data útil anterior ou posterior à 'dataBase'
        /// Reversa da função Dt_Data_Util do sistema em Delphi
        /// </summary>
        public static DateTime BuscarDiaUtil(List<FeriadoEntidade> feriados, DateTime dataBase, Direcao direcao, Estado? estado)
        {
            DateTime dtTmp = dataBase;
            string estadoTmp;
            const string todos = "";

            estadoTmp = estado.HasValue ? estado.Value.ToString() : todos;

            while (true)
            {
                if (direcao == Direcao.Posterior)
                    dtTmp = dtTmp.AddDays(1);
                else
                    dtTmp = dtTmp.AddDays(-1);


                if (dtTmp.DayOfWeek == DayOfWeek.Sunday)
                    if (direcao == Direcao.Posterior)
                        dtTmp = dtTmp.AddDays(1);
                    else
                        dtTmp = dtTmp.AddDays(-2);

                if (dtTmp.DayOfWeek == DayOfWeek.Saturday)
                    if (direcao == Direcao.Posterior)
                        dtTmp = dtTmp.AddDays(2);
                    else
                        dtTmp = dtTmp.AddDays(-1);
                
                //Se não for nem feriado local nem feriado estadual, achou a data
                var feriado = feriados
                    .Where((x => (x.DT_FERIADO == dtTmp && x.LOCAL == estadoTmp) || (x.DT_FERIADO == dtTmp && estadoTmp == todos)))
                    .SingleOrDefault();

                if (feriado == null)
                    break;
            }

            return dtTmp;
        }
    }
}
