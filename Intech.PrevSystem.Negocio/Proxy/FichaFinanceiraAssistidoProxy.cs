#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades; 
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class FichaFinanceiraAssistidoProxy : FichaFinanceiraAssistidoDAO
    {
        public override IEnumerable<FichaFinanceiraAssistidoEntidade> BuscarDatas(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, DateTime DT_REFERENCIA)
        {
            var datas = base.BuscarDatas(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_REFERENCIA).ToList();

            datas.ForEach(data =>
            {
                var rubricasData = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferencia(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, data.DT_REFERENCIA, "1");

                data.VAL_BRUTO = rubricasData.Where(x => x.RUBRICA_PROV_DESC == "P").Sum(x => x.VALOR_MC);
                data.VAL_DESCONTOS = rubricasData.Where(x => x.RUBRICA_PROV_DESC == "D").Sum(x => x.VALOR_MC);
                data.VAL_LIQUIDO = data.VAL_BRUTO - Math.Abs(data.VAL_DESCONTOS.Value);
            });

            return datas;
        }

        public dynamic BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferencia(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, DateTime DT_REFERENCIA, string CD_TIPO_FOLHA, int? SeqRecebedor = null)
        {
            List<FichaFinanceiraAssistidoEntidade> rubricas;
                
            if(SeqRecebedor.HasValue)
                rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SeqRecebedor.Value, CD_PLANO, DT_REFERENCIA, CD_TIPO_FOLHA).ToList();
            else
                rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferencia(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_REFERENCIA, CD_TIPO_FOLHA).ToList();

            var proventos = rubricas.Where(x => x.RUBRICA_PROV_DESC == "P").ToList();
            var descontos = rubricas.Where(x => x.RUBRICA_PROV_DESC == "D").ToList();

            var bruto = proventos.Sum(x => x.VALOR_MC);
            var valDescontos = descontos.Sum(x => x.VALOR_MC);
            var liquido = bruto - Math.Abs(valDescontos.Value);

            return new
            {
                Proventos = proventos,
                Descontos = descontos,
                Resumo = new {
                    Referencia = DT_REFERENCIA,
                    Bruto = bruto,
                    Descontos = valDescontos,
                    Liquido = liquido,
                    TipoFolha = rubricas.First().CD_TIPO_FOLHA
                }
            };
        }
    }
}
