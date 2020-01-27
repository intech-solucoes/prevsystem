﻿#region Usings
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System; 
#endregion

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class DadosPessoaisProxy : DadosPessoaisDAO
    {
        public override DadosPessoaisEntidade BuscarPorCodEntid(string COD_ENTID)
        {
            var dadosPessoais = base.BuscarPorCodEntid(COD_ENTID);

            if(!string.IsNullOrEmpty(dadosPessoais.CPF_CGC))
                dadosPessoais.CPF_CGC = dadosPessoais.CPF_CGC.AplicarMascara(Mascaras.CPF);

            if (!string.IsNullOrEmpty(dadosPessoais.SEXO))
                dadosPessoais.DS_SEXO = dadosPessoais.SEXO.Substring(0, 1).ToUpper() == "F" ? "FEMININO" : "MASCULINO";
            else
                dadosPessoais.DS_SEXO = "-";

            return dadosPessoais;
        }
    }
}