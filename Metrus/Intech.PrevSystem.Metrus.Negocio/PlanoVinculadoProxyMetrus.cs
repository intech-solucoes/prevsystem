using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Constantes;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intech.PrevSystem.Metrus.Negocio
{
    public class PlanoVinculadoProxyMetrus : PlanoVinculadoProxy
    {
        public IEnumerable<PlanoVinculadoEntidade> BuscarPorFundacaoEmpresaMatriculaComModalidades(FuncionarioEntidade funcionario, bool abatePensao = true)
        {
            var planos = base.BuscarPorFundacaoEmpresaMatricula(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA).ToList();

            var categoria = new CategoriaProxy().BuscarPorCdCategoria(planos[0].CD_CATEGORIA);
            var sitPlano = new SitPlanoProxy().BuscarPorCdSituacao(planos[0].CD_SIT_PLANO);

            if (planos.Count == 0 || categoria.PERMITE_EMPRESTIMO == "N" || sitPlano.permite_emprestimo_em == "N")
                throw new Exception("Participante não elegível à concessão de empréstimo. Dúvidas entrar em contato com a central de relacionamento pelo telefone 0800 16 05 95");

            var contrato = new ContratoProxyMetrus().BuscarPorFundacaoEmpresaInscricaoSituacao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_INSCRICAO, "3").FirstOrDefault();
            if (contrato != null)
            {
                var regraNatureza = new RegraNaturezaProxy().BuscarPorQtdReformas(1);

                var quantidadeDeParcelasPagas = contrato.Prestacoes.Count(x => x.DT_PAGTO != null);
                decimal percentualMinimo = Convert.ToDecimal(regraNatureza.PERCENTUAL_QTD);
                decimal quantidadeMinimaDeParcelasPagas = Math.Round((contrato.PRAZO * percentualMinimo) / 100, 0);

                if (quantidadeDeParcelasPagas < quantidadeMinimaDeParcelasPagas)
                    throw new Exception($"Contrato não pode ser Reformado pois, não atingiu o Limite de Carência para Reforma. Número mínimo de Prestações Pagas (Limite): {quantidadeMinimaDeParcelasPagas}. Número de Prestações Pagas: {quantidadeDeParcelasPagas}.");
            }

            var proxyBeneficio = new ProcessoBeneficioProxy();

            foreach(var plano in planos)
            {
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

                plano.UltimoSalario = BuscarUltimoSalario(funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA, origem, plano, abatePensao);
                plano.ProcessoBeneficio = proxyBeneficio.BuscarPorFundacaoEmpresaMatriculaPlano(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA, plano.CD_PLANO);
                plano.Modalidades = new ModalidadeProxyMetrus().BuscarAtivasComNaturezas(funcionario, funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_MATRICULA, origem, plano);
            }

            return planos;
        }
    }
}
