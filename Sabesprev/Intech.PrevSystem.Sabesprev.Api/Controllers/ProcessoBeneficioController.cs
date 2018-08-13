#region Usings
using Intech.PrevSystem.API;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Negocio.Proxy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
#endregion

namespace Intech.PrevSystem.Sabesprev.Api.Controllers
{
    [Route(RotasApi.ProcessoBeneficio)]
    public class ProcessoBeneficioController : BaseProcessoBeneficioController
    {
    }
}
