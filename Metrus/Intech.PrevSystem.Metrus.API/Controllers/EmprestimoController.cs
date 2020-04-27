#region Usings
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Extensoes;
using Intech.PrevSystem.Metrus.Negocio;
using Intech.PrevSystem.Negocio;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
#endregion

namespace Intech.PrevSystem.Metrus.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : Controller
    {
        #region Situacoes

        [HttpGet("situacoes")]
        public IActionResult BuscarSituacoes()
        {
            try
            {
                return Json(new SitContratoProxy().Buscar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Contratos

        [HttpGet("porCodEntid/{codEntid}")]
        public IActionResult BuscarPorCodEntid(string codEntid)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                return Json(new ContratoProxyMetrus().BuscarPorFundacaoEmpresaInscricao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_INSCRICAO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidPlano/{codEntid}/{cdPlano}")]
        public IActionResult BuscarPorCodEntidPlano(string codEntid, string cdPlano)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                return Json(new ContratoProxyMetrus().BuscarPorFundacaoEmpresaPlanoInscricao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano, funcionario.NUM_INSCRICAO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidSituacao/{codEntid}/{situacao}")]
        public IActionResult BuscarPorCodEntidSituacao(string codEntid, string situacao)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                return Json(new ContratoProxyMetrus().BuscarPorFundacaoEmpresaInscricaoSituacao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_INSCRICAO, situacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidPlanoSituacao/{codEntid}/{cdPlano}/{situacao}")]
        public IActionResult BuscarPorCodEntidPlanoSituacao(string codEntid, string cdPlano, string situacao)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                return Json(new ContratoProxyMetrus().BuscarPorFundacaoEmpresaPlanoInscricaoSituacao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano, funcionario.NUM_INSCRICAO, situacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Prestações

        [HttpGet("prestacoesPorCodEntidNumContratoAnoContrato/{codEntid}/{numContrato}/{anoContrato}")]
        public IActionResult BuscarPrestacoesPorCodEntidNumContratoAnoContrato(string codEntid, decimal numContrato, decimal anoContrato)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                return Json(new PrestacaoProxy().BuscarResumoPorFundacaoContrato(funcionario.CD_FUNDACAO, anoContrato, numContrato));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Parâmetros

        [HttpGet("parametrosPorCodEntid/{codEntid}")]
        public IActionResult BuscarParametros(string codEntid)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                
                var planos = new PlanoVinculadoProxyMetrus().BuscarPorFundacaoEmpresaMatriculaComModalidades(funcionario);

                // ------------
                // Datas de crédito

                var feriados = new FeriadoProxy().BuscarDatas().ToList();
                var dataCredito = DateTime.Today;

                while (dataCredito.DayOfWeek != DayOfWeek.Friday)
                    dataCredito = dataCredito.AddDays(1);

                var listaTemp = new List<DateTime>();
                var listaDatasCredito = new List<DateTime>();

                listaTemp.Add(dataCredito.AddDays(7));
                listaTemp.Add(dataCredito.AddDays(14));
                listaTemp.Add(dataCredito.AddDays(21));

                foreach (DateTime item in listaTemp)
                {
                    dataCredito = item;

                    if (feriados.Contains(dataCredito))
                        dataCredito = item.AddDiaUtil(1, feriados);

                    listaDatasCredito.Add(dataCredito);
                }

                var retorno = new
                {
                    DataSolicitacao = DateTime.Now,
                    Planos = planos,
                    DatasCredito = listaDatasCredito
                };

                return Json(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex.Message
                });
            }
        }

        [HttpGet("calcularDataDesconto/{dataCredito}/{carencia}")]
        public IActionResult CalularDataDesconto(string dataCredito, int carencia)
        {
            DateTime dataAux = DateTime.ParseExact(dataCredito, "dd.MM.yyyy", new CultureInfo("pt-BR"));

            var listaFeriados = new FeriadoProxy().Buscar().ToList();
            dataAux = dataAux.AddMonths(carencia + 1);

            DateTime dataFinal = new DateTime(dataAux.Year, dataAux.Month,dataAux.UltimoDiaUtilDoMes(listaFeriados));

            return Json(new { data = dataFinal });
        }

        [HttpGet("buscarConcessao/{codEntid}/{cdPlano}/{cdNatur}/{dataCredito}")]
        public IActionResult BuscarConcessao(string codEntid, string cdPlano, decimal cdNatur, string dataCredito)
        {
            try
            {
                DateTime dtCredito = DateTime.ParseExact(dataCredito, "dd.MM.yyyy", new CultureInfo("pt-BR"));
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);

                var concessao = ConcessaoMetrus.ObtemConcessao(funcionario, cdPlano, cdNatur, 1, dtCredito, DateTime.Now);

                return Json(new { concessao });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("parametrosParcelas")]
        public IActionResult ParametrosParcelas([FromBody] ParametrosSimulacaoEmprestimo dados)
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(dados.CodEntid);
                var contratosDisponiveis = new ContratoDisponivel().BuscarContratosDisponiveis(funcionario, dados.Concessao, dados.CdPlano, dados.CD_MODAL, dados.CD_NATUR, dados.DataCredito, dados.ValorSolicitado, dados.Carencia);

                if (contratosDisponiveis.Count > 0)
                    return Json(contratosDisponiveis);
                else
                    return Json(new {
                        mensagem = "Não existem parcelas disponíveis para simulação/contratação"
                    });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("contratar")]
        public IActionResult Contratar([FromBody] ParametrosContrato dados)
        {
            try
            {
                throw new Exception("No momento a cotratação de empréstimos está inabilitada!");
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(dados.CodEntid);
                return Json(new
                {
                    AnoNumContrato = new ContratoProxyMetrus().Contratar(funcionario, dados.Contrato, dados.Concessao, dados.SaldoDevedor)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex.Message
                });
            }
        }

        #endregion
    }

    public class ParametrosSimulacaoEmprestimo
    {
        public string CodEntid { get; set; }
        public string CdPlano { get; set; }
        public decimal CD_MODAL { get; set; }
        public decimal CD_NATUR { get; set; }
        public DateTime DataCredito { get; set; }
        public decimal ValorSolicitado { get; set; }
        public decimal Carencia { get; set; }
        public ConcessaoEntidade Concessao { get; set; }
    }

    public class ParametrosContrato
    {
        public string CodEntid { get; set; }
        public string CdPlano { get; set; }
        public ContratoDisponivel Contrato { get; set; }
        public ConcessaoEntidade Concessao { get; set; }
        public SaldoDevedorEntidade SaldoDevedor { get; set; }
    }
}