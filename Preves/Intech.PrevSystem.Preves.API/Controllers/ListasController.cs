using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Intech.PrevSystem.Preves.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Listas")]
    public class ListasController : Controller
    {
        [HttpGet("fundacaoEmpresaPlano")]
        [Authorize("Bearer")]
        public IActionResult GetListasFundacaoEmpresaPlano()
        {
            try
            {
                var listas = new
                {
                    Fundacoes = new FundacaoProxy().BuscarTodas().ToList(),
                    SitPlanos = new SitPlanoProxy().BuscarTodos()
                };

                listas.Fundacoes.ForEach(fund =>
                {
                    fund.Empresas = new EmpresaProxy().BuscarPorFundacao(fund.CD_FUNDACAO).ToList();

                    fund.Empresas.ForEach(emp =>
                    {
                        emp.Planos = new PlanoProxy().BuscarPorEmpresa(emp.CD_EMPRESA).ToList();
                    });
                });

                return Json(listas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}