#region Usings
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Mvc;
using System; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseFatorRiscoController : BaseController
    {
        [HttpGet("porFundacaoPlano/{fundacao}")]
        public IActionResult GetPorFundacaoPlano(string fundacao, string plano, int idade)
        {
            try
            {
                return Json(new FatorRiscoProxy().BuscarPorFundacaoPlano(fundacao, plano, idade));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
