#region Usings
using Intech.Lib.Log.Core;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Entidades.Extensoes;
using Intech.PrevSystem.Metrus.Negocio;
using Intech.PrevSystem.Metrus.Negocio.Constantes;
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

        [HttpGet("situacoes/{oidAcesso}")]
        public IActionResult BuscarSituacoes(int oidAcesso)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.EMPRESTIMO_SITUACOES);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                return Json(new SitContratoProxy().Buscar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Contratos

        [HttpGet("porCodEntid/{oidAcesso}/{codEntid}")]
        public IActionResult BuscarPorCodEntid(int oidAcesso, string codEntid)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.EMPRESTIMO_POR_CODENTID);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                //var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var funcionario = new DadosMetrusProxy().BuscarPorCodEntid(codEntid).Funcionario;

                return Json(new ContratoProxyMetrus().BuscarPorFundacaoEmpresaInscricao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_INSCRICAO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidPlano/{oidAcesso}/{codEntid}/{cdPlano}")]
        public IActionResult BuscarPorCodEntidPlano(int oidAcesso, string codEntid, string cdPlano)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.EMPRESTIMO_POR_CODENTID_PLANO);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                //var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var funcionario = new DadosMetrusProxy().BuscarPorCodEntid(codEntid).Funcionario;

                return Json(new ContratoProxyMetrus().BuscarPorFundacaoEmpresaPlanoInscricao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano, funcionario.NUM_INSCRICAO));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidSituacao/{oidAcesso}/{codEntid}/{situacao}")]
        public IActionResult BuscarPorCodEntidSituacao(int oidAcesso, string codEntid, string situacao)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.EMPRESTIMO_POR_CODENTID_SITUACAO);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                //var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var funcionario = new DadosMetrusProxy().BuscarPorCodEntid(codEntid).Funcionario;

                return Json(new ContratoProxyMetrus().BuscarPorFundacaoEmpresaInscricaoSituacao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, funcionario.NUM_INSCRICAO, situacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("porCodEntidPlanoSituacao/{oidAcesso}/{codEntid}/{cdPlano}/{situacao}")]
        public IActionResult BuscarPorCodEntidPlanoSituacao(int oidAcesso, string codEntid, string cdPlano, string situacao)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.EMPRESTIMO_POR_CODENTID_PLANO_SITUACAO);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                //var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var funcionario = new DadosMetrusProxy().BuscarPorCodEntid(codEntid).Funcionario;

                return Json(new ContratoProxyMetrus().BuscarPorFundacaoEmpresaPlanoInscricaoSituacao(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, cdPlano, funcionario.NUM_INSCRICAO, situacao));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Prestações

        [HttpGet("prestacoesPorCodEntidNumContratoAnoContrato/{oidAcesso}/{codEntid}/{numContrato}/{anoContrato}")]
        public IActionResult BuscarPrestacoesPorCodEntidNumContratoAnoContrato(int oidAcesso, string codEntid, decimal numContrato, decimal anoContrato)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.EMPRESTIMO_PRESTACOES);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                //var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var funcionario = new DadosMetrusProxy().BuscarPorCodEntid(codEntid).Funcionario;

                return Json(new PrestacaoProxy().BuscarResumoPorFundacaoContrato(funcionario.CD_FUNDACAO, anoContrato, numContrato));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Parâmetros

        [HttpGet("parametrosPorCodEntid/{oidAcesso}/{codEntid}")]
        public IActionResult BuscarParametros(int oidAcesso, string codEntid)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.EMPRESTIMO_PARAMETROS);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                //var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var funcionario = new DadosMetrusProxy().BuscarPorCodEntid(codEntid).Funcionario;

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

        [HttpGet("calcularDataDesconto/{oidAcesso}/{dataCredito}/{carencia}")]
        public IActionResult CalularDataDesconto(int oidAcesso, string dataCredito, int carencia)
        {
            var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.EMPRESTIMO_CALCULAR_DATA_DESCONTO);
            new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

            DateTime dataAux = DateTime.ParseExact(dataCredito, "dd.MM.yyyy", new CultureInfo("pt-BR"));

            var listaFeriados = new FeriadoProxy().Buscar().ToList();
            dataAux = dataAux.AddMonths(carencia + 1);

            DateTime dataFinal = new DateTime(dataAux.Year, dataAux.Month,dataAux.UltimoDiaUtilDoMes(listaFeriados));

            return Json(new { data = dataFinal });
        }

        [HttpGet("buscarConcessao/{oidAcesso}/{codEntid}/{cdPlano}/{cdNatur}/{dataCredito}")]
        public IActionResult BuscarConcessao(int oidAcesso, string codEntid, string cdPlano, decimal cdNatur, string dataCredito)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.EMPRESTIMO_BUSCAR_CONCESSAO);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                DateTime dtCredito = DateTime.ParseExact(dataCredito, "dd.MM.yyyy", new CultureInfo("pt-BR"));
                //var funcionario = new FuncionarioProxy().BuscarPorCodEntid(codEntid);
                var funcionario = new DadosMetrusProxy().BuscarPorCodEntid(codEntid).Funcionario;

                var concessao = ConcessaoMetrus.ObtemConcessao(funcionario, cdPlano, cdNatur, 1, dtCredito, DateTime.Now);

                return Json(new { concessao });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("parametrosParcelas/{oidAcesso}")]
        public IActionResult ParametrosParcelas([FromBody] ParametrosSimulacaoEmprestimo dados, int oidAcesso)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.EMPRESTIMO_PARAMETROS_PARCELAS);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                //var funcionario = new FuncionarioProxy().BuscarPorCodEntid(dados.CodEntid);
                var funcionario = new DadosMetrusProxy().BuscarPorCodEntid(dados.CodEntid).Funcionario;
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

        [HttpPost("contratar/{oidAcesso}")]
        public IActionResult Contratar([FromBody] ParametrosContrato dados, int oidAcesso)
        {
            try
            {
                var funcionalidade = new FuncionalidadeProxy().BuscarPorNumFuncionalidade(DMN_FUNCIONALIDADE.EMPRESTIMO_CONTRATAR);
                new Logger().CriarLog(oidAcesso, funcionalidade.OID_FUNCIONALIDADE);

                throw new Exception("No momento a cotratação de empréstimos está inabilitada!");
                //var funcionario = new FuncionarioProxy().BuscarPorCodEntid(dados.CodEntid);
                var funcionario = new DadosMetrusProxy().BuscarPorCodEntid(dados.CodEntid).Funcionario;
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