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
        public override IEnumerable<FichaFinanceiraAssistidoEntidade> BuscarDatas(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO)
        {
            var datas = base.BuscarDatas(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO).ToList();

            foreach(var data in datas)
            {
                var rubricasData = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferencia(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, data.DT_REFERENCIA, data.CD_TIPO_FOLHA);

                data.VAL_BRUTO = rubricasData.Where(x => x.RUBRICA_PROV_DESC == "P").Sum(x => x.VALOR_MC);
                data.VAL_DESCONTOS = rubricasData.Where(x => x.RUBRICA_PROV_DESC == "D").Sum(x => x.VALOR_MC);
                data.VAL_LIQUIDO = data.VAL_BRUTO - Math.Abs(data.VAL_DESCONTOS.Value);
            }

            return datas;
        }

        public override IEnumerable<FichaFinanceiraAssistidoEntidade> BuscarDatasPorRecebedor(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, int SEQ_RECEBEDOR, string CD_PLANO)
        {
            var datas = base.BuscarDatasPorRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SEQ_RECEBEDOR, CD_PLANO).ToList();

            datas.ForEach(data =>
            {
                var rubricasData = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SEQ_RECEBEDOR, CD_PLANO, data.DT_REFERENCIA, data.CD_TIPO_FOLHA);

                data.VAL_BRUTO = rubricasData.Where(x => x.RUBRICA_PROV_DESC == "P").Sum(x => x.VALOR_MC);
                data.VAL_DESCONTOS = rubricasData.Where(x => x.RUBRICA_PROV_DESC == "D").Sum(x => x.VALOR_MC);
                data.VAL_LIQUIDO = data.VAL_BRUTO - Math.Abs(data.VAL_DESCONTOS.Value);
            });

            return datas;
        }

        public dynamic BuscarRubricasPorFundacaoEmpresaMatriculaPlanoCompetencia(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, DateTime DT_COMPETENCIA, string CD_TIPO_FOLHA, int? SeqRecebedor = null)
        {
            List<FichaFinanceiraAssistidoEntidade> rubricas;

            if (SeqRecebedor.HasValue)
                rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoCompetenciaRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SeqRecebedor.Value, CD_PLANO, DT_COMPETENCIA, CD_TIPO_FOLHA).ToList();
            else
                rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoCompetencia(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_COMPETENCIA, CD_TIPO_FOLHA).ToList();

            var proventos = rubricas.Where(x => x.RUBRICA_PROV_DESC == "P").ToList();
            var descontos = rubricas.Where(x => x.RUBRICA_PROV_DESC == "D").ToList();

            foreach(var rubrica in descontos)
                rubrica.VALOR_MC *= -1;

            var bruto = proventos.Sum(x => x.VALOR_MC);
            var valDescontos = descontos.Sum(x => x.VALOR_MC);
            var liquido = bruto - Math.Abs(valDescontos.Value);

            return new
            {
                Proventos = proventos,
                Descontos = descontos,
                Resumo = new
                {
                    Competencia = DT_COMPETENCIA,
                    Bruto = bruto,
                    Descontos = valDescontos,
                    Liquido = liquido,
                    TipoFolha = rubricas.First().CD_TIPO_FOLHA,
                    DesTipoFolha = rubricas.First().DS_TIPO_FOLHA
                }
            };
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

            foreach (var rubrica in descontos)
                rubrica.VALOR_MC *= -1;

            var bruto = proventos.Sum(x => x.VALOR_MC);
            var valDescontos = descontos.Sum(x => x.VALOR_MC);
            var liquido = bruto - Math.Abs(valDescontos.Value);

            return new Contracheque
            {
                Proventos = proventos,
                Descontos = descontos,
                Resumo = new ContrachequeResumo {
                    Referencia = DT_REFERENCIA,
                    Bruto = bruto,
                    Descontos = valDescontos,
                    Liquido = liquido,
                    TipoFolha = rubricas.First().CD_TIPO_FOLHA,
                    DesTipoFolha = rubricas.First().DS_TIPO_FOLHA
                }
            };
        }

        public dynamic BuscarUltimaFolhaPorFundacaoEmpresaMatriculaPlano(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, int? SeqRecebedor = null)
        {
            List<FichaFinanceiraAssistidoEntidade> rubricas;

            if (SeqRecebedor.HasValue)
            {
                var data = base.BuscarUltimaDataPorRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SeqRecebedor.Value, CD_PLANO);
                rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SeqRecebedor.Value, CD_PLANO, data, "1").ToList();
            }
            else
            {
                var data = base.BuscarUltimaData(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO);
                rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferencia(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, data, "1").ToList();
            }

            var proventos = rubricas.Where(x => x.RUBRICA_PROV_DESC == "P").ToList();
            var descontos = rubricas.Where(x => x.RUBRICA_PROV_DESC == "D").ToList();

            foreach (var rubrica in descontos)
                rubrica.VALOR_MC *= -1;

            var bruto = proventos.Sum(x => x.VALOR_MC);
            var valDescontos = descontos.Sum(x => x.VALOR_MC);
            var liquido = bruto - Math.Abs(valDescontos.Value);
            var indice = new IndiceValoresProxy().BuscarReservaPoupanca(rubricas.First().DT_REFERENCIA.PrimeiroDiaDoMes());

            return new
            {
                Proventos = proventos,
                Descontos = descontos,
                Resumo = new
                {
                    Referencia = rubricas.First().DT_REFERENCIA,
                    Bruto = bruto,
                    Descontos = valDescontos,
                    Liquido = liquido,
                    TipoFolha = rubricas.First().CD_TIPO_FOLHA,
                    DesTipoFolha = rubricas.First().DS_TIPO_FOLHA,
                    Indice = indice
                }
            };
        }
    }

    public class Contracheque
    {
        public List<FichaFinanceiraAssistidoEntidade> Proventos { get; internal set; }
        public List<FichaFinanceiraAssistidoEntidade> Descontos { get; internal set; }
        public ContrachequeResumo Resumo { get; internal set; }
    }

    public class ContrachequeResumo
    {
        public DateTime Referencia { get; internal set; }
        public decimal? Bruto { get; internal set; }
        public decimal? Descontos { get; internal set; }
        public decimal? Liquido { get; internal set; }
        public string TipoFolha { get; internal set; }
        public string DesTipoFolha { get; internal set; }
    }
}
