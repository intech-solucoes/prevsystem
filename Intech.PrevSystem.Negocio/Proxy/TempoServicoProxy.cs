using Intech.Lib.Util.Date;
using Intech.PrevSystem.Dados.DAO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class TempoServicoProxy : TempoServicoDAO
    {
        public List<Periodo> BuscarPorCodEntidSemConcomitancia(string codEntid)
        {
            var temposServico = base.BuscarPorCodEntid(Convert.ToInt32(codEntid)).ToList();

            var retorno = new List<Periodo>();

            if (temposServico.Any())
            {
                temposServico = temposServico.OrderBy(x => x.DT_INIC_ATIVIDADE).ToList();

                DateTime inicio = temposServico[0].DT_INIC_ATIVIDADE.Value;
                DateTime fim = temposServico[0].DT_TERM_ATIVIDADE ?? DateTime.Now;

                for (int i = 1; i < temposServico.Count; i++)
                {
                    if (temposServico[i].DT_INIC_ATIVIDADE <= fim)
                    {
                        if (temposServico[i].DT_TERM_ATIVIDADE > fim)
                            fim = temposServico[i].DT_TERM_ATIVIDADE.Value;
                    }
                    else
                    {
                        retorno.Add(new Periodo(inicio, fim));

                        inicio = temposServico[i].DT_INIC_ATIVIDADE.Value;
                        fim = temposServico[i].DT_TERM_ATIVIDADE.Value;
                    }
                }

                retorno.Add(new Periodo(inicio, fim));
            }

            return retorno;
        }
    }
}
