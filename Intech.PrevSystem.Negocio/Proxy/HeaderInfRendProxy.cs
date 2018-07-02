#region Usings
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class HeaderInfoRendProxy : HeaderInfoRendDAO
    {
        public IEnumerable<int> BuscarReferenciasPorCPF(string cpf)
        {
            var informes = BuscarPorCPF(cpf).ToList();

            foreach (var informe in informes)
                yield return (int)informe.ANO_CALENDARIO;
        }

        public HeaderInfoRendEntidade BuscarPorCpfReferencia(string cpf, decimal referencia)
        {
            var informe = BuscarPorCPFAnoCalendario(cpf, referencia).First();

            informe.Grupos = new InfoRendProxy().BuscarPorOidHeader(informe.OID_HEADER_INFO_REND).ToList();
            informe.PreencherGrupos();

            return informe;
        }
    }
}
