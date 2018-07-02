#region Usings
using Microsoft.AspNetCore.Mvc;
using System.Reflection; 
#endregion

namespace Intech.PrevSystem.API
{
    public class BaseVersaoController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            var version = Assembly.GetExecutingAssembly().GetName();
            return Json(version.Version.ToString(3));
        }
    }
}
