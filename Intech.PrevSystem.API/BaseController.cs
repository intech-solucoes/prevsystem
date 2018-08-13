﻿#region Usings
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
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
        public string CdFundacao => User.Claims.GetValue("CdFundacao");
        public string CdEmpresa => User.Claims.GetValue("CdEmpresa");
        public bool Pensionista => Convert.ToBoolean(User.Claims.GetValue("Pensionista"));
        public int SeqRecebedor => Convert.ToInt32(User.Claims.GetValue("SeqRecebedor"));
        public string GrupoFamilia => User.Claims.GetValue("GrupoFamilia");
    }
}
