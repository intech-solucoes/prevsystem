#region Usings
using Microsoft.AspNetCore.Mvc;
using System;
#endregion

namespace Intech.PrevSystem.API
{
    public abstract class BaseController : Controller
    {
        public string CodEntid => User.Claims.GetValue("CodEntid");
        public string Cpf => User.Claims.GetValue("Cpf");
        public string Matricula => User.Claims.GetValue("Matricula");
        public string Inscricao => User.Claims.GetValue("Inscricao");


    }
}
