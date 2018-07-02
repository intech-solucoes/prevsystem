#region Usings
using Microsoft.AspNetCore.Mvc;
using System.Reflection; 
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route("api/")]
    public class VersaoController : Controller
    {
        public IActionResult Get()
        {
            var version = Assembly.GetExecutingAssembly().GetName();
            return Json(version.Version.ToString(3));
        }
    }
}
