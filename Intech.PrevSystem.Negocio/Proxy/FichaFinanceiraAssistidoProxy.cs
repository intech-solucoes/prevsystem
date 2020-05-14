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
        public override List<FichaFinanceiraAssistidoEntidade> BuscarDatas(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO)
        {
            var datas = base.BuscarDatas(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO).ToList();

            foreach(var data in datas)
            {
                var rubricasData = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaTipoFolha(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, data.DT_REFERENCIA, data.CD_TIPO_FOLHA);

                data.VAL_BRUTO = rubricasData.Where(x => x.RUBRICA_PROV_DESC == "P").Sum(x => x.VALOR_MC);
                data.VAL_DESCONTOS = rubricasData.Where(x => x.RUBRICA_PROV_DESC == "D").Sum(x => x.VALOR_MC);
                data.VAL_LIQUIDO = data.VAL_BRUTO - Math.Abs(data.VAL_DESCONTOS.Value);
            }

            return datas;
        }

        public override List<FichaFinanceiraAssistidoEntidade> BuscarDatasPorRecebedor(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, int SEQ_RECEBEDOR, string CD_PLANO)
        {
            var datas = base.BuscarDatasPorRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SEQ_RECEBEDOR, CD_PLANO).ToList();

            datas.ForEach(data =>
            {
                var rubricasData = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaTipoFolhaRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SEQ_RECEBEDOR, CD_PLANO, data.DT_REFERENCIA, data.CD_TIPO_FOLHA);

                data.VAL_BRUTO = rubricasData.Where(x => x.RUBRICA_PROV_DESC == "P").Sum(x => x.VALOR_MC);
                data.VAL_DESCONTOS = rubricasData.Where(x => x.RUBRICA_PROV_DESC == "D").Sum(x => x.VALOR_MC);
                data.VAL_LIQUIDO = data.VAL_BRUTO - Math.Abs(data.VAL_DESCONTOS.Value);
            });

            return datas;
        }

        public dynamic BuscarRubricasPorFundacaoEmpresaMatriculaPlanoCompetencia(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, DateTime DT_COMPETENCIA, string CD_TIPO_FOLHA, int? SeqRecebedor = null)
            => BuscarRubricasPorFundacaoEmpresaMatriculaPlanoCompetenciaEspecie(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_COMPETENCIA, CD_TIPO_FOLHA, null, SeqRecebedor);

        public dynamic BuscarRubricasPorFundacaoEmpresaMatriculaPlanoCompetenciaEspecie(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, DateTime DT_COMPETENCIA, string CD_TIPO_FOLHA, string CD_ESPECIE, int? SeqRecebedor = null)
        {
            List<FichaFinanceiraAssistidoEntidade> rubricas;

            if (SeqRecebedor.HasValue)
                rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoCompetenciaRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SeqRecebedor.Value, CD_PLANO, DT_COMPETENCIA, CD_TIPO_FOLHA).ToList();
            else
                rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoCompetencia(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_COMPETENCIA, CD_TIPO_FOLHA).ToList();

            if (!string.IsNullOrEmpty(CD_ESPECIE))
                rubricas = rubricas.Where(x => x.CD_ESPECIE == CD_ESPECIE).ToList();

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

        public dynamic Metrus_BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferencia(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, DateTime DT_COMPETENCIA, string CD_TIPO_FOLHA, int? SeqRecebedor = null)
            => Metrus_BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferenciaEspecie(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_COMPETENCIA, CD_TIPO_FOLHA, null, SeqRecebedor);

        public dynamic Metrus_BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferenciaEspecie(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, DateTime DT_REFERENCIA, string CD_TIPO_FOLHA, string CD_ESPECIE, int? SeqRecebedor = null)
        {
            List<FichaFinanceiraAssistidoEntidade> rubricas;

            if (SeqRecebedor.HasValue)
                rubricas = base.Metrus_BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaTipoFolhaRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SeqRecebedor.Value, CD_PLANO, DT_REFERENCIA, CD_TIPO_FOLHA).ToList();
            else
                rubricas = base.Metrus_BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaTipoFolha(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_REFERENCIA, CD_TIPO_FOLHA).ToList();

            if (!string.IsNullOrEmpty(CD_ESPECIE))
                rubricas = rubricas.Where(x => x.CD_ESPECIE == CD_ESPECIE).ToList();

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
                Resumo = new ContrachequeResumo
                {
                    Referencia = DT_REFERENCIA,
                    Bruto = bruto,
                    Descontos = valDescontos,
                    Liquido = liquido,
                    TipoFolha = rubricas.First().CD_TIPO_FOLHA,
                    DesTipoFolha = rubricas.First().DS_TIPO_FOLHA
                }
            };
        }

        public Contracheque BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferencia(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, DateTime DT_COMPETENCIA, string CD_TIPO_FOLHA, int? SeqRecebedor = null)
            => BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferenciaEspecie(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_COMPETENCIA, CD_TIPO_FOLHA, null, SeqRecebedor);

        public Contracheque BuscarRubricasPorFundacaoEmpresaMatriculaPlanoReferenciaEspecie(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, DateTime DT_REFERENCIA, string CD_TIPO_FOLHA, string CD_ESPECIE, int? SeqRecebedor = null)
        {
            List<FichaFinanceiraAssistidoEntidade> rubricas;
                
            if(SeqRecebedor.HasValue)
                rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaTipoFolhaRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SeqRecebedor.Value, CD_PLANO, DT_REFERENCIA, CD_TIPO_FOLHA).ToList();
            else
                rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaTipoFolha(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, DT_REFERENCIA, CD_TIPO_FOLHA).ToList();

            if(!string.IsNullOrEmpty(CD_ESPECIE))
                rubricas = rubricas.Where(x => x.CD_ESPECIE == CD_ESPECIE).ToList();

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

        public dynamic BuscarUltimaFolhaPorFundacaoEmpresaMatriculaPlanoProcesso(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, string CD_ESPECIE, string ANO_PROCESSO, string NUM_PROCESSO, int? SeqRecebedor = null)
        {
            List<FichaFinanceiraAssistidoEntidade> rubricas = new List<FichaFinanceiraAssistidoEntidade>();

            if (SeqRecebedor.HasValue)
            {
                var ultima = base.BuscarUltimaPorProcessoRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SeqRecebedor.Value, CD_PLANO, CD_ESPECIE, ANO_PROCESSO, NUM_PROCESSO).FirstOrDefault();

                if (ultima != null)
                    rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaProcessoRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SeqRecebedor.Value, CD_PLANO, ultima.DT_REFERENCIA, ANO_PROCESSO, NUM_PROCESSO).ToList();
            }
            else
            {
                var ultima = base.BuscarUltimaPorProcesso(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, CD_ESPECIE, ANO_PROCESSO, NUM_PROCESSO).FirstOrDefault();

                if(ultima != null)
                    rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaProcesso(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, ultima.DT_REFERENCIA, ANO_PROCESSO, NUM_PROCESSO).ToList();
            }

            if (!string.IsNullOrEmpty(CD_ESPECIE))
                rubricas = rubricas.Where(x => x.CD_ESPECIE == CD_ESPECIE).ToList();

            var proventos = rubricas.Where(x => x.RUBRICA_PROV_DESC == "P").ToList();
            var descontos = rubricas.Where(x => x.RUBRICA_PROV_DESC == "D").ToList();

            foreach (var rubrica in descontos)
                rubrica.VALOR_MC *= -1;

            var bruto = proventos.Sum(x => x.VALOR_MC);
            var valDescontos = descontos.Sum(x => x.VALOR_MC);
            var liquido = bruto - Math.Abs(valDescontos.Value);

            var cdTipoFolha = "";
            var desTipoFolha = "";
            DateTime dtReferencia = new DateTime();
            var indice = new IndiceValoresEntidade();

            if (rubricas.Any())
            {
                indice = new IndiceValoresProxy().BuscarReservaPoupanca(rubricas.First().DT_REFERENCIA.PrimeiroDiaDoMes());
                cdTipoFolha = rubricas.First().CD_TIPO_FOLHA;
                desTipoFolha = rubricas.First().DS_TIPO_FOLHA;
                dtReferencia = rubricas.First().DT_REFERENCIA;
            }

            return new
            {
                Proventos = proventos,
                Descontos = descontos,
                Resumo = new
                {
                    Referencia = dtReferencia,
                    Bruto = bruto,
                    Descontos = valDescontos,
                    Liquido = liquido,
                    TipoFolha = cdTipoFolha,
                    DesTipoFolha = desTipoFolha,
                    Indice = indice
                }
            };
        }

        public dynamic BuscarUltimaFolhaPorFundacaoEmpresaMatriculaPlano(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, int? SeqRecebedor = null)
        {
            List<FichaFinanceiraAssistidoEntidade> rubricas;

            if (SeqRecebedor.HasValue)
            {
                var ultima = base.BuscarUltimaPorRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SeqRecebedor.Value, CD_PLANO).First();
                rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferenciaRecebedor(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, SeqRecebedor.Value, CD_PLANO, ultima.DT_REFERENCIA).ToList();
            }
            else
            {
                var ultima = base.BuscarUltima(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO).First();
                rubricas = base.BuscarPorFundacaoEmpresaMatriculaPlanoReferencia(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO, ultima.DT_REFERENCIA).ToList();
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
        public List<FichaFinanceiraAssistidoEntidade> Rubricas { get; set; }
        public List<FichaFinanceiraAssistidoEntidade> Proventos { get; set; }
        public List<FichaFinanceiraAssistidoEntidade> Descontos { get; set; }
        public List<FichaFinanceiraAssistidoEntidade> Outros { get; set; }
        public ContrachequeResumo Resumo { get; set; }
    }

    public class ContrachequeResumo
    {
        public DateTime Referencia { get; set; }
        public DateTime DataCredito { get; set; }
        public decimal? Bruto { get; set; }
        public decimal? Descontos { get; set; }
        public decimal? Liquido { get; set; }
        public string TipoFolha { get; set; }
        public string DesTipoFolha { get; set; }
    }
}