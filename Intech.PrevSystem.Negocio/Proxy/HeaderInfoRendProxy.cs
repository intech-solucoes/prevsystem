#region Usings
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Dicionarios;
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

        public IEnumerable<int> BuscarReferenciasPorMatricula(string matricula)
        {
            var informes = BuscarPorMatricula(matricula).ToList();

            foreach (var informe in informes)
                yield return (int)informe.ANO_CALENDARIO;
        }

        public IEnumerable<int> BuscarReferenciasPorEmpresaMatricula(string cdEmpresa, string matricula)
        {
            var informes = BuscarPorEmpresaMatricula(cdEmpresa, matricula).ToList();

            foreach (var informe in informes)
                yield return (int)informe.ANO_CALENDARIO;
        }

        public HeaderInfoRendEntidade BuscarPorCpfReferencia(string cpf, decimal referencia)
        {
            var informe = BuscarPorCPFAnoCalendario(cpf, referencia).First();
            informe.Grupos = new List<InfoRendGrupoEntidade>();

            var infoRend = new InfoRendProxy().BuscarPorOidHeader(informe.OID_HEADER_INFO_REND).ToList();

            infoRend
                .GroupBy(x => new { x.COD_GRUPO, x.DES_GRUPO })
                .ToList()
                .ForEach(item =>
                {
                    var grupo = new InfoRendGrupoEntidade
                    {
                        COD_GRUPO = item.Key.COD_GRUPO,
                        DES_GRUPO = item.Key.DES_GRUPO,
                        Itens = item.ToList()
                    };

                    grupo.Itens.ForEach(grupoItem =>
                    {
                        if (!string.IsNullOrEmpty(grupoItem.TXT_QUADRO))
                            grupoItem.DES_INFO_REND = grupoItem.TXT_QUADRO;
                        else
                            grupoItem.DES_INFO_REND = DicionariosInfoRend.Linhas.SingleOrDefault(x => x.Key == grupoItem.COD_LINHA).Value;
                    });

                    informe.Grupos.Add(grupo);
                });

            return informe;
        }

        public HeaderInfoRendEntidade BuscarPorMatriculaReferencia(string matricula, decimal referencia, decimal? seqRecebedor = null)
        {
            HeaderInfoRendEntidade informe;

            if(seqRecebedor.HasValue)
                informe = BuscarPorMatriculaAnoCalendarioSeqRecebedor(matricula, referencia, seqRecebedor.Value).First();
            else
                informe = BuscarPorMatriculaAnoCalendario(matricula, referencia).First();


            informe.Grupos = new List<InfoRendGrupoEntidade>();

            var infoRend = new InfoRendProxy().BuscarPorOidHeader(informe.OID_HEADER_INFO_REND).ToList();

            infoRend
                .GroupBy(x => new { x.COD_GRUPO, x.DES_GRUPO })
                .ToList()
                .ForEach(item =>
                {
                    var grupo = new InfoRendGrupoEntidade
                    {
                        COD_GRUPO = item.Key.COD_GRUPO,
                        DES_GRUPO = item.Key.DES_GRUPO,
                        Itens = item.ToList()
                    };

                    grupo.Itens.ForEach(grupoItem =>
                    {
                        if (!string.IsNullOrEmpty(grupoItem.TXT_QUADRO))
                            grupoItem.DES_INFO_REND = grupoItem.TXT_QUADRO;
                        else
                            grupoItem.DES_INFO_REND = DicionariosInfoRend.Linhas.SingleOrDefault(x => x.Key == grupoItem.COD_LINHA).Value;
                    });

                    informe.Grupos.Add(grupo);
                });

            return informe;
        }

        public HeaderInfoRendEntidade BuscarPorEmpresaMatriculaReferencia(string cdEmpresa, string matricula, decimal referencia, decimal? seqRecebedor = null)
        {
            HeaderInfoRendEntidade informe;

            if (seqRecebedor.HasValue)
                informe = BuscarPorEmpresaMatriculaAnoCalendarioSeqRecebedor(cdEmpresa, matricula, referencia, seqRecebedor.Value).First();
            else
                informe = BuscarPorEmpresaMatriculaAnoCalendario(cdEmpresa, matricula, referencia).First();


            informe.Grupos = new List<InfoRendGrupoEntidade>();

            var infoRend = new InfoRendProxy().BuscarPorOidHeader(informe.OID_HEADER_INFO_REND).ToList();

            infoRend
                .GroupBy(x => new { x.COD_GRUPO, x.DES_GRUPO })
                .ToList()
                .ForEach(item =>
                {
                    var grupo = new InfoRendGrupoEntidade
                    {
                        COD_GRUPO = item.Key.COD_GRUPO,
                        DES_GRUPO = item.Key.DES_GRUPO,
                        Itens = item.ToList()
                    };

                    grupo.Itens.ForEach(grupoItem =>
                    {
                        if (!string.IsNullOrEmpty(grupoItem.TXT_QUADRO))
                            grupoItem.DES_INFO_REND = grupoItem.TXT_QUADRO;
                        else
                            grupoItem.DES_INFO_REND = DicionariosInfoRend.Linhas.SingleOrDefault(x => x.Key == grupoItem.COD_LINHA).Value;
                    });

                    informe.Grupos.Add(grupo);
                });

            return informe;
        }
    }
}
