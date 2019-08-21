#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class PlanoVinculadoProxy : PlanoVinculadoDAO
    {
        public override IEnumerable<PlanoVinculadoEntidade> BuscarPorFundacaoEmpresaMatricula(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA)
        {
            var planos = base.BuscarPorFundacaoEmpresaMatricula(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA).ToList();

            planos.ForEach(plano =>
            {
                plano.ProcessoBeneficio = new ProcessoBeneficioProxy().BuscarPorFundacaoEmpresaMatriculaPlano(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, plano.CD_PLANO).FirstOrDefault();
            });

            return planos;
        }

        public override PlanoVinculadoEntidade BuscarPorFundacaoEmpresaMatriculaPlano(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO)
        {
            var plano = base.BuscarPorFundacaoEmpresaMatriculaPlano(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO);

            plano.ProcessoBeneficio = new ProcessoBeneficioProxy().BuscarPorFundacaoEmpresaMatriculaPlano(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, plano.CD_PLANO).FirstOrDefault();

            return plano;
        }

        public  PlanoVinculadoEntidade BuscarPorFundacaoEmpresaMatriculaPlanoComSalario(string CD_FUNDACAO, string CD_EMPRESA, string NUM_MATRICULA, string CD_PLANO, int? seqRecebedor)
        {
            var plano = BuscarPorFundacaoEmpresaMatriculaPlano(CD_FUNDACAO, CD_EMPRESA, NUM_MATRICULA, CD_PLANO);

            decimal origem;
            switch (plano.CD_CATEGORIA)
            {
                case DMN_CATEGORIA.ATIVO:
                case DMN_CATEGORIA.AUTOPATROCINIO:
                case DMN_CATEGORIA.EM_LICENCA: //Ativos, Autopatrocinados ou Em licença
                case DMN_CATEGORIA.DIFERIDO: //Assistidos ou Diferidos
                    origem = 1;
                    break;
                case DMN_CATEGORIA.ASSISTIDO:
                    origem = 4;
                    break;
                case DMN_CATEGORIA.DESLIGADO: //Desligados
                default:
                    throw new Exception("Concessão de empréstimo não permitida para usuários na situação Desligado");
            }

            plano.UltimoSalario = BuscarUltimoSalario(CD_EMPRESA, NUM_MATRICULA, origem, plano, seqRecebedor: seqRecebedor);

            return plano;
        }

        public decimal BuscarUltimoSalario(string cdEmpresa, string matricula, decimal origem, PlanoVinculadoEntidade plano, bool abatePensao = true, int? seqRecebedor = null)
        {
            var dataAtual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 01);
            var dataAnterior = new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, 01);

            var rubricasAdicionais = new RubricasAdicionaisProxy().BuscarPorFundacaoEmpresaMatriculaOrigemReferencia(plano.CD_FUNDACAO, cdEmpresa, matricula, origem, dataAtual, dataAnterior);

            var valorPensao = rubricasAdicionais.Where(x => x.CD_RUBRICA == "761").Sum(x => x.VL_RUBRICA).Value;
            
            switch (plano.CD_CATEGORIA)
            {
                case DMN_CATEGORIA.ATIVO:
                    var salario = ObtemSalarioAtivoMetrus(plano).Value;
                    return abatePensao ? salario - valorPensao : salario;
                case DMN_CATEGORIA.AUTOPATROCINIO:
                case DMN_CATEGORIA.EM_LICENCA:       //Ativos, Autopatrocinados ou Em licença
                case DMN_CATEGORIA.DIFERIDO:
                    return 0;
                    //return p.ObtemUltimoSRCFichaFinanceira() - valorPensao;//Buscar entrada mais recente da ficha financeira 
                case DMN_CATEGORIA.ASSISTIDO:      //Assistidos
                    return ObtemSalarioDosAssistidos(cdEmpresa, matricula, plano, seqRecebedor);
                case DMN_CATEGORIA.DESLIGADO:       //Desligados
                default:
                    return 0;
            }
        }

        private decimal? ObtemSalarioAtivoMetrus(PlanoVinculadoEntidade plano)
        {
            var fichaFinanceira = new FichaFinanceiraProxy().BuscarPorFundacaoPlanoInscricao(plano.CD_FUNDACAO, plano.CD_PLANO, plano.NUM_INSCRICAO).ToList();

            switch (plano.CD_PLANO)
            {
                case "0002":
                    return fichaFinanceira
                        .Where(x => x.CD_TIPO_CONTRIBUICAO == "34")
                        .OrderByDescending(x => x.ANO_COMP)
                        .ThenByDescending(x => x.MES_COMP)
                        .ToList()
                        .FirstOrDefault()
                        .SRC;
                case "0001":
                    return fichaFinanceira.Where(x => x.CD_TIPO_CONTRIBUICAO == "01")
                        .OrderByDescending(x => x.ANO_COMP)
                        .ThenByDescending(x => x.MES_COMP)
                        .ToList()
                        .FirstOrDefault()
                        .SRC;
                default:
                    return 0;
            }
        }

        private decimal ObtemSalarioDosAssistidos(string cdEmpresa, string numMatricula, PlanoVinculadoEntidade plano, int? seqRecebedor)
        {
            if (!seqRecebedor.HasValue)
                throw new Exception("Assistido não possui SeqRecebedor ao buscar Salario Real de Contribuicao");

            //var fichas = new FichaFinanceiraAssistidoProxy().BuscarDatasPorRecebedor(plano.CD_FUNDACAO, cdEmpresa, numMatricula, seqRecebedor, plano.CD_PLANO, );

            var fichas = new List<FichaFinanceiraAssistidoEntidade>();

            //Buscar todas RUBRICAS_PREVIDENCIAL com INCID_LIQUIDO  = 'S' e INCID_MARGEM_CONSIG = 'S'
            var enRubrica = new RubricasPrevidencialProxy().BuscarIncideLiquidoMargemConsig(DMN_SN.SIM, DMN_SN.SIM).ToList();
            
            var proxyFichaFinancAssistido = new FichaFinanceiraAssistidoProxy();
            var dtFichas = proxyFichaFinancAssistido
                .BuscarPorFundacaoEmpresaMatriculaPlanoRecebedor(plano.CD_FUNDACAO, cdEmpresa, numMatricula, seqRecebedor.Value, plano.CD_PLANO);

            var qry = from row in dtFichas
                      where enRubrica.Select(x => x.CD_RUBRICA).Contains(row.CD_RUBRICA)
                      select row;

            foreach (var ficha in qry)
            {
                var Rubrica = enRubrica.Where(x => x.CD_RUBRICA == ficha.CD_RUBRICA).SingleOrDefault();
                string provdesc = Rubrica.RUBRICA_PROV_DESC;
                fichas.Add(ficha);
            }

            DateTime dt = DateTime.Today;
            decimal total = 0;

            int i = 0;
            do
            {
                DateTime dtCompInicial = new DateTime(dt.Year, dt.Month, 1);
                DateTime dtCompFinal = dt.UltimoDiaDoMes();

                var filtro = fichas.Where(x => x.DT_COMPETENCIA >= dtCompInicial
                     && x.DT_COMPETENCIA <= dtCompFinal);

                //verificar se existe dados, senao buscar dados do mes anterior ate encontrar 
                //ou a pesquisa procure por mais de 1 ano
                if (filtro.Count() != 0)
                {
                    foreach (var item in filtro)
                    {
                        if (item.RUBRICA_PROV_DESC == "P")
                            total += item.VALOR_MC.Value;
                        else
                            total -= item.VALOR_MC.Value;
                    }

                    break;
                }

                dt = dt.AddMonths(-1);

                i++;
            } while (i < 12); //while evita loop infinito na logica

            return total;
        }
    }
}
