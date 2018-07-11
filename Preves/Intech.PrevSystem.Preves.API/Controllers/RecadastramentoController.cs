#region Usings
using Intech.PrevSystem.API;
using Intech.PrevSystem.Negocio.Proxy;
using Intech.PrevSystem.Preves.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Preves.API.Controllers
{
    [Route("api/recadastramento")]
    public class RecadastramentoController : BaseController
    {
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            try
            {
                var funcionario = new FuncionarioProxy().BuscarPorCodEntid(CodEntid);
                var entidade = new EntidadeProxy().BuscarPorCodEntid(CodEntid);
                var plano = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatricula(funcionario.CD_FUNDACAO, funcionario.CD_EMPRESA, Matricula).First();
                var dadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(CodEntid);
                var empresa = new EmpresaProxy().BuscarPorCodigo(funcionario.CD_EMPRESA);
                var banco = new BancoAgProxy().BuscarPorCodBancoCodAgencia(entidade.NUM_BANCO, "00000");

                return Json(new Recadastramento(funcionario, entidade, dadosPessoais, empresa, plano, banco).BuscarPassos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}